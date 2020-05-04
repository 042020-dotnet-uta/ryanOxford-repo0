using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.InMemory;
using Xunit;
using Project0;

namespace Project0_Unit_Test
{
    public class Customer_Add_Test
    {
        [Fact]
        public void Test_1() {
            var options = new DbContextOptionsBuilder<Store_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test_1")
                .Options;

            //using (var context = new Store_DbContext options)
            //{

            //}
        }

    }
}
