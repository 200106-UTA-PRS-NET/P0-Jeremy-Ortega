using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;

namespace PizzaBox.Storing.Repositories
{
    /// <summary>
    /// This model was diaplayed and placed on github by Pushpinder Kaur. 
    /// </summary>
    public class CustomerRepository : IRepositoryCustomer<Customer1>
    {
        PizzaProjectContext PC;
        public CustomerRepository()
        {
            PC = new PizzaProjectContext();
        }
        public CustomerRepository(PizzaProjectContext PC)
        {
            // Directly taken from the aformentioned model by Pushpinder Kaur.
            this.PC = PC ?? throw new ArgumentNullException(nameof(PC));
        }



        public void CreateCustomer(Customer1 customer)
        {
            if (PC.Customer.Any(c => c.Phone == customer.Phone) || customer.Phone == null)
            {
                Console.WriteLine($"This customer with username {customer.Email} already exists and cannot be added");
                return;
            }
            else
                PC.Customer.Add(Mappings.Mapper.Map(customer));// this will generate insertMapper.Map(customer)
            PC.SaveChanges();// this will execute the above generate insert query
        }

        public void DeleteCustomer(int Id)
        {
            var Cus = PC.Customer.FirstOrDefault(Cx => Cx.Id == Id);
            if (Cus.Id == Id)
            {
                PC.Remove(Cus);
                PC.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Cx with id {Id} doesn't exist");
                return;
            }
        }

        public IEnumerable<Customer1> ReadInCustomer()
        {
            var getCx = from cx in PC.Customer
                        select Mappings.Mapper.Map(cx);

            return getCx;
        }

        public void UpdateCustomer(Customer1 Customer)
        {
            if(PC.Customer.Any(Cx => Cx.Id == Customer.Id))
            {
                var Cus = PC.Customer.FirstOrDefault(Cx => Cx.Id == Customer.Id);
                Cus.Fname = Customer.Fname;
                PC.Customer.Update(Cus);
                PC.SaveChanges();
            }
        }
    }
}
