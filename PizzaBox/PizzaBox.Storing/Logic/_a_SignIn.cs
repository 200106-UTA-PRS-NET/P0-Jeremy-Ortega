using System;
using System.Collections.Generic;
using PizzaBox.Domain;
using System.Text;
using System.Threading;
using PizzaBox.Storing.TestModels;
using System.Text.RegularExpressions;


// TODO 70;


namespace PizzaBox.Storing.Logic
{
    public class _a_SignIn
    {
        _b_LocationOrderHistory LOH;
        public _a_SignIn()
        {
            LOH = new _b_LocationOrderHistory();
        }

        /// <summary>
        /// Get through the sign in process.
        /// </summary>
        //public int SignInToAccount(Dictionary<string, string> UserList, Pizza pizza, StoreRepository stores,
        public int SignInToAccount(
            Abstractions.IRepositoryCustomer<Customer1> repo,
            Abstractions.IRepositoryOrders<Order1> orderRepo,
            Abstractions.IRepositoryPizza<Pizza1> pizzaRepo,
            Abstractions.IRepositoryStore<Store1> storeRepo)
        {   

            int choice = -1;
            while (!(choice >= 1 && choice <= 2))
            {
                Console.Clear();
                Console.WriteLine(" __________________________________");
                Console.WriteLine(" |1\tSign In?");
                Console.WriteLine(" |2\tCreate New Account?");
                Console.WriteLine(" |0\t<Close Program>");
                Console.WriteLine(" |_________________________________");

                choice = IntCheck.IntChecker();
                if(choice == -1){continue;}

                //ask for user name and password of a previously created account 
                if (choice == 1)
                {
                    string name = LoginChecks.LoginUserPrompt.LoginUserPrompter(repo);
                    if (name.Equals("@")) { continue; }
                    LOH.ChooseVewOrdersOrStorePortal(name, repo, orderRepo, pizzaRepo, storeRepo);
                    choice = 0;
                }

                //ask for user to create new acount by giving a email and password 
                else if (choice == 2)
                {
                    LoginChecks.CreateNewUser.CreateNewUserPrompt(repo);
                    choice = -1;
                }


                else if (choice == 0)
                {
                    break;
                }
            }

            Console.WriteLine("Thank you!");
            return choice;
        }
    }
}
