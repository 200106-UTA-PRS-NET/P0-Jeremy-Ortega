using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Abstractions
{
    public interface IRepositoryPizza<T>
    {
        // Create , Read, Update, Delete
        IEnumerable<T> ReadInPizza();
        void CreatePizza(T Pizza);
        void UpdatePizza(T Pizza);
        void DeletePizza(int Id);
    }
}
