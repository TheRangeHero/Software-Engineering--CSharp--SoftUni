using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int usernameLenght = username.Length - 1;
            string password = "";
            for (int i = usernameLenght; i >=0 ; i--)
            {
                password += username[i];
            }

            
            int incorrectPassword = 0;
            string passInput = Console.ReadLine();
            while (passInput != password)
            {
                incorrectPassword++;               

                if (incorrectPassword > 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                Console.WriteLine($"Incorrect password. Try again.");
                passInput = Console.ReadLine();
            }

            if (passInput == password)
            {
                Console.WriteLine($"User { username} logged in.");
            }
        }       
        
    }
}
