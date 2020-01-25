using PizzaBox.Storing.TestModels;
using System;
using System.Threading;

namespace PizzaBox.Storing.Logic.Login

{
    class CreateNewUser
    {
        public static bool CreateNewUserPrompt(Abstractions.IRepositoryCustomer<Customer1> repo)
        {
            // Check for valid email
            string email = EmailCheck.NewEmailChecker();
            if (RegexAndLoginExpressions.safeWord(email)) { return false; }
            // Check for valid password
            string password = PassCheck.NewPassChecker();
            if (RegexAndLoginExpressions.safeWord(password)) { return false; }
            // Check for valid first name
            string fname = FirstNameCheck.NewFirstNameChecker();
            if (RegexAndLoginExpressions.safeWord(fname)) { return false; }
            // Check for valid last name
            string lname = LastNameCheck.NewLastNameChecker();
            if (RegexAndLoginExpressions.safeWord(lname)) { return false; }
            // Check for valid phone
            string phone = PhoneCheck.NewPhoneChecker();
            if (RegexAndLoginExpressions.safeWord(phone)) { return false; }

            // Check if customer already exists
            if (CxAlreadyExists.CxAlreadyExistsChecker(repo, email, phone))
            {
                Console.Clear();
                Console.WriteLine("Email or phone# already taken please go back and login.");
                Thread.Sleep(1500);
                return false;
            }

            Console.Clear();
            Console.WriteLine("Created your account! [{0}]", email);
            Thread.Sleep(800);
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
            return true;
        }
    }
}
