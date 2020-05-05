using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Project0
{
    /// <summary>
    /// Method to create the database context used to read and write to the database
    /// </summary>
    public class Store_DbContext : DbContext
    {
        /// <summary>
        /// Orders table
        /// </summary>
        public DbSet<Order> Orders { get; set; }
        /// <summary>
        /// Products table
        /// </summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// Locations table
        /// </summary>
        public DbSet<Location> Locations { get; set; }
        /// <summary>
        /// OrderProducts table
        /// </summary>
        public DbSet<OrderProduct> OrderProducts { get; set; }
        /// <summary>
        /// Inventory table
        /// </summary>
        public DbSet<Inventory> Inventory { get; set; }
        /// <summary>
        /// Customer table
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// No argument constructor
        /// </summary>
        public Store_DbContext() { }
        /// <summary>
        /// Constructor for options configuration
        /// </summary>
        /// <param name="options">options settings</param>
        public Store_DbContext(DbContextOptions<Store_DbContext> options)
            : base(options)
        {}
        /// <summary>
        /// Setting the connection to the local SQLServer Database
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=ESTE; Database=Store; Trusted_connection = true;");
            }
        }
    }
}
