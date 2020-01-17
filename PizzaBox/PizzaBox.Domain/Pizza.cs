using System;
using System.Collections.Generic;
using System.Threading;

namespace PizzaBox.Domain
{
    public class Pizza
    {
        /// <summary>
        /// Size of pizza, choice by customer with properties
        /// </summary>
        /// 
        public PizzaSize pizzaSize { get; set; }
        public enum PizzaSize
        {
            twelveInch, fifteenInch, twentyInch, none,
        }

        /// <summary>
        /// Toppings choice given to customer using list to store
        /// up to 5 choices
        /// </summary>
        public List<Toppings> toppings;
       public enum Toppings
        {
            sauce, cheese, pepperoni, sausage, pineapple,
        }

        /// <summary>
        /// Crust choice will be a multiplicative addition based on size of pizza.
        /// </summary>
        public Crust crust;
        public enum Crust
        {
            deepdish, thin, cheesefilled,
        }



        /// <summary>
        ///  Basic Pizza choice has no pizza with default pizza
        ///  constructor.
        /// </summary>
        public Pizza()
        {
            pizzaSize = PizzaSize.twelveInch;
            crust = Crust.thin;
            defaultToppings();
        }

        /// <summary>
        /// Pizza requires at least cheese and pepperoni
        /// </summary>
        private void defaultToppings()
        {
            toppings = new List<Toppings>();
            toppings.Add(Toppings.cheese);
            toppings.Add(Toppings.sauce);
        }


        /// <summary>
        /// Add more toppings, limited to no more than 5.
        /// </summary>
        /// <param name="top"></param>
        public void addToppings(Toppings top)
        {
            if (toppings.Count >= 5)
            {
                Console.WriteLine("Topping Limit is reached");
            }
            else
            {
                toppings.Add(top);
            }
        }

        /// <summary>
        /// return the toppings in a string list
        /// </summary>
        /// <returns></returns>
        public List<string> getChosenToppings()
        {
            List<string> strTops= new List<string>();
            foreach (Toppings top in toppings)
            {
                string strTop = "";
                if(top == Toppings.cheese)
                {
                    strTop = "cheese";
                }
                if (top == Toppings.pepperoni)
                {
                    strTop = "pepperoni";
                }
                if (top == Toppings.pineapple)
                {
                    strTop = "pineapple";
                }
                if (top == Toppings.sausage)
                {
                    strTop = "sausage";
                }
                if (top == Toppings.sauce)
                {
                    strTop = "sauce";
                }
                strTops.Add(strTop);
            }
            return strTops;
        }


        /// <summary>
        /// Customer chooses their crust
        /// </summary>
        /// <param name="c"></param>
        public void chooseCrust(Crust c)
        {
            crust = c;
        }

        public string getSizeChoice()
        {
            if(pizzaSize == PizzaSize.twelveInch)
            {
                return "12 inch";
            }
            else if (pizzaSize == PizzaSize.fifteenInch)
            {
                return "15 inch";
            }
            else if (pizzaSize == PizzaSize.twentyInch)
            {
                return "20 inch";
            }
            return "";
        }


        /// <summary>
        /// Retun the type of crust chosen
        /// </summary>
        /// <returns></returns>
        public string getCrustChoice()
        {
            if (crust == Crust.thin)
            {
                return "thin";
            }
            else if (crust == Crust.deepdish)
            {
                return "deep dish";
            }
            else if (crust == Crust.cheesefilled)
            {
                return "cheesy";
            }
            return "";
        }


        /// <summary>
        /// returns total price of pizza ordered.
        /// </summary>
        /// <returns></returns>
        public double getPriceOfPizza()
        {
            double ToppingsPrice = 0.0;
            double CrustMultiplier;
            double pizzaSizeCost = 0.0;

            // Chosen Size
            PizzaSize size = pizzaSize;
            switch (size)
            {
                case PizzaSize.twelveInch:
                    pizzaSizeCost = 5.0;
                    break;
                case PizzaSize.fifteenInch:
                    pizzaSizeCost = 8.0;
                    break;
                case PizzaSize.twentyInch:
                    pizzaSizeCost = 11.0;
                    break;
                default:
                    Console.WriteLine("no pizza size chosen.");
                    Thread.Sleep(3000);
                    break;
            }

            // Chosen crust
            Crust crust = this.crust;
            switch (crust)
            {
                case Crust.cheesefilled:
                    CrustMultiplier = 1.5;
                    break;
                case Crust.deepdish:
                    CrustMultiplier = 1.3;
                    break;
                case Crust.thin:
                    CrustMultiplier = 1.1;
                    break;
                default:
                    Console.WriteLine("No crust was chosen.");
                    CrustMultiplier = 1.0;
                    Thread.Sleep(3000);
                    break;
            }


            // Chosen Toppings
            if (toppings.Contains(Toppings.cheese))
            {
                ToppingsPrice += 1.50;
            }
            if (toppings.Contains(Toppings.sauce))
            {
                ToppingsPrice += 1.25;
            }
            if (toppings.Contains(Toppings.pepperoni))
            {
                ToppingsPrice += 1.60;
            }
            if (toppings.Contains(Toppings.sausage))
            {
                ToppingsPrice += 1.70;
            }
            if (toppings.Contains(Toppings.pineapple))
            {
                ToppingsPrice += 1.75;
            }


            // return total cost of pizza
            return pizzaSizeCost * CrustMultiplier + ToppingsPrice;

        }

    }
}
