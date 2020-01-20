using PizzaBox.Domain.Models;
using PizzaBox.Storing.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaBox.Storing
{
    public class OrderRepository : IRepositoryOrders<Order1>
    {
        Project0Context PC;
        public OrderRepository()
        {
            PC = new Project0Context();
        }
        public OrderRepository(Project0Context PC)
        {
            // Directly taken from the aformentioned model by Pushpinder Kaur.
            this.PC = PC ?? throw new ArgumentNullException(nameof(PC));
        }



        public void CreateOrder(Order1 order)
        {
            //if (PC.CxOrder.Any(c => c.OrderId == order.) || order.Phone == null)
            //{
            //    Console.WriteLine($"This order with username {order.Username} already exists and cannot be added");
            //    return;
            //}
            //else
            PC.CxOrder.Add(MapOrder.Map(order));// this will generate insertMapper.Map(order)
            PC.SaveChanges();// this will execute the above generate insert query
        }

        public void DeleteOrder(int Id)
        {
            var Cus = PC.CxOrder.FirstOrDefault(Cx => Cx.Id == Id);
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

        public IEnumerable<Order1> ReadInOrder()
        {
            var getOrder = from O in PC.CxOrder
                        select MapOrder.Map(O);

            return getOrder;
        }

        public void UpdateOrder(Order1 order)
        {
            if (PC.order.Any(Cx => Cx.Id == order.Id))
            {
                var Cus = PC.order.FirstOrDefault(Cx => Cx.Id == order.Id);
                Cus.Username = order.Fname;
                PC.order.Update(Cus);
                PC.SaveChanges();
            }
        }
    }
}
