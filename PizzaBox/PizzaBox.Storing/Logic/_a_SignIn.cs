using System;
using System.Collections.Generic;
using PizzaBox.Domain;
using System.Text;
using System.Threading;
using PizzaBox.Storing.TestModels;


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

            var customers = repo.ReadInCustomer();
            

            int choice = -1;
            while (!(choice >= 1 && choice <= 3))
            {
                Console.Clear();
                Console.WriteLine(" __________________________________");
                Console.WriteLine(" |1\tSign In?");
                Console.WriteLine(" |2\tCreate New Account?");
                Console.WriteLine(" |0\t<Close Program>");
                Console.WriteLine(" |_________________________________");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Not an int");
                    choice = -1;
                    continue;
                }

                //ask for user name and password of a previously created account 
                if (choice == 1)
                {

                    // email
                    Console.Clear();
                    Console.WriteLine(" ---- email ----");
                    string email = Console.ReadLine();

                    // password
                    Console.Clear();
                    Console.WriteLine(" ---- password ----");
                    string password = Console.ReadLine();

                    string name = "";
                    bool correctAuth = false;
                    foreach (var Cx in customers){
                        if (Cx.Username != null && Cx.Username.Equals(email))
                        {
                            if (Cx.UserPass.Equals(password))
                            {
                                name = Cx.Fname;
                                correctAuth = true;
                            }
                        }
                    }
                    if (!correctAuth)
                    {
                        Console.Clear();
                        Console.WriteLine("No User found with that email and password.");
                        Thread.Sleep(1700);
                        continue;
                    }
                    LOH.ChooseVewOrdersOrStorePortal(email, repo, orderRepo, pizzaRepo, storeRepo);
                    choice = 0;
                }

                //ask for user to create new acount by giving a email and password 
                else if (choice == 2)
                {
                    // email - maps to username in the database
                    Console.Clear();
                    Console.WriteLine(" ---- new email ---- ");
                    string email = Console.ReadLine();

                    // password
                    Console.WriteLine("\n ---- create password ----");
                    string password = Console.ReadLine();

                    // First Name
                    Console.WriteLine("\n ---- first name ----");
                    string fname = Console.ReadLine();

                    // Last Name
                    Console.WriteLine("\n ---- last name ----");
                    string lname = Console.ReadLine();

                    // Phone Number
                    Console.WriteLine("\n ---- Phone ----");
                    string phone = Console.ReadLine();

                    bool correctAuth = false;
                    foreach (var Cx in customers)
                    {
                        if (Cx.Username!=null && Cx.Username.Equals(email))
                            if (Cx.UserPass.Equals(password))
                                correctAuth = true;
                    }
                    if (correctAuth)
                    {
                        Console.Clear();
                        Console.WriteLine("Email already in use please sign in or use another email address.");
                        Thread.Sleep(1700);
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine("Created your account! [{0}]", email);

                    Customer1 Cu = new Customer1()
                    {
                        Fname = fname,
                        Lname = lname,
                        Username = email,
                        UserPass = password,
                        Phone = Convert.ToInt32(phone)
                    };

                    repo.CreateCustomer(Cu);
                    Thread.Sleep(400);
                    choice = 0;
                }
                else if (choice == 0)
                {
                    break;
                }
                Console.WriteLine("choice: " + choice);
            }
            Console.WriteLine("Thank you, come again!");
            return choice;
        }
    }
}
