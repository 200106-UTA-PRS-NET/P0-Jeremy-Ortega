using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using PizzaBox.Storing.TestModels;
using System.Linq;

namespace PizzaBox.Storing.Logic.Portal
{
    public class _c_ChooseStoreLocation
    {

        public _c_ChooseStoreLocation()
        {
        }

        /// <summary>
        /// Choose Pizza Location
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        public static void choosePizzaStoreLocation(string username,
            Abstractions.IRepositoryCustomer<Customer1> repo,
            Abstractions.IRepositoryOrders<Order1> orderRepo,
            Abstractions.IRepositoryPizza<Pizza1> pizzaRepo,
            Abstractions.IRepositoryStore<Store1> storeRepo)
        {
            var customer = repo.ReadInCustomer();
            var order = orderRepo.ReadInOrder();
            var pizza = pizzaRepo.ReadInPizza();
            var store = storeRepo.ReadInStore();

            int locationChoice = -1;
            while (locationChoice != 0)
            {
                Console.Clear();
                Console.WriteLine(" __________________________________________________________");
                Console.WriteLine(" | Hello:\t[" + username + "]");
                Console.WriteLine(" |---------------------------------------------------------");
                Console.WriteLine(" | Select a Pizza Parlor Location");
                Console.WriteLine(" |_________________________________________________________");

                // read through the list of Pizza parlors available.
                Dictionary<int, int> LocChoice = new Dictionary<int, int>();
                int storeCount = 0;
                foreach (var s in store)
                {

                    //DateTimeLogic.MostRecentOrder.getMostRecentOrder(store, customer, order, username);
                    // var cx = customer.OrderByDescending(Cx => Cx.Fname != null && Cx.Fname.Equals(username));
                    var Cus = customer.FirstOrDefault(Cx => Cx.Fname.Equals(username));

                    DateTime dt = DateTime.Now;
                    double time = 25;
                    double date2 = 25;
                    // For each order go through and check if store id and customer id match
                    foreach (var Ord in order)
                    {
                        if (Cus.Id == Ord.CustId && Ord.StoreId == s.Id)
                        {
                            TimeSpan ts2 = (TimeSpan)(dt - Ord.OrderDate);
                            date2 = ts2.TotalMinutes / 60;
                            if (date2 < time)
                            {
                                time = date2;
                            }
                        }
                    }

                    if (time >= 24)
                    {
                        //Console.WriteLine($"Yes visited and time {time}hrs ago");
                        storeCount++;
                        Console.WriteLine($" |{storeCount}. :  {s.StoreName}");
                        Console.WriteLine($" |        {s.StoreLocation}");
                        Console.WriteLine(" |");
                        LocChoice.Add(storeCount, s.Id);
                    }
                    else
                    {
                        Console.WriteLine($" | Plese wait 24 hours before ordering from \"{s.StoreName}\" again.");
                        Console.WriteLine($" | \t - You have {Math.Round((24 - time), 2)} hours remaining.");
                        Console.WriteLine(" |");
                    }

                }
                Console.WriteLine(" |0. : Return to previous page.");
                Console.WriteLine(" |_________________________________________________________");

                locationChoice = IntCheck.IntChecker();
                if (locationChoice == -1) { continue; }

                // choose location and bring up data about that location
                if (locationChoice > 0 && locationChoice <= storeCount)
                {
                    var Loc = store.FirstOrDefault(S => S.Id == LocChoice[locationChoice]);

                    // Call Main logic for In Store.
                    _d_StorePortal.inStoreLogic(username, Loc.StoreName, repo, orderRepo, pizzaRepo, storeRepo);
                }

                if (locationChoice == 0)
                {
                    Console.WriteLine("returning to the previous page...");
                    Thread.Sleep(500);
                    break;
                }
            }
        }
    }
}
