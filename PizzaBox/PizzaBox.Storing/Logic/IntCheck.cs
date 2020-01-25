using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Logic
{
    class IntCheck
    {
        public static int IntChecker()
        {
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Not an int");
                return -1;
            }
            return choice;
        }
    }
}
