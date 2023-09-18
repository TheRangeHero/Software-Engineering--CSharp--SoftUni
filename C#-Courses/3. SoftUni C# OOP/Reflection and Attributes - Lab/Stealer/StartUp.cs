using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
        }


    }
    public class Spy
    {


        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }



            return sb.ToString().Trim();
        }

    }


    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        public string Password { get => password; set => password = value; }
        private int Id { get; set; }
        public double BankAccountBalance { get; private set; }


        public void DownloadAllBankAccountsInTheWorld()
        {

        }
    }
}
