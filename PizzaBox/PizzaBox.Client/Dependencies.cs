using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaBox.Client
{
    class Dependencies
    {

        public static IRepositoryCustomer<Storing.Customer1> CreateCustomerRepository()
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
    }
}
