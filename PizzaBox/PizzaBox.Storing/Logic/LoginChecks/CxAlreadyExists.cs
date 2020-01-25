using PizzaBox.Storing.TestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Logic.LoginChecks
{
    public class CxAlreadyExists
    {
        public static bool CxAlreadyExistsChecker(Abstractions.IRepositoryCustomer<Customer1> repo, string email, string phone)
        {
            var customers = repo.ReadInCustomer();

            foreach (var Cx in customers)
            {
                if (Cx.Email != null && Cx.Email.Equals(email))
                    if (Cx.Phone.Equals(phone))
                        return true;
            }
            return false;
        }
    }
}
