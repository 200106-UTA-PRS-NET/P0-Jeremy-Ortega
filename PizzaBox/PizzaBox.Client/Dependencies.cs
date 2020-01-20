using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaBox.Client
{
    public class Dependencies
    {

        public static IRepositoryCustomer<Storing.TestModels.Customer1> CreateCustomerRepository()
        {
            var configurBuilder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Project0"));
            var options = optionsBuilder.Options;
            Project0Context db = new Project0Context(options);
            return new CustomerRepository(db);
        }
        public static IRepositoryOrders<Storing.TestModels.Order1> CreateOrderRepository()
        {
            var configurBuilder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Project0"));
            var options = optionsBuilder.Options;
            Project0Context db = new Project0Context(options);
            return new OrderRepository(db);
        }

        internal static IRepositoryStore<Storing.TestModels.Store1> CreatStoreRepository()
        {
            var configurBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Project0"));
            var options = optionsBuilder.Options;
            Project0Context db = new Project0Context(options);
            return new StoreRepository(db);
        }

        internal static IRepositoryPizza<Storing.TestModels.Pizza1> CreatePizzaRepository()
        {
            var configurBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Project0"));
            var options = optionsBuilder.Options;
            Project0Context db = new Project0Context(options);
            return new PizzaRepository(db);
        }
    }
}
