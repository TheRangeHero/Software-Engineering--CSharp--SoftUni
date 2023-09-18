using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    class Controller : IController
    {
        private IRepository<IBooth> booths;
        private IRepository<IDelicacy> delicacies;
        private IRepository<ICocktail> cocktails;

        public Controller()
        {
            this.booths = new BoothRepository();
            this.delicacies = new DelicacyRepository();
            this.cocktails = new CocktailRepository();
        }



        public string AddBooth(int capacity)
        {
            var boothCount = this.booths.Models.Count;
            IBooth booth = new Booth(boothCount++, capacity);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }


            if (delicacies.Models.Any(x => x.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded);
            }

            IDelicacy delicacy = null;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }

            delicacies.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (cocktails.Models.Any(x => x.Name == cocktailName && x.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail = null;
            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            cocktails.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {


            if (booths.Models.All(x => x.IsReserved == true) || booths.Models.Any(x => x.IsReserved == false && x.Capacity < countOfPeople))
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            var sortedBooths = booths.Models.OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId);

            var selectedBooth = sortedBooths.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= countOfPeople);
            selectedBooth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, selectedBooth.BoothId, countOfPeople);

        }

        public string BoothReport(int boothId)
        {
            var selectedBooth = booths.Models.First(x => x.BoothId == boothId); 
          return  selectedBooth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            var selectedBooth = booths.Models.First(x => x.BoothId == boothId);
            var currentBill = selectedBooth.CurrentBill;
            selectedBooth.Charge();
            selectedBooth.ChangeStatus();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine($"Booth {selectedBooth.BoothId} is now available!");

            return sb.ToString().TrimEnd();
        }


        public string TryOrder(int boothId, string order)
        {
            var selectedBooth = booths.Models.First(x => x.BoothId == boothId);
            string[] tokens = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemType = tokens[0];
            string itemName = tokens[1];
            int count = int.Parse(tokens[2]);
            string size = null;
            if (itemType == nameof(MulledWine) || itemType == nameof(Hibernation))
            {
                size = tokens[3];
            }

            if (itemType != nameof(MulledWine) || itemType != nameof(Hibernation) || itemType != nameof(Gingerbread) || itemType != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemType);
            }

            if (itemType == nameof(MulledWine) || itemType == nameof(Hibernation))
                {
                if (!cocktails.Models.Any(x => x.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemType, itemName);

                }

                if (!cocktails.Models.Any(x=>x.Name == itemName && x.Size==size))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }

                ICocktail cocktail = null;
                if (itemType == nameof(Hibernation))
                {
                    cocktail = new Hibernation(itemName, size);
                }
                else if (itemType == nameof(MulledWine))
                {
                    cocktail = new MulledWine(itemName, size);
                }

                selectedBooth.UpdateCurrentBill(count * cocktail.Price);

                return string.Format(OutputMessages.SuccessfullyOrdered, selectedBooth.BoothId, count, itemName);
            }

            if (itemType == nameof(Gingerbread) || itemType == nameof(Stolen))
            {
                if (!delicacies.Models.Any(x => x.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemType, itemName);


                }

                if (!delicacies.Models.Any(x => x.Name == itemName ))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }

                IDelicacy delicacy = null;
                if (itemType == nameof(Gingerbread))
                {
                    delicacy = new Gingerbread(itemName);
                }
                else if (itemType == nameof(Stolen))
                {
                    delicacy = new Stolen(itemName);
                }

                selectedBooth.UpdateCurrentBill(count * delicacy.Price);

                return string.Format(OutputMessages.SuccessfullyOrdered, selectedBooth.BoothId, count, itemName);
            }

            return string.Empty;

        }
    }
}
