using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {

                string item = Console.ReadLine();
                //Box<string> input = new Box<string>(item);

                //Console.WriteLine(input.ToString());
                box.Items.Add(item);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
