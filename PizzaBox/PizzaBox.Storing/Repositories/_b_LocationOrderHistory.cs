using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaBox.Storing.Repositories
{
    class _b_LocationOrderHistory
    {
        _c_ChooseStoreLocation CSL;

        public _b_LocationOrderHistory()
        {
            CSL = new _c_ChooseStoreLocation();
        }


        public void ChooseVewOrdersOrStorePortal(string username, StoreRepo stores, OrderHistory orderHistory, Abstractions.IRepositoryCustomer<Customer1> repo)
        {

            int signedInChoice = 0;
            while (signedInChoice != 3)
            {
                Console.Clear();
                Console.WriteLine(" __________________________________");
                Console.WriteLine(" | Hello:\t[" + username + "]");
                Console.WriteLine(" |---------------------------------");
                Console.WriteLine(" |1. Choose Location");
                Console.WriteLine(" |2. Look at my complete order history. ");
                Console.WriteLine(" |3. sign out");
                Console.WriteLine(" |_________________________________");
                if (!int.TryParse(Console.ReadLine(), out signedInChoice))
                {
                    Console.WriteLine("Not an int");
                    signedInChoice = -1;
                    continue;
                }
                
                //This choice signifies selecting the pizza parlor you wish to engage with 
                if (signedInChoice == 1)
                {
                    CSL.choosePizzaStoreLocation(username, stores, orderHistory);
                }
                // Show all order history
                else if (signedInChoice == 2)
                {
                    if (signedInChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine(" __________________________________________________________");
                        Console.WriteLine(" | Hello:\t[" + username + "]");
                        Console.WriteLine(" |---------------------------------------------------------");
                        Console.WriteLine(" | ... Order history ...");
                        Console.WriteLine(" |_________________________________________________________");
                    }
                    Console.WriteLine("...Still in progress");
                    Thread.Sleep(1100);
                }
                // Sign out
                else if (signedInChoice == 3)
                {
                    Console.WriteLine("Signing Out...");
                    Thread.Sleep(1500);

                }
            }
        }
    }
}
