using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Project0
{
    class StoreOperation
    {
        public Customer newCustomer = new Customer();
        Store_DbContext db = new Store_DbContext();

        public void AddCustomer()
        {
            Console.WriteLine("Customer First Name: ");
            String Name = Console.ReadLine();
            newCustomer.FirstName = Name;

            Console.WriteLine("Customer Last name: ");
            Name = Console.ReadLine();
            newCustomer.LastName = Name;

            db.Add(newCustomer);
            db.SaveChanges();
            var dbentry = db.Customers.Where(x => x.FirstName == "Fred").ToList();
            var linqTest = from cust in db.Customers
                           where cust.FirstName == "Fred"
                            select cust;
            foreach(Customer obj in dbentry)
            {
                Console.WriteLine("List of things: " + obj.LastName);
            }
            foreach(Customer obj in linqTest)
            {
                Console.WriteLine("Second List: " + obj.LastName);
            }
            
        }
    }
}
