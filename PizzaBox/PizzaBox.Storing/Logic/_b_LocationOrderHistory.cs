using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using PizzaBox.Storing.TestModels;
using System.Linq;

namespace PizzaBox.Storing.Logic
{
    class _b_LocationOrderHistory
    {
        _c_ChooseStoreLocation CSL;

        public _b_LocationOrderHistory()
        {
            CSL = new _c_ChooseStoreLocation();
        }


        //public void ChooseVewOrdersOrStorePortal(string username, StoreRepository stores, OrderHistory orderHistory, 
        public void ChooseVewOrdersOrStorePortal(string username, 
            Abstractions.IRepositoryCustomer<Customer1> repo,
            Abstractions.IRepositoryOrders<Order1> orderRepo,
            Abstractions.IRepositoryPizza<Pizza1> pizzaRepo,
            Abstractions.IRepositoryStore<Store1> storeRepo)
        {
            var customer = repo.ReadInCustomer();
            var order = orderRepo.ReadInOrder();
            var pizza = pizzaRepo.ReadInPizza();
            var store = storeRepo.ReadInStore();




            int signedInChoice = 0;
            while (signedInChoice != 3)
            {
                Console.Clear();
                Console.WriteLine(" __________________________________");
                Console.WriteLine(" | Hello:\t[" + username + "]");
                Console.WriteLine(" |---------------------------------");
                Console.WriteLine(" |1. Choose Location");
                Console.WriteLine(" |2. Look at my complete order history Of All Pizza Restaurants. ");
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
                    //CSL.choosePizzaStoreLocation(username, stores, orderHistory);
                    Console.WriteLine("Working on it");
                    CSL.choosePizzaStoreLocation(username, repo, orderRepo, pizzaRepo, storeRepo);
                }
                // Show all order history
                else if (signedInChoice == 2)
                {
                    BitFlagConversion BFC = new BitFlagConversion();
                    Console.Clear();
                    Console.WriteLine(" __________________________________________________________");
                    Console.WriteLine(" | Hello:\t[" + username + "]");
                    Console.WriteLine(" |---------------------------------------------------------");
                    Console.WriteLine(" | ... Order history ...");

                    var Cus = customer.FirstOrDefault(Cx => Cx.Fname.Equals(username));
                    foreach (var Ord in order)
                    {
                        int inOrder = 0;
                        foreach (var pie in pizza)
                        {
                            if (Cus.Id == Ord.CustId && pie.OrderId == Ord.OrderId)
                            {
                                if (inOrder != pie.OrderId) {
                                    Console.WriteLine(" |-------------------------------------------------------");
                                    Console.WriteLine($" | Order: {Ord.OrderId} on Date {Ord.OrderDate}  Total Cost ${Ord.Price}");
                                }
                                Console.Write($" |    - {pie.Size} {pie.Crust} ");
                                char[] tops = BFC.convertIntToFlagArray(pie.Toppings, 5);
                                if(tops[0] == '1')
                                {
                                    Console.Write(" <sauce> ");
                                }
                                if(tops[1] == '1')
                                {
                                    Console.Write(" <cheese> ");
                                }
                                if(tops[2] == '1')
                                {
                                    Console.Write(" <pepperoni> ");
                                }
                                if(tops[3] == '1')
                                {
                                    Console.Write(" <sausage> ");
                                }
                                if(tops[4] == '4')
                                {
                                    Console.Write(" <pineapple> ");
                                }
                                Console.WriteLine($" \t\t<${pie.Price}>");
                                inOrder = pie.OrderId;
                            }
                        }
                    }
                    Console.WriteLine(" |_________________________________________________________");

                    Console.WriteLine("...Press Any Key To Continue.");
                    Console.ReadLine();
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
