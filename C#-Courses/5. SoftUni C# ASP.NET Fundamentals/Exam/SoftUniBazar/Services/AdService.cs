using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Contracts;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;

namespace SoftUniBazar.Services
{

    public class AdService : IAdService
    {
        private readonly BazarDbContext dbContext;

        public AdService(BazarDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public async Task<AddAdViewModel> GetNewAddBookModelAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToArrayAsync();

            AddAdViewModel model = new AddAdViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task AddBookAsync(AddAdViewModel model, string userId)
        {
            Ad ad = new Ad
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                CategoryId = model.CategoryId,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId
            };

            await dbContext.Ads.AddAsync(ad);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllAdsViewModel>> GetAllAdsAsync()
        {
            return await dbContext.Ads
                .Select(a => new AllAdsViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price,
                    Category = a.Category.Name,
                    CreatedOn = a.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Owner = a.Owner.UserName
                })
                .ToArrayAsync();
        }

        public async Task<AddAdViewModel?> GetAdByIdForEditAsync(int id)
        {
            var categories = await dbContext.Categories
               .Select(c => new CategoryViewModel
               {
                   Id = c.Id,
                   Name = c.Name,
               }).ToArrayAsync();

            return await dbContext.Ads
                .Where(a => a.Id == id)
                .Select(a => new AddAdViewModel
                {
                    Name = a.Name,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price,
                    CategoryId = a.CategoryId,
                    Categories = categories
                }).FirstOrDefaultAsync();
        }

        public async Task EditAdAsync(AddAdViewModel model, int id)
        {
            var ad = await dbContext.Ads.FindAsync(id);

            if (ad != null)
            {
                ad.Name = model.Name;
                ad.Description = model.Description;
                ad.ImageUrl = model.ImageUrl;
                ad.Price = model.Price;
                ad.CategoryId = model.CategoryId;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<AllAdsViewModel?> GetAdByIdAsync(int id)
        {
            return await dbContext.Ads
                .Where(a => a.Id == id)
                .Select(a => new AllAdsViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price,
                    Category = a.Category.Name
                }).FirstOrDefaultAsync();
        }

        public async Task AddAdToCollectionAsync(string userId, AllAdsViewModel ad)
        {
            bool alreadyAdded = await dbContext.AdsBuyers.AnyAsync(ab => ab.BuyerId == userId && ab.AdId == ad.Id);

            if(alreadyAdded == false)
            {
                var adBuyer = new AdBuyer
                {
                    AdId = ad.Id,
                    BuyerId = userId
                };

                await dbContext.AdsBuyers.AddAsync(adBuyer);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllAdsViewModel>> GetMyAdsAsync(string userId)
        {
            return await dbContext.AdsBuyers.Where(ad => ad.BuyerId == userId)
                .Select(a => new AllAdsViewModel
                {
                    Id = a.Ad.Id,
                    Name = a.Ad.Name,
                    Description = a.Ad.Description,
                    ImageUrl = a.Ad.ImageUrl,
                    Price = a.Ad.Price,
                    Category = a.Ad.Category.Name,
                    CreatedOn = a.Ad.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                   // Owner = a.Ad.Owner.UserName На снимката има селър, но не вади информация и не знам дали трябва да го показвам в My Cart колекцията
                }).ToArrayAsync();
        }

        public async Task RemoveAdFromCollectionAsync(string userId, AllAdsViewModel ad)
        {
            var buyerAd = await dbContext.AdsBuyers.FirstOrDefaultAsync(ab=>ab.BuyerId==userId && ab.AdId==ad.Id);

            if (buyerAd!=null)
            {
                dbContext.AdsBuyers.Remove(buyerAd);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> AdAlreadyAddedToCartAsync(string userId, int id)
        {
            bool alreadyAdded = await dbContext.AdsBuyers.AnyAsync(ab => ab.BuyerId == userId && ab.AdId == id);
            return alreadyAdded;
        }
    }
}
