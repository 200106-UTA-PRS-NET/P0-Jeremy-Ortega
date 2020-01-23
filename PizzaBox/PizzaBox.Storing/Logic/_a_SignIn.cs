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

            var customers = repo.ReadInCustomer();
            

            int choice = -1;
            while (!(choice >= 1 && choice <= 2))
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
                    string quit = "";

                    string emailChk = @"^[a-zA-Z0-9_]{1,15}[@][a-zA-Z0-9_]{1,15}[.][a-zA-Z]{2,3}$";
                    Match mxEmail = Regex.Match("", emailChk);
                    string email = "";
                    while (!mxEmail.Success && !quit.Equals("quit"))
                    {
                        // Email
                        Console.Clear();
                        Console.WriteLine("\n  ---- email ---- \"quit\" to return");
                        email = Console.ReadLine();
                        quit = email;
                        mxEmail = Regex.Match(email, emailChk);
                    }
                    if (quit.Equals("quit")) {
                        choice = -1;
                        continue; 
                    }
                

                    // password
                    string passCheck = @"^[a-zA-Z0-9_]{1,15}$";
                    // phone pattern complete
                    Match rxPass = Regex.Match("", passCheck);
                    string password = "";
                    while (!rxPass.Success && !quit.Equals("quit"))
                    {
                        // First Name
                        Console.Clear();
                        Console.WriteLine("\n ---- password ---- \"quit\" to return");
                        password = Console.ReadLine();
                        quit = password;
                        rxPass = Regex.Match(password, passCheck);
                    }
                    if (quit.Equals("quit")) { choice = -1; continue; }

                    string name = "";
                    bool correctAuth = false;
                    foreach (var Cx in customers) {
                        if (Cx.Email != null && Cx.Email.Equals(email))
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
                        Thread.Sleep(1200);
                        choice = -1;
                        continue;
                    }
                    LOH.ChooseVewOrdersOrStorePortal(name, repo, orderRepo, pizzaRepo, storeRepo);
                    choice = 0;
                }

                //ask for user to create new acount by giving a email and password 
                else if (choice == 2)
                {
                    string quit = "";

                    string emailChk = @"^[a-zA-Z0-9_]{1,15}[@][a-zA-Z0-9_]{1,15}[.][a-zA-Z]{2,3}$";
                    Match mxEmail = Regex.Match("", emailChk);
                    string email = "";
                    while(!mxEmail.Success && !quit.Equals("quit"))
                    {
                        // Email
                        Console.Clear();
                        Console.WriteLine("\n  ---- new email - typical email format required ----\n\t\t\"quit\" to return");
                        email = Console.ReadLine();
                        quit = email;
                        mxEmail = Regex.Match(email, emailChk);
                    }
                    if (quit.Equals("quit")) { choice = -1; break; }

                    // password
                    string passCheck = @"^[a-zA-Z0-9_]{1,15}$";
                    // phone pattern complete
                    Match rxPass = Regex.Match("", passCheck);
                    string password = "";
                    while (!rxPass.Success && !quit.Equals("quit"))
                    {
                        // First Name
                        Console.Clear();
                        Console.WriteLine("\n ---- create password please only 15 characters, numbers, and top row special characters only ----\n\t\t\"quit\" to return");
                        password = Console.ReadLine();
                        quit = password;
                        rxPass = Regex.Match(password, passCheck);
                    }
                    if (quit.Equals("quit")) { choice = -1; break; }


                    string namePattern = @"^[a-zA-Z]{1,15}$";
                    // phone pattern complete
                    Match rxFname = Regex.Match("", namePattern);
                    string fname = "";
                    while (!rxFname.Success && !quit.Equals("quit"))
                    {
                        // First Name
                        Console.Clear();
                        Console.WriteLine("\n ---- first name up to 15 characters Only Letters ----\n\t\t\"quit\" to return");
                        fname = Console.ReadLine();
                        quit = fname;
                        rxFname = Regex.Match(fname, namePattern);
                    }
                    if (quit.Equals("quit")) { choice = -1; break; }

                    // phone pattern complete
                    Match rxLname = Regex.Match("", namePattern);
                    string lname = "";
                    while (!rxLname.Success && !quit.Equals("quit"))
                    {
                        // Last Name
                        Console.Clear();
                        Console.WriteLine("\n ---- last name up to 15 characters ---\n\t\t\"quit\" to return");
                        lname = Console.ReadLine();
                        quit = lname;
                        rxLname = Regex.Match(lname, namePattern);
                    }
                    if (quit.Equals("quit")) { choice = -1; break; }

                    // phone pattern complete
                    string phonePattern = @"^[0-9]{3}[\-]?[0-9]{3}[\-]?[0-9]{4}$";
                    Match rxPhone = Regex.Match("", phonePattern);
                    string phone = "";
                    while (!rxPhone.Success && !quit.Equals("quit"))
                    {
                        // Phone Number
                        Console.Clear();
                        Console.WriteLine("\n ---- Phone 9 digits not starting with 0 ----");
                        phone = Console.ReadLine();
                        rxPhone = Regex.Match(phone, phonePattern);

                        /////////////// Fix Phone bug - remove string '-' from string
                        phone = Regex.Replace(phone, "[/-]", "");
                        if (phone.StartsWith("0"))
                        {
                            rxPhone = Regex.Match("123", phonePattern);
                        }
                    }


                    /////////////// Fix Phone bug - remove string '-' from string
                    phone = Regex.Replace(phone, "[/-]", "");
                   

                    bool correctAuth = false;
                    foreach (var Cx in customers)
                    {
                        if (Cx.Email != null && Cx.Email.Equals(email))
                            if (Cx.UserPass.Equals(password))
                                correctAuth = true;
                    }
                    if (correctAuth)
                    {
                        Console.Clear();
                        Console.WriteLine("Email already taken please sign in or use another email address.");
                        Thread.Sleep(1500);
                        choice = -1;
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine("Created your account! [{0}]", email);
                    Random random = new Random();
                    Customer1 Cu = new Customer1()
                    {
                        Id = random.Next(1000000000, 2000000000),
                        Fname = fname,
                        Lname = lname,
                        Email = email,
                        UserPass = password,
                        Phone = Convert.ToInt64(phone)
                    };

                    repo.CreateCustomer(Cu);
                    Thread.Sleep(400);
                    choice = -1;
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
