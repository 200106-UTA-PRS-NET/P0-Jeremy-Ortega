using PizzaBox.Storing.TestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace PizzaBox.Storing.Logic.LoginChecks
{
    class LoginUserPrompt
    {
        public static string LoginUserPrompter(Abstractions.IRepositoryCustomer<Customer1> repo)
        {

            var customers = repo.ReadInCustomer();

            string email = NewEmailCheck.NewEmailChecker();
            if (email.Equals("quit")) { return "@"; }

            string password = NewPassCheck.NewPassChecker();
            if (password.Equals("quit")) { return "@"; }
            string name = "";
            bool correctAuth = false;
            foreach (var Cx in customers)
            {
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
                Thread.Sleep(1000);
                return "@";
            }

            return name;
        }
    }
}
