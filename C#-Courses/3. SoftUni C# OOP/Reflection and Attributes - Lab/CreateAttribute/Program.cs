using System;


namespace AuthorProblem
{
    [Author("Victor")]
    class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
        
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
}
