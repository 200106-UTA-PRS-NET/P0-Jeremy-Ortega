using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Storing.Repositories;
using System.Threading;

namespace PizzaBox.Storing.Logic
{
    public class _f_PizzaSizeChoice
    {
        _g_PizzaConfirmationToOrder PCTO;
        ZZ_PrintLoggedInHeader PLH;
        public _f_PizzaSizeChoice()
        {
            PCTO = new _g_PizzaConfirmationToOrder();
            PLH = new ZZ_PrintLoggedInHeader();
        }
        /// <summary>
        /// Add a preset Pizza of specified type
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="PresetPizza"></param>
        /// <param name="CurOrd"></param>
        public void presetPizzaSizeChoice(string username, string storeName, Pizza PresetPizza, CurrentOrder CurOrd, bool custom)
        {
            // Get price of pizza
            int sizeOfPizza = -1;
            while (sizeOfPizza != 0)
            {
                if (!int.TryParse(Console.ReadLine(), out sizeOfPizza)) // try to read int choice
                {
                    Console.WriteLine("Not an option");
                    sizeOfPizza = -1;
                    continue;
                }
                if (sizeOfPizza == 1)
                {
                    PresetPizza.pizzaSize = Pizza.PizzaSize.twelveInch;
                }
                else if (sizeOfPizza == 2)
                {
                    PresetPizza.pizzaSize = Pizza.PizzaSize.fifteenInch;
                }
                else if (sizeOfPizza == 3)
                {
                    PresetPizza.pizzaSize = Pizza.PizzaSize.twentyInch;
                }
                else
                {
                    sizeOfPizza = -1;
                    continue;
                }
                if (custom)
                {
                    // This is the crust option
                    PLH.printStoreHeaderLoggedIn(username, storeName);
                    {
                        int crustCheck = -1;
                        while (crustCheck <1 || crustCheck >3) {
                            Console.WriteLine(" | Pizza Crust Selection.");
                            Console.WriteLine(" |---------------------------------------------------");
                            Console.WriteLine(" | 1. thin");
                            Console.WriteLine(" | 2. deep dish");
                            Console.WriteLine(" | 3. cheese filled");
                            Console.WriteLine(" |___________________________________________________");
                            int crustChoice;
                            if (!int.TryParse(Console.ReadLine(), out crustChoice))
                            {
                                Console.WriteLine("Not an option");
                                Thread.Sleep(1100);
                                crustCheck = -1;
                                continue;
                            }
                            if (crustChoice == 1)
                            {
                                PresetPizza.chooseCrust(Pizza.Crust.thin);
                                crustCheck = 1;
                            }
                            else if (crustChoice == 2)
                            {
                                PresetPizza.chooseCrust(Pizza.Crust.deepdish);
                                crustCheck = 1;
                            }
                            else if (crustChoice == 3)
                            {
                                PresetPizza.chooseCrust(Pizza.Crust.cheesefilled);
                                crustCheck = 1;
                            }
                            else
                            {
                                Console.WriteLine("Not an option");
                                Thread.Sleep(1100);
                            }
                        }
                    }
                        // This is the toppings choice.
                        List<string> toppings = new List<string>();
                    for (int i = 0; i < 5; i++)
                    {
                        PLH.printStoreHeaderLoggedIn(username, storeName);
                        if (toppings.Count == 0)
                        {
                            Console.WriteLine(" | You may choose up to five toppings.. Hit enter after each submission.");
                            Console.WriteLine(" |---------------------------------------------------");
                        }
                        else
                        {
                            Console.Write(" | ");
                        }
                        foreach (var top in toppings)
                        {
                            Console.Write($" <{top}>");
                        }
                        if (toppings.Count > 0) {
                            Console.WriteLine();
                        }
                        Console.WriteLine(" | 1. sauce");
                        Console.WriteLine(" | 2. cheese");
                        Console.WriteLine(" | 3. pepperoni");
                        Console.WriteLine(" | 4. sausage");
                        Console.WriteLine(" | 5. pineapple");
                        Console.WriteLine(" | 0. [COMPLETED TOPPING CHOICE]...");
                        Console.WriteLine(" |______________________________________________________");
                        int toppingChoice;
                        if (!int.TryParse(Console.ReadLine(), out toppingChoice))
                        {
                            Console.WriteLine("Not an option");
                            i--;
                            continue;
                        }
                        if (toppingChoice == 1)
                        {
                            toppings.Add("sauce");
                        }
                        else if (toppingChoice == 2)
                        {
                            toppings.Add("cheese");
                        }
                        else if (toppingChoice == 3)
                        {
                            toppings.Add("pepperoni");
                        }
                        else if (toppingChoice == 4)
                        {
                            toppings.Add("sausage");
                        }
                        else if (toppingChoice == 5)
                        {
                            toppings.Add("pineapple");
                        }
                        else if (toppingChoice == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" Please submit an available choice...");
                            i--;
                        }
                    }
                    foreach (var tops in toppings)
                    {
                        if (tops.Equals("sauce"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.sauce);
                        }
                        if (tops.Equals("cheese"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.cheese);
                        }
                        if (tops.Equals("pepperoni"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.pepperoni);
                        }
                        if (tops.Equals("sausage"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.sausage);
                        }
                        if (tops.Equals("pineapple"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.pineapple);
                        }
                    }
                }

                // if user chooses to confirm then add order.
                if (PCTO.PizzaConfirmToOrder(username, storeName, PresetPizza))
                {
                    double check = 0;
                    foreach (var priceCheck in CurOrd.pizzasInOrder)
                    {
                        check += priceCheck.getPriceOfPizza();
                    }
                    if ((check + PresetPizza.getPriceOfPizza()) > 250)
                    {
                        Console.WriteLine("This pizza will push your maximum order limit.\n " +
                            "Please check out at your earliest convenience. " +
                            "<Press any key> to return to the previous page..");
                        Console.ReadLine();
                        break;
                    }
                    // Add The pizza to the order for this restaurant and user
                    CurOrd.confirmPizzaOrder(PresetPizza, username, storeName);
                    sizeOfPizza = 0;
                }
            }
        }
    }
}
