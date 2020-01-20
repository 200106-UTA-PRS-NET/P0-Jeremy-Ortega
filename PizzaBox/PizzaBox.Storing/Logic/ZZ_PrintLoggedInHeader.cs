using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Logic
{
    public class ZZ_PrintLoggedInHeader
    {

        /// <summary>
        /// Print a common reocurring theme
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        public void printStoreHeaderLoggedIn(string username, string storeName)
        {
            Console.Clear();
            Console.WriteLine(" __________________________________________________________");
            Console.WriteLine(" | Hello:\t[" + username + "]");
            Console.WriteLine(" |---------------------------------------------------------");
            Console.WriteLine($" | {storeName} |");
            Console.WriteLine(" |---------------------------------------------------------");
        }
    }
}
