using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    public class ZZ_PrintLoggedInHeader
    {

        /// <summary>
        /// Print a common reocurring theme
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        public void printStoreHeaderLoggedIn(string username, StoreRepo stores, int locationChoice)
        {
            Console.Clear();
            Console.WriteLine(" __________________________________________________________");
            Console.WriteLine(" | Hello:\t[" + username + "]");
            Console.WriteLine(" |---------------------------------------------------------");
            Console.WriteLine(" | {0} |", stores.currentStores[locationChoice - 1].storeName);
            Console.WriteLine(" |---------------------------------------------------------");
        }
    }
}
