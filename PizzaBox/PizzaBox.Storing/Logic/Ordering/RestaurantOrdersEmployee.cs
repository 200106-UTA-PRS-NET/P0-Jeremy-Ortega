using PizzaBox.Storing.TestModels;
using System;
using System.Linq;
using PizzaBox.Storing.Logic.Portal;


namespace PizzaBox.Storing.Logic.Ordering
{
    class RestaurantOrdersEmployee
    {
        public static void AllRestaurantOrders(Abstractions.IRepositoryOrders<Order1> orderRepo, Abstractions.IRepositoryStore<Store1> storeRepo, string username, string storeName)
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
                ZZ_PrintLoggedInHeader.printStoreHeaderLoggedIn(username, storeName);
                Console.WriteLine(" | :: All Restaurant Orders::");
                Console.WriteLine(" |---------------------------------------------------------");
                Console.WriteLine(" | Order ID  |  Cx ID  |  Price  |  Date  |");
                Console.WriteLine(" |---------------------------------------------------------");
                var stor = store.FirstOrDefault(S => S.StoreName.Equals(storeName));
                var ORD = order.OrderByDescending(o=>o.OrderDate);
                foreach (var o in ORD)
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
