using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using PizzaBox.Storing.TestModels;
using System.Linq;
using PizzaBox.Storing.Logic.Portal;

namespace PizzaBox.Storing.Logic.Portal
{
    class _b_LocationOrderHistory
    {

        public _b_LocationOrderHistory()
        {
        }


        //public void ChooseVewOrdersOrStorePortal(string username, StoreRepository stores, OrderHistory orderHistory, 
        public static void ChooseVewOrdersOrStorePortal(string username, 
            Abstractions.IRepositoryCustomer<Customer1> repo,
            Abstractions.IRepositoryOrders<Order1> orderRepo,
            Abstractions.IRepositoryPizza<Pizza1> pizzaRepo,
            Abstractions.IRepositoryStore<Store1> storeRepo)
        {

            int signedInChoice = 0;
            while (signedInChoice != 3)
            {
                HeaderPortal.printHeaderPortal(username);
                Console.WriteLine(" |1. Choose Location");
                Console.WriteLine(" |2. My complete order history");
                Console.WriteLine(" |3. sign out");
                Console.WriteLine(" |________________________________________________________________");

                signedInChoice = IntCheck.IntChecker();
                if (signedInChoice == -1) { continue; }

                //This choice signifies selecting the pizza parlor you wish to engage with 
                if (signedInChoice == 1)
                {
                    //CSL.choosePizzaStoreLocation(username, stores, orderHistory);
                    Console.WriteLine("Working on it");
                    _c_ChooseStoreLocation.choosePizzaStoreLocation(username, repo, orderRepo, pizzaRepo, storeRepo);
                }
                // Show all order history
                else if (signedInChoice == 2)
                {
                    Ordering.OrderHistory.DisplayOrderHistory(username,repo, pizzaRepo, orderRepo);
                }
                // Sign out
                else if (signedInChoice == 3)
                {
                    Console.WriteLine("Signing Out...");
                    Thread.Sleep(500);
                }
            }
        }
    }
}
