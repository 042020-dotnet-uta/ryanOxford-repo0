using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.InMemory;
using Xunit;
using Project0;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;

namespace Project0_Unit_Test
{
    public partial class AdditionTests
    {
        [Fact]
        public void AddCustomerToDatabase() {
            var options = new DbContextOptionsBuilder<Store_DbContext>()
                .UseInMemoryDatabase(databaseName: "AddCustomerToDatabase")
                .Options;

            using(var db = new Store_DbContext(options))
            {
                db.Add(new Customer
                {
                    FirstName = "Test",
                    LastName = "Name",
                    AddressLine1 = "Test",
                    AddressLine2 = "Address",
                    City = "City",
                    State = "TX",
                    ZipCode = "75024",
                    Phone = "(555)555-5555",
                    Email = "test@email.com"
                });
                db.SaveChanges();

            }
            using (var db = new Store_DbContext(options))
            {
                Assert.Single(db.Customers);
            }

        }
        [Fact]
        public void AddLocationToDatabase()
        {
            var options = new DbContextOptionsBuilder<Store_DbContext>()
                 .UseInMemoryDatabase(databaseName: "AddLocationToDatabase")
                 .Options;

            using (var db = new Store_DbContext(options))
            {
                db.Add(new Location
                {
                    Name = "Test Location"
                });
                db.SaveChanges();

            }
            using (var db = new Store_DbContext(options))
            {
                Assert.Single(db.Locations);
            }
        }
        [Fact]
        public void AddProductToDatabase()
        {
            var options = new DbContextOptionsBuilder<Store_DbContext>()
                 .UseInMemoryDatabase(databaseName: "AddProductToDatabase")
                 .Options;

            using (var db = new Store_DbContext(options))
            {
                db.Add(new Product
                {
                    ProductName = "Test Product",
                    ProductDescription = "Test description",
                    Price = Convert.ToDecimal(199.99)
                });
                db.SaveChanges();

            }
            using (var db = new Store_DbContext(options))
            {
                Assert.Single(db.Products);
            }
        }
        [Fact]
        public void AddOrderProductToDatabase()
        {
            var options = new DbContextOptionsBuilder<Store_DbContext>()
                 .UseInMemoryDatabase(databaseName: "AddOrderProductToDatabase")
                 .Options;

            using (var db = new Store_DbContext(options))
            {
                db.Add(new OrderProduct
                {

                    Order = new Order(),
                    Product = new Product(),
                    Quantity = 10
                });
                db.SaveChanges();

            }
            using (var db = new Store_DbContext(options))
            {
                Assert.Single(db.OrderProducts);
                Assert.Single(db.Orders);
                Assert.Single(db.Products);
            }
        }
        [Fact]
        public void AddInventoryToDatabase()
        {
            var options = new DbContextOptionsBuilder<Store_DbContext>()
                 .UseInMemoryDatabase(databaseName: "AddInventoryToDatabase")
                 .Options;

            using (var db = new Store_DbContext(options))
            {
                db.Add(new Inventory
                {

                    Location = new Location(),
                    Product = new Product(),
                    Quantity = 10
                });
                db.SaveChanges();

            }
            using (var db = new Store_DbContext(options))
            {
                Assert.Single(db.Inventory);
            }
        }
        [Fact]
        public void AddOrderToDatabase()
        {
            var options = new DbContextOptionsBuilder<Store_DbContext>()
                 .UseInMemoryDatabase(databaseName: "AddOrderToDatabase")
                 .Options;

            using (var db = new Store_DbContext(options))
            {
                db.Add(new Order
                {
                    Customer = new Customer(),
                    Location = new Location(),
                    OrderCompleteTime = DateTime.Now
                });
                db.SaveChanges();

            }
            using (var db = new Store_DbContext(options))
            {
                Assert.Single(db.Orders);
                Assert.Single(db.Customers);
                Assert.Single(db.Locations);

            }
        }


    }
}
