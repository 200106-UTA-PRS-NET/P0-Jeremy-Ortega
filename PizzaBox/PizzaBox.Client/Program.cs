using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain;
using PizzaBox.Storing;
using PizzaBox.Storing.Logic;


namespace PizzaBox.Client
{
    
    public class Program
    {


        public Program()
        {

        }

        public static void Main(string[] args)
        {
            // Initialize the main data structures going to be handling the pertinant selection data
            //StoreRepository stores = new StoreRepository();
            //Pizza pizza = new Pizza();
            //Dictionary<string, string> UserList = new Dictionary<string, string>();
            //int choice = SI.SignInToAccount(UserList, pizza, stores, CxRepo, orderRepo, pizzaRepo, storeRepo);

            _a_SignIn SI = new _a_SignIn();
            // Sign In 

            var CxRepo = Dependencies.CreateCustomerRepository();
            var orderRepo = Dependencies.CreateOrderRepository();
            var pizzaRepo = Dependencies.CreatePizzaRepository();
            var storeRepo = Dependencies.CreatStoreRepository();

            int choice = SI.SignInToAccount(CxRepo, orderRepo, pizzaRepo, storeRepo);

            //Storing.Abstractions.IRepositoryCustomer<Customer1> repo




            //foreach (var Cx in customer)
            //{
            //    if(Cx.Fname != "" || Cx.Fname != null)
            //        Console.WriteLine($"{Cx.Fname} {Cx.Lname}");
            //}
            //Console.ReadLine();


            // // Works just need to stop creating new 
            //Customer1 Cu = new Customer1()
            //{
            //    Fname = "Jeremy",
            //    Lname = "Ortega",
            //    Username = "jmastaice",
            //    UserPass = "1",
            //    Phone = 1234561117
            //};

            //repo.CreateCustomer(Cu);


            //// Update Works - will need to delete all references to Cx Id in other tables before finally deleting this 
            //// row. 
            //Customer1 cu2 = new Customer1()
            //{
            //    Fname = "JMaStAiCe",
            //    Id = 12,
            //};
            //repo.UpdateCustomer(cu2);
            //Console.ReadLine();

            //// Deletion Works
            //repo.DeleteCustomer(12);



            //CustomerRepository CR = new CustomerRepository();
        }

    
    }


}
