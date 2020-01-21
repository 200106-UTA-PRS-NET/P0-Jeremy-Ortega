using System;
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
        // public void inStoreLogic(string username, StoreRepository stores, int locationChoice, CurrentOrder CurOrd, OrderHistory LocationOrderHistory)
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

            CurrentOrder curOrder = new CurrentOrder();
            int inStoreChoice = -1;
            while (inStoreChoice != 0)
            {
                PLIH.printStoreHeaderLoggedIn(username, storeName);
                Console.WriteLine(" |---------------------------------------------------------");
                Console.WriteLine(" | 1. : Order a Pizza.");
                Console.WriteLine(" | 2. : Preview Your Current Order.");
                Console.WriteLine(" | 3. : View your complete history of orders at this location.");    
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
                   PMC.pizzaMakerChoice(username, storeName, curOrder, repo, orderRepo, pizzaRepo, storeRepo);
                }

                
                if (inStoreChoice == 2)
                {
                    if (curOrder.pizzasInOrder.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("No pizza's ordered yet!");
                        Console.ReadLine();
                    }
                    else
                    {
                        CxOrdersAtLocation Cx = new CxOrdersAtLocation();
                        // give option for persistance 
                        int num = Cx.printCxPrevOrdersAtCurrLoc(username, storeName, curOrder);  /////////
                        if (num == 1) // try to read int choice
                        {
                            // Randomize and create new order.
                            Random random = new Random();
                            int OrderID = random.Next(1000000000, 2000000000);
                            var cx = customer.FirstOrDefault(Cx => Cx.Email != null && Cx.Email.Equals(username));
                            var stor = store.FirstOrDefault(S => S.StoreName.Equals(storeName));
                            Order1 Or = new Order1(){
                                CustId=cx.Id,
                                OrderId = OrderID,
                                StoreId=stor.Id
                            };
                            orderRepo.CreateOrder(Or);


                            if (num == 1)
                            {
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


                                    int topSet = BitFlagConversion.convertFlagArrayToInt(tops);
                                    Pizza1 Cu = new Pizza1()
                                    {
                                        Toppings = topSet,
                                        Crust = pie.getCrustChoice(),
                                        Size = pie.getSizeChoice(),
                                        OrderId = OrderID
                                    };

                                    pizzaRepo.CreatePizza(Cu);
                                }
                            }
                        }
                    }
                }
                // Look at previous order history at current location
                if (inStoreChoice == 3)
                {
                    OrderHistory StoresOrdHist = null;
                  //  StoresOrdHist.orders = stores.currentStores[locationChoice - 1].userHistoryFromThisStore(username);
                  //  PLIH.printStoreHeaderLoggedIn(username, stores, locationChoice);
                    Console.WriteLine(" |_________________________________________________________");
                    Console.WriteLine(" | ::Orders::");
                  //  StoresOrdHist.orders = stores.currentStores[locationChoice - 1].userHistoryFromThisStore(username);
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
