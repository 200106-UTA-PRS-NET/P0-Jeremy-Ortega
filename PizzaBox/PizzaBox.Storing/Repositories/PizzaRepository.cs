using PizzaBox.Storing.TestModels;
using PizzaBox.Storing.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Mappings;

namespace PizzaBox.Storing.Repositories
{
    public class PizzaRepository : IRepositoryPizza<Pizza1>
    {
        Project0Context PC;
        public PizzaRepository()
        {
            PC = new Project0Context();
        }
        public PizzaRepository(Project0Context PC)
        {
            // Directly taken from the aformentioned model by Pushpinder Kaur.
            this.PC = PC ?? throw new ArgumentNullException(nameof(PC));
        }

        public void CreatePizza(Pizza1 pizza)
        {
            PC.Pizza.Add(MapPizza.Map(pizza));// this will generate insertMapper.Map(order)
            PC.SaveChanges();// this will execute the above generate insert query
        }

        public void DeletePizza(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizza1> ReadInPizza()
        {
            var getPizza = from P in PC.Pizza
                           select MapPizza.Map(P);

            return getPizza;
        }

        public void UpdatePizza(Pizza1 Order)
        {
            throw new NotImplementedException();
        }
    }
}
