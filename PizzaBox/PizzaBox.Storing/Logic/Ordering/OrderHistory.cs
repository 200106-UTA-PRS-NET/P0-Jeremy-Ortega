using PizzaBox.Storing.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaBox.Storing.Logic.Ordering
{
    public class OrderHistory
    {
        public static void DisplayOrderHistory(string username,
            Abstractions.IRepositoryCustomer<Customer1> repo,
            Abstractions.IRepositoryPizza<Pizza1> pizzaRepo,
            Abstractions.IRepositoryOrders<Order1> orderRepo
            )
        {

            var customer = repo.ReadInCustomer();
            var order = orderRepo.ReadInOrder();
            var pizza = pizzaRepo.ReadInPizza();


            BitFlagConversion BFC = new BitFlagConversion();
            Console.Clear();
            Console.WriteLine(" ____________________________________________________________________________");
            Console.WriteLine(" | Hello:\t[" + username + "]");
            Console.WriteLine(" |---------------------------------------------------------------------------");
            Console.WriteLine(" | ... Order history ...");

            var Cus = customer.FirstOrDefault(Cx => Cx.Fname.Equals(username));
            var ORD = order.OrderByDescending(o=>o.OrderDate);
            foreach(var Ord in ORD)
            //foreach (var Ord in order.OrderByDescending)
            {
                int inOrder = 0;
                foreach (var pie in pizza)
                {
                    if (Cus.Id == Ord.CustId && pie.OrderId == Ord.OrderId)
                    {
                        if (inOrder != pie.OrderId)
                        {
                            Console.WriteLine(" |---------------------------------------------------------------------------");
                            Console.WriteLine($" | Order: {Ord.OrderId} on Date {Ord.OrderDate}  Total Cost ${Ord.Price}");
                        }
                        Console.Write($" |     ${pie.Price}       :: {pie.Size}inch {pie.Crust} ");
                        char[] tops = BFC.convertIntToFlagArray(pie.Toppings, 5);
                        if (tops[0] == '1')
                        {
                            Console.Write(" <sauce> ");
                        }
                        if (tops[1] == '1')
                        {
                            Console.Write(" <cheese> ");
                        }
                        if (tops[2] == '1')
                        {
                            Console.Write(" <pepperoni> ");
                        }
                        if (tops[3] == '1')
                        {
                            Console.Write(" <sausage> ");
                        }
                        if (tops[4] == '1')
                        {
                            Console.Write(" <pineapple> ");
                        }
                        Console.WriteLine();
                        inOrder = pie.OrderId;
                    }
                }
            }
            Console.WriteLine(" |___________________________________________________________________________");
            Console.WriteLine("...Press Any Key To Continue.");
            Console.ReadLine();
        }
    }
}
