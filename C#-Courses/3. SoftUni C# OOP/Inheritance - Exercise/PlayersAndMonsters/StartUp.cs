namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var bladeKnight = new BladeKnight("Genadi", 34);

            var wizard = new Wizard("Spas", 45);

            var darkWizard = new DarkWizard("TheRangeHero", 88);

            System.Console.WriteLine(bladeKnight);
            System.Console.WriteLine(wizard);
            System.Console.WriteLine(darkWizard);
        }
    }
}