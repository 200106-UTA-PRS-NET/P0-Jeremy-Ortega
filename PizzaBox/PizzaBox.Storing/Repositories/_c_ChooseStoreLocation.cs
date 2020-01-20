using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaBox.Storing.Repositories
{
    public class _c_ChooseStoreLocation
    {

        _d_StorePortal SPL;

        public _c_ChooseStoreLocation()
        {
            SPL = new _d_StorePortal();
        }

        /// <summary>
        /// Choose Pizza Location
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        public void choosePizzaStoreLocation(string username, StoreRepo stores, OrderHistory OrderHistory)
        {
            int locationChoice = -1;
            while (locationChoice != 0)
            {
                Console.Clear();
                Console.WriteLine(" __________________________________________________________");
                Console.WriteLine(" | Hello:\t[" + username + "]");
                Console.WriteLine(" |---------------------------------------------------------");
                Console.WriteLine(" | Select a Pizza Parlor Location");
                Console.WriteLine(" |_________________________________________________________");
                int storeCount = 1;

                // read through the list of Pizza parlors available.
                foreach (Store storeLoc in stores.currentStores)
                {
                    Console.WriteLine(" |{0}. :  {1}", storeCount, storeLoc.storeName);
                    Console.WriteLine(" |        {0}", storeLoc.location);
                    Console.WriteLine(" |");
                    storeCount++;
                }
                Console.WriteLine(" |0. : Return to previous page.");
                Console.WriteLine(" |_________________________________________________________");
                if (!int.TryParse(Console.ReadLine(), out locationChoice)) // try to read int choice
                {
                    Console.WriteLine("Not an int");
                    locationChoice = -1;
                    continue;
                }

                // choose location and bring up data about that location
                if (locationChoice > 0 && locationChoice <= stores.currentStores.Count)
                {
                    // This Object pulls from persisted data from a database on this store's location
                    // pertaining to this Cx
                    // This will need to be picked up from the database.
                    OrderHistory orderHistoryOfCurrentLocation = null;
                    // Cx Customers current order selections.  Basically each pizza is a new "order" however
                    // It doesn't get it's persistance until checkout where The entire order gets the same order
                    // ID to resemble a full order consisting of one or many pizzas.
                    OrderHistory LocationOrderHistory = new OrderHistory();
                    CurrentOrder CurOrd = new CurrentOrder();

                    // Call Main logic for In Store.
                    SPL.inStoreLogic(username, stores, locationChoice, CurOrd, LocationOrderHistory);
                }

                if (locationChoice == 0)
                {
                    Console.WriteLine("returning to the previous page...");
                    Thread.Sleep(700);
                    break;
                }
            }
        }
    }
}
