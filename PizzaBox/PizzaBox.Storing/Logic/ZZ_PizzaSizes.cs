using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Logic
{
    public class ZZ_PizzaSizes
    {
        ZZ_PrintLoggedInHeader PH;
        public ZZ_PizzaSizes()
        {
            PH = new ZZ_PrintLoggedInHeader();
        }
        /// <summary>
        /// Print the size options for a pizza
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="PizzaType"></param>
        public void printPizzaSizeChoice(string username, StoreRepository stores, int locationChoice, string PizzaType)
        {
            PH.printStoreHeaderLoggedIn(username, stores, locationChoice);
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
