using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Abstractions
{
    public interface IRepositoryStore<T>
    {
        // Create , Read, Update, Delete
        IEnumerable<T> ReadInStore();
        void CreateStore(T Store);
        void UpdateStore(T Store);
        void DeleteStore(int Id);
    }
}
