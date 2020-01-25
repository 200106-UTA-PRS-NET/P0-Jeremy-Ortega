using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Logic.Portal
{
    public class HeaderPortal
    {
        public static void printHeaderPortal(string username)
        {
            Console.Clear();
            Console.WriteLine(" _________________________________________________________________");
            Console.WriteLine(" | Hello:\t[" + username + "]");
            Console.WriteLine(" |----------------------------------------------------------------");
        }
    }
}
