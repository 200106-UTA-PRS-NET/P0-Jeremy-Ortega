using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Storing.Logic
{
    public class _g_PizzaConfirmationToOrder
    {
        ZZ_PrintLoggedInHeader PH;
        public _g_PizzaConfirmationToOrder()
        {
            PH = new ZZ_PrintLoggedInHeader();
        }
        /// <summary>
        /// Allow the user an opportunity to back out of a pizza, not the entire order.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="HawaiiPizza"></param>
        /// <returns></returns>
        public bool PizzaConfirmToOrder(string username, StoreRepository stores, int locationChoice, Pizza PizzaChoice)
        {
            Console.WriteLine("CHECK");
            int confirm = -1;
            while (!(confirm >= 1 && confirm <= 2))
            {
                PH.printStoreHeaderLoggedIn(username, stores, locationChoice);
                Console.WriteLine(" | %%% Price of pizza adding to order: ${0} %%%|", PizzaChoice.getPriceOfPizza());
                Console.WriteLine(" |------------------------------");
                Console.WriteLine(" |1. : Confirm Pizza order");
                Console.WriteLine(" |2. : return to previous menu...");
                Console.WriteLine(" |_________________________________________________________");
                if (!int.TryParse(Console.ReadLine(), out confirm))
                {
                    Console.WriteLine("Not an option");
                    confirm = -1;
                    continue;
                }
                if (confirm == 1)
                {
                    return true;
                }
                if (confirm == 2)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Not an option");
                    confirm = -1;
                }
            }
            return false;
        }
    }
}
