using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using PizzaBox.Storing.TestModels;
using System.Linq;

namespace PizzaBox.Storing.Logic
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
        // public void choosePizzaStoreLocation(string username, StoreRepository stores, OrderHistory OrderHistory)
        public void choosePizzaStoreLocation(string username,
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


                //////
                //var Cus = customer.FirstOrDefault(Cx => Cx.Fname.Equals(username));
                //DateTime dt = DateTime.Now;
                //TimeSpan ts = new TimeSpan();
                //foreach (var Ord in order)
                //{
                //    int inOrder = 0;
                //    foreach (var pie in pizza)
                //    {
                //        if (Cus.Id == Ord.CustId && pie.OrderId == Ord.OrderId)
                //        {
                //            if (inOrder != pie.OrderId)
                //            {
                //                TimeSpan ts2 = (TimeSpan)(dt - Ord.OrderDate);
                //                Console.WriteLine(" |-------------------------------------------------------");
                //                Console.WriteLine($" | {Cus.Fname} {Ord.OrderId} {Ord.OrderDate} {dt}  {ts2}");
                //                if (ts == null || ts2 > ts)
                //                {
                //                    ts = ts2;
                //                }
                //            }
                //            inOrder = pie.OrderId;
                //        }
                //    }
                //}
                //Console.WriteLine($"{ts.TotalMinutes/60}");
                //////


                // returns record of customer where first name matched the user name.
                //var customerID = from CX in customer
                //                 where CX.Fname.Equals(username)
                //                 select CX.Id;
                //var cx = customer.OrderByDescending(Cx => Cx.Fname != null && Cx.Fname == username);
                //var ox = order.OrderByDescending(Ox => Ox.CustId == cx.FirstOrDefault().Id);

                //Console.WriteLine($"{ox.FirstOrDefault().OrderDate.Value.Date}");
                //Console.ReadLine();



                //var CustomerOrders = from OR in order
                //                     where OR.CustId == customerID.

                // read through the list of Pizza parlors available.
                Dictionary<int, int> LocChoice = new Dictionary<int, int>();
                int storeCount = 0;
                foreach (var s in store)
                {
                    //var cx = customer.OrderByDescending(Cx => Cx.Fname != null && Cx.Fname.Equals(username));
                    //////
                    bool visitedStore = false;
                    var Cus = customer.FirstOrDefault(Cx => Cx.Fname.Equals(username));
                    DateTime dt = DateTime.Now;
                    TimeSpan ts = new TimeSpan();
                    foreach (var Ord in order)
                    {
                        if (Cus.Id == Ord.CustId && Ord.StoreId == s.Id)
                        {
                            visitedStore = true;
                            TimeSpan ts2 = (TimeSpan)(dt - Ord.OrderDate);
                            if (ts == null || ts2 > ts)
                            {
                                ts = ts2;
                            }
                        }
                    }
                    if (visitedStore)
                    {
                        double time = ts.TotalMinutes / 60;

                        if (time >= 24)
                        {
                            storeCount++;
                            Console.WriteLine($" |{storeCount}. :  {s.StoreName}");
                            Console.WriteLine($" |        {s.StoreLocation}");
                            Console.WriteLine(" |");
                            LocChoice.Add(storeCount, s.Id);
                        }
                        else
                        {
                            Console.WriteLine($" | Wait 24 hours before ordering from \"{s.StoreName}\" again.");
                            Console.WriteLine($" | \t - You have {Math.Round((24 - time), 2)} hours remaining.");
                        }
                    }
                    else
                    {
                        storeCount++;
                        Console.WriteLine($" |{storeCount}. :  {s.StoreName}");
                        Console.WriteLine($" |        {s.StoreLocation}");
                        Console.WriteLine(" |");
                        LocChoice.Add(storeCount, s.Id);
                    }
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
                if (locationChoice > 0 && locationChoice <= storeCount)
                {
                    // This Object pulls from persisted data from a database on this store's location
                    // pertaining to this Cx
                    // This will need to be picked up from the database.
                    /// OrderHistory orderHistoryOfCurrentLocation = null;
                    // Cx Customers current order selections.  Basically each pizza is a new "order" however
                    // It doesn't get it's persistance until checkout where The entire order gets the same order
                    // ID to resemble a full order consisting of one or many pizzas.

                    var Loc = store.FirstOrDefault(S => S.Id == LocChoice[locationChoice]);

                    // Call Main logic for In Store.
                    SPL.inStoreLogic(username, Loc.StoreName, repo, orderRepo, pizzaRepo, storeRepo);

                    // SPL.inStoreLogic(username, Loc.StoreName, locationChoice, CurOrd, LocationOrderHistory);
                    Console.WriteLine("...In Progress");
                    Thread.Sleep(1500);
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
