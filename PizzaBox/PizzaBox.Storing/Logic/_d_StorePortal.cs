﻿using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using PizzaBox.Storing.TestModels;
using System.Linq;

namespace PizzaBox.Storing.Logic
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
        
        public void inStoreLogic(string username, string storeName,
            Abstractions.IRepositoryCustomer<Customer1> repo,
            Abstractions.IRepositoryOrders<Order1> orderRepo,
            Abstractions.IRepositoryPizza<Pizza1> pizzaRepo,
            Abstractions.IRepositoryStore<Store1> storeRepo)
        {

            var customer = repo.ReadInCustomer();
            var order = orderRepo.ReadInOrder();
            var pizza = pizzaRepo.ReadInPizza();
            var store = storeRepo.ReadInStore();

            // Create new order object to temporarily store the order before confirming it.
            CurrentOrder curOrder = new CurrentOrder();
            int inStoreChoice = -1;
            while (inStoreChoice != 0)
            {
                PLIH.printStoreHeaderLoggedIn(username, storeName);
                Console.WriteLine(" |---------------------------------------------------------");
                Console.WriteLine(" | 1. : Order a Pizza.");
                Console.WriteLine(" | 2. : Preview Your Current Order.");
                Console.WriteLine(" | 3. : [ADMIN] Preview All Orders at this Location.");
                Console.WriteLine(" | 0. : Return to Restaurant choice.");
                Console.WriteLine(" |_________________________________________________________");

                inStoreChoice = IntCheck.IntChecker();
                if (inStoreChoice == -1) { continue; }

                // Pizza Size
                if (inStoreChoice == 1)
                {
                    PMC.pizzaMakerChoice(username, storeName, curOrder);
                }
   
                if (inStoreChoice == 2)
                {
                    if (curOrder.pizzasInOrder.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("No pizza's ordered yet!");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        inStoreChoice = 0; // trying to for customer back to store choice after checking out a pizza.
                        CxOrdersAtLocation Cx = new CxOrdersAtLocation();
                        // give option for persistance 
                        int num = Cx.printCxPrevOrdersAtCurrLoc(username, storeName, curOrder);  /////////
                        if (num == 1) // try to read int choice
                        {
                            // Randomize and create new order.
                            Random random = new Random();
                            int OrderID = random.Next(1000000000, 2000000000);
                            var cx = customer.FirstOrDefault(Cx => Cx.Fname != null && Cx.Fname.Equals(username));
                            var stor = store.FirstOrDefault(S => S.StoreName.Equals(storeName));

                            // Tally the complete order first to get the total.
                            double total = 0;
                            foreach(var pi in curOrder.pizzasInOrder)
                            {
                                total += pi.getPriceOfPizza();
                            }

                            // Create new order and submit.
                            Order1 Or = new Order1()
                            {
                                CustId = cx.Id,
                                OrderId = OrderID,
                                StoreId = stor.Id,
                                Price = (decimal)total
                            };
                            orderRepo.CreateOrder(Or);

                            foreach (var pie in curOrder.pizzasInOrder)
                            {
                                char[] tops = new char[5];
                                var top = pie.getChosenToppings();

                                if (top.Contains("sauce"))
                                {
                                    tops[0] = '1';
                                }
                                else
                                {
                                    tops[0] = '0';
                                }
                                if (top.Contains("cheese"))
                                {
                                    tops[1] = '1';
                                }
                                else
                                {
                                    tops[1] = '0';
                                }
                                if (top.Contains("pepperoni"))
                                {
                                    tops[2] = '1';
                                }
                                else
                                {
                                    tops[2] = '0';
                                }
                                if (top.Contains("sausage"))
                                {
                                    tops[3] = '1';
                                }
                                else
                                {
                                    tops[3] = '0';
                                }
                                if (top.Contains("pineapple"))
                                {
                                    tops[4] = '1';
                                }
                                else
                                {
                                    tops[4] = '0';
                                }

                                // Convert toppings int a singular decimal representing a bit flag 
                                int topSet = BitFlagConversion.convertFlagArrayToInt(tops);
                                Pizza1 Cu = new Pizza1()
                                {
                                    PizzaId = random.Next(1000000000, 2000000000),
                                    Toppings = topSet,
                                    Crust = pie.getCrustChoice(),
                                    Size = pie.getSizeChoice(),
                                    OrderId = OrderID,
                                    Price = (decimal)pie.getPriceOfPizza()
                                };
                                pizzaRepo.CreatePizza(Cu);
                            }
                        }
                    }
                }
                // Look at previous order history at current location
                if (inStoreChoice == 3)
                {
                    AllRestaurantOrders(orderRepo, storeRepo, username, storeName);
                }

                if (inStoreChoice == 0)
                {
                    Console.WriteLine("returning to the previous page...");
                    Thread.Sleep(700);
                    break;
                }
            }
        }


        // can be called by employee
        public void AllRestaurantOrders(Abstractions.IRepositoryOrders<Order1> orderRepo, Abstractions.IRepositoryStore<Store1> storeRepo, string username, string storeName)
        {
            var store = storeRepo.ReadInStore();
            var order = orderRepo.ReadInOrder();
            Console.Clear();
            Console.WriteLine("Please Enter The Store Employee Passcode.");
            string passcode = Console.ReadLine();
            if (passcode != "cheesy")
            {
                Console.WriteLine("Incorrect Passcode. Press any key to continue.");
                Console.ReadLine();
            }
            else
            {
                // StoresOrdHist.orders = stores.currentStores[locationChoice - 1].userHistoryFromThisStore(username);
                PLIH.printStoreHeaderLoggedIn(username, storeName);
                Console.WriteLine(" | :: All Restaurant Orders::");
                Console.WriteLine(" |---------------------------------------------------------");
                Console.WriteLine(" | Order ID  |  Cx ID  |  Price  |  Date  |");
                Console.WriteLine(" |---------------------------------------------------------");
                var stor = store.FirstOrDefault(S => S.StoreName.Equals(storeName));
                foreach (var o in order)
                {
                    if (o.StoreId == stor.Id)
                    {
                        Console.WriteLine($" | {o.OrderId} {o.CustId} {o.Price}\t{o.OrderDate}");
                    }
                }
                Console.WriteLine(" |_________________________________________________________");
                Console.ReadLine();
            }
        }

    }
}
