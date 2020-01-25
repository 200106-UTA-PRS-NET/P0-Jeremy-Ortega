using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Logic.Portal
{
    public class ZZ_PrintLoggedInHeader
    {

        /// <summary>
        /// Print a common reocurring theme
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        public static void printStoreHeaderLoggedIn(string username, string storeName)
        {
            HeaderPortal.printHeaderPortal(username);
            Console.WriteLine($" | {storeName} |");
            Console.WriteLine(" |---------------------------------------------------------");
        }
    }
}
