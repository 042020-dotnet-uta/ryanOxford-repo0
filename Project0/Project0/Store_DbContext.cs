using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Project0
{
    class Store_DbContext : DbContext
    {
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public Store_DbContext() { }

        public Store_DbContext(DbContextOptions<Store_DbContext> options)
            : base(options)
        {}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=ESTE; Database=Store; Trusted_connection = true;");
            }
        }
    }
}
