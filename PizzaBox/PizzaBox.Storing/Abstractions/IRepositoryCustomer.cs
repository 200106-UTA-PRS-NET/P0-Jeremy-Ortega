using System;
using System.Collections.Generic;
using System.Text;


namespace PizzaBox.Storing.Abstractions
{
    public interface IRepositoryCustomer<T>
    {
        // Create , Read, Update, Delete
        IEnumerable<T> ReadInCustomer();
        void CreateCustomer(T Customer);
        void UpdateCustomer(T Customer);
        void DeleteCustomer(int Id);
    }
}
