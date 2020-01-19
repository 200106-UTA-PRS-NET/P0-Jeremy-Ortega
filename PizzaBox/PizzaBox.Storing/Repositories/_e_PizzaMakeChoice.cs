﻿using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    public class _e_PizzaMakeChoice
    {
        _f_PizzaSizeChoice PSC;
        ZZ_PizzaSizes PPS;
        ZZ_PrintLoggedInHeader PH;
        CheckOut CO;


        public _e_PizzaMakeChoice()
        {
            PSC = new _f_PizzaSizeChoice();
            PPS = new ZZ_PizzaSizes();
            PH = new ZZ_PrintLoggedInHeader();
            CO = new CheckOut();
        }

        /// <summary>
        /// The main logic for Ordering a pizza type
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="CurOrd"></param>
        public void pizzaMakerChoice(string username, StoreRepo stores, int locationChoice, CurrentOrder CurOrd, OrderHistory LocationOrderHistory)
        {

            int presetPizzaOptional = -1;
            while (presetPizzaOptional != 0)
            {
                PH.printStoreHeaderLoggedIn(username, stores, locationChoice);
                Console.WriteLine(" |  :: Choose Pizza Type ::");
                Console.WriteLine(" | 1. : Hawaiian");
                Console.WriteLine(" | 2. : Meat Lovers");
                Console.WriteLine(" | 3. : Pepperoni");
                Console.WriteLine(" | 4. : [MAKE YOUR OWN]");
                Console.WriteLine(" | 0. : return to previous page...");
                Console.WriteLine(" |_________________________________________________________");

                if (!int.TryParse(Console.ReadLine(), out presetPizzaOptional)) // try to read int choice
                {
                    Console.WriteLine("Not an option");
                    presetPizzaOptional = -1;
                    continue;
                }
                if (presetPizzaOptional == 4)
                {
                    PPS.printPizzaSizeChoice(username, stores, locationChoice, "[CUSTOM PIZZA]");
                }

                // Customer chose Hawaiian preset pizza.
                else if (presetPizzaOptional == 1)
                {
                    PPS.printPizzaSizeChoice(username, stores, locationChoice, "Hawaiian Pizza");
                    Pizza HawaiiPizza = new Pizza(); // Comes with sauce and Cheese
                    HawaiiPizza.addToppings(Pizza.Toppings.pineapple);
                    HawaiiPizza.chooseCrust(Pizza.Crust.deepdish);
                    PSC.presetPizzaSizeChoice(username, stores, locationChoice, HawaiiPizza, CurOrd);
                }
                // Cx chose Meat Lovers
                else if (presetPizzaOptional == 2)
                {
                    PPS.printPizzaSizeChoice(username, stores, locationChoice, "Meat Lovers");
                    Pizza MeatLovers = new Pizza(); // Comes with sauce and Cheese
                    MeatLovers.addToppings(Pizza.Toppings.pepperoni);
                    MeatLovers.addToppings(Pizza.Toppings.sausage);
                    MeatLovers.chooseCrust(Pizza.Crust.deepdish);
                    PSC.presetPizzaSizeChoice(username, stores, locationChoice, MeatLovers, CurOrd);
                }
                // Cx chose Pepperoni
                else if (presetPizzaOptional == 3)
                {
                    PPS.printPizzaSizeChoice(username, stores, locationChoice, "Pepperoni");
                    Pizza Pepperoni = new Pizza(); // Comes with sauce and Cheese
                    Pepperoni.addToppings(Pizza.Toppings.pepperoni);
                    Pepperoni.chooseCrust(Pizza.Crust.deepdish);
                    PSC.presetPizzaSizeChoice(username, stores, locationChoice, Pepperoni, CurOrd);
                }

                // execute after choosing a pizza, This acts as a persisting layer to persist to a database hopefully.
                if (presetPizzaOptional >= 1 && presetPizzaOptional <= 4)
                {
                    CO.checkOutProcedure(username, locationChoice, LocationOrderHistory, CurOrd, stores);
                }

            }
        }
    }
}