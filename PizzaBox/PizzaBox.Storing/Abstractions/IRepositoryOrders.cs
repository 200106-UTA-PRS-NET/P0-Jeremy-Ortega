using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Abstractions
{
    public interface IRepositoryOrders<T>
    {
        // Create , Read, Update, Delete
        IEnumerable<T> ReadInOrder();
        void CreateOrder(T Order);
        void UpdateOrder(T Order);
        void DeleteOrder(int Id);
    }
}
