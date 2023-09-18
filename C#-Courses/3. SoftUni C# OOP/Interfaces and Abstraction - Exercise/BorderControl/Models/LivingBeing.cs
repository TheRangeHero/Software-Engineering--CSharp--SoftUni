
namespace BorderControl.Models
{
    using Interfaces;
    abstract class LivingBeing : ILivingcreatures
    {
        public LivingBeing(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; private set; }

        public string BirthDate { get; private set; }
    }
}
