using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaBox.Storing.Repositories
{
    public class _d_StorePortal
    {

        ZZ_PrintLoggedInHeader PLIH;
        _e_PizzaMakeChoice PMC;
        public _d_StorePortal()
        {
            PLIH = new ZZ_PrintLoggedInHeader();
            PMC = new _e_PizzaMakeChoice();
        }

        /// <summary>
        /// Main Logic for initial choices a Cx can make when they login to the store
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="CurOrd"></param>
        /// <param name="LocationOrderHistory"></param>
        public void inStoreLogic(string username, StoreRepo stores, int locationChoice, CurrentOrder CurOrd, OrderHistory LocationOrderHistory)
        {
            int inStoreChoice = -1;
            while (inStoreChoice != 0)
            {
                PLIH.printStoreHeaderLoggedIn(username, stores, locationChoice);
                Console.WriteLine(" |---------------------------------------------------------");
                Console.WriteLine(" |...TODO: Add Order History / \"Your current order is empty...\"");
                Console.WriteLine(" |---------------------------------------------------------");
                Console.WriteLine(" | 1. : Order a Pizza.");
                Console.WriteLine(" | 3. : Preview your history of orders at this location.");
                Console.WriteLine(" | 0. : Return to Restaurant choice.");
                Console.WriteLine(" |_________________________________________________________");

                if (!int.TryParse(Console.ReadLine(), out inStoreChoice)) // try to read int choice
                {
                    Console.WriteLine("Not an option");
                    inStoreChoice = -1;
                    continue;
                }

                // Pizza Size
                if (inStoreChoice == 1)
                {
                    PMC.pizzaMakerChoice(username, stores, locationChoice, CurOrd, LocationOrderHistory);
                }

                // This would be the second store
                if (inStoreChoice == 2)
                {
                    if (CurOrd.pizzasInOrder.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("No pizza's ordered yet!");
                        Console.ReadLine();
                    }
                }
                // Look at previous order history at current location
                if (inStoreChoice == 3)
                {
                    OrderHistory StoresOrdHist = null;
                    StoresOrdHist.orders = stores.currentStores[locationChoice - 1].userHistoryFromThisStore(username);
                    PLIH.printStoreHeaderLoggedIn(username, stores, locationChoice);
                    Console.WriteLine(" |_________________________________________________________");
                    Console.WriteLine(" | ::Orders::");
                    StoresOrdHist.orders = stores.currentStores[locationChoice - 1].userHistoryFromThisStore(username);
                    Console.WriteLine(" |_________________________________________________________");
                    Console.ReadLine();
                }

                if (inStoreChoice == 0)
                {
                    Console.WriteLine("returning to the previous page...");
                    Thread.Sleep(700);
                    break;
                }
            }
        }
    }
}
