using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    [Author("Victor")]
    class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine("{0} is written by {1}",method.Name,attr.Name);
                    }
                }
            }
        }
    }
}
