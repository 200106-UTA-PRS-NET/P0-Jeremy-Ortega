using System;
using PizzaBox.Storing.TestModels;

namespace PizzaBox.Storing.Logic.Portal
{
    public class _a_SignIn
    {
        public _a_SignIn()
        {
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

            int choice = 1;
            while (choice != 0)
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
                    string name = Login.LoginUserPrompt.LoginUserPrompter(repo);
                    if (!name.Equals("@"))
                    {
                        _b_LocationOrderHistory.ChooseVewOrdersOrStorePortal(name, repo, orderRepo, pizzaRepo, storeRepo);
                    }
                }

                //ask for user to create new acount by giving a email and password 
                else if (choice == 2)
                {
                    Login.CreateNewUser.CreateNewUserPrompt(repo);
                }
            }

            Console.WriteLine("Thank you!");
            return choice;
        }
    }
}
