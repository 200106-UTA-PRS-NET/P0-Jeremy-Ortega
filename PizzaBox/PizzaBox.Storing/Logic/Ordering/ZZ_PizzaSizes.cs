using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Storing.Logic.Portal;

namespace PizzaBox.Storing.Logic.Ordering
{
    public class ZZ_PizzaSizes
    {
        public ZZ_PizzaSizes()
        {
        }
        /// <summary>
        /// Print the size options for a pizza
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="PizzaType"></param>
        public static void printPizzaSizeChoice(string username,string storeName, string PizzaType)
        {
            ZZ_PrintLoggedInHeader.printStoreHeaderLoggedIn(username, storeName);
            Console.WriteLine(" |  :: {0} ::  |", PizzaType);
            Console.WriteLine(" |---------------------------------------------------------");
            Console.WriteLine(" | 1. : 12\"");
            Console.WriteLine(" | 2. : 15\"");
            Console.WriteLine(" | 3  : 20\"");
            Console.WriteLine(" | 0  : return to previous page...");
            Console.WriteLine(" |_________________________________________________________");
        }
    }
}
