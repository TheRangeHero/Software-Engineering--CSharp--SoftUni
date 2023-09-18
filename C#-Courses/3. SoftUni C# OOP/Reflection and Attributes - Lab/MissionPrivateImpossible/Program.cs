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
            //Spy spy = new Spy();
            //string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            //Console.WriteLine(result);

            //Spy spy = new Spy();
            //string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            //Console.WriteLine(result);

            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Stealer.Hacker");
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
        public string AnalyzeAccessModifiers(string ClassName)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = typeof(Hacker);

            var classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            var classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            var classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }


            return sb.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);

            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                sb.AppendLine(method.Name);
            }


            return sb.ToString().TrimEnd();
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
