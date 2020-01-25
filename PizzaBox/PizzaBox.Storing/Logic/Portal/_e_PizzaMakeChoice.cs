using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Storing.Logic.Ordering;
using System.Threading;


namespace PizzaBox.Storing.Logic.Portal
{
    public class _e_PizzaMakeChoice
    {
       // _f_PizzaSizeChoice PSC;
       // ZZ_PizzaSizes PPS;


        public _e_PizzaMakeChoice()
        {
           // PSC = new _f_PizzaSizeChoice();
           // PPS = new ZZ_PizzaSizes();
        }

        /// <summary>
        /// The main logic for Ordering a pizza type
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="CurOrd"></param>
       // public void pizzaMakerChoice(string username, StoreRepository stores, int locationChoice, CurrentOrder CurOrd, OrderHistory LocationOrderHistory)
        public static void pizzaMakerChoice(string username, string storeName, CurrentOrder CurOrd)
        {
            int presetPizzaOptional = -1;
            while (presetPizzaOptional != 0)
            {
                ZZ_PrintLoggedInHeader.printStoreHeaderLoggedIn(username, storeName);
                Console.WriteLine(" |  :: Choose Pizza Type ::");
                Console.WriteLine(" | 1. : Hawaiian");
                Console.WriteLine(" | 2. : Meat Lovers");
                Console.WriteLine(" | 3. : Pepperoni");
                Console.WriteLine(" | 4. : [MAKE YOUR OWN]");
                Console.WriteLine(" | 0. : return to previous page...");
                Console.WriteLine(" |_________________________________________________________");

                presetPizzaOptional = IntCheck.IntChecker();
                if (presetPizzaOptional == -1) { continue; }

                if (presetPizzaOptional == 4)
                {
                    ZZ_PizzaSizes.printPizzaSizeChoice(username, storeName, "Custom Pizza");
                    Pizza CustomPizza = new Pizza(); // Comes with sauce and Cheese
                    _f_PizzaSizeChoice .presetPizzaSizeChoice(username, storeName, CustomPizza, CurOrd, true);
                }

                // Customer chose Hawaiian preset pizza.
                else if (presetPizzaOptional == 1)
                {
                    ZZ_PizzaSizes.printPizzaSizeChoice(username, storeName, "Hawaiian Pizza");
                    Pizza HawaiiPizza = new Pizza(); // Comes with sauce and Cheese
                    HawaiiPizza.setDefaultToppings();
                    HawaiiPizza.addToppings(Pizza.Toppings.pineapple);
                    HawaiiPizza.chooseCrust(Pizza.Crust.deepdish);
                    _f_PizzaSizeChoice.presetPizzaSizeChoice(username, storeName, HawaiiPizza, CurOrd, false);
                }
                // Cx chose Meat Lovers
                else if (presetPizzaOptional == 2)
                {
                    ZZ_PizzaSizes.printPizzaSizeChoice(username, storeName, "Meat Lovers");
                    Pizza MeatLovers = new Pizza(); // Comes with sauce and Cheese
                    MeatLovers.setDefaultToppings();
                    MeatLovers.addToppings(Pizza.Toppings.pepperoni);
                    MeatLovers.addToppings(Pizza.Toppings.sausage);
                    MeatLovers.chooseCrust(Pizza.Crust.deepdish);
                    _f_PizzaSizeChoice.presetPizzaSizeChoice(username, storeName, MeatLovers, CurOrd, false);
                }
                // Cx chose Pepperoni
                else if (presetPizzaOptional == 3)
                {
                    ZZ_PizzaSizes.printPizzaSizeChoice(username, storeName, "Pepperoni");
                    Pizza Pepperoni = new Pizza(); // Comes with sauce and Cheese
                    Pepperoni.setDefaultToppings();
                    Pepperoni.addToppings(Pizza.Toppings.pepperoni);
                    Pepperoni.chooseCrust(Pizza.Crust.deepdish);
                    _f_PizzaSizeChoice.presetPizzaSizeChoice(username, storeName, Pepperoni, CurOrd, false);
                }
            }
        }
    }
}
