using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Project0
{
    class StoreOperation
    {
        private static ConsoleKey response;
        public Customer newCustomer = new Customer();
        public Product newProduct = new Product();
        Store_DbContext db = new Store_DbContext();
        public static string[] stateAbbreviations = {
            "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FM", "FL", "GA",
            "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MH", "MD", "MA",
            "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND",
            "MP", "OH", "OK", "OR", "PW", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT",
            "VT", "VI", "VA", "WA", "WV", "WI", "WY" };
        public static string namePattern = @"^([a-zA-Z-]{2,30})*$";
        public static string emailPattern = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$";
        public static string addressPattern = @"^([a-zA-Z0-9 .-]{0,50})*$";
        public static string cityPattern = @"^([a-zA-Z -]{2,30})*$";
        public static string phonePattern = @"^\d{10}$";
        public static string zipPattern = @"^\d{5}$";
        public static string productPattern = @"^([a-zA-Z0-9 .,-]{0,300})*$";
        public static string pricePattern = @"^\d{0,8}(\.\d{2})?$";


        String temp;

        private string[] commands;
        private string[] commandkeys;
        public void start()
        {
            do
            {
                Console.WriteLine("Welcome to the store! Use the following keys to execute an action.");

                commands = new string[]{"Create new order","Create new customer","Customer search","Look up customer order history","Update inventory","Create new product","Exit Program"};
                commandkeys = new string[] { "1", "2", "3", "4", "5","6", "ESC"};
                for (int i = 0; i < commands.Length; i++)
                {
                    Console.WriteLine("{0,-5} {1,-20}", commandkeys[i], commands[i]);
                }
                response = Console.ReadKey(false).Key;

                if(response == ConsoleKey.D1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Feature to be added later.");
                }
                else if(response == ConsoleKey.D2)
                {
                    Console.WriteLine();
                    newCustomer = AddCustomer();
                    if (newCustomer != null)
                    {
                        Console.WriteLine($"New Customer created for {newCustomer.FirstName} {newCustomer.LastName} as customer ID: {newCustomer.ID}");
                    }
                    else
                    {
                        Console.WriteLine("Customer creating cancelled.");
                        continue;
                    }
                }
                else if (response == ConsoleKey.D3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Feature to be added later.");
                }
                else if (response == ConsoleKey.D4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Feature to be added later.");
                }
                else if (response == ConsoleKey.D5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Feature to be added later.");
                }
                else if (response == ConsoleKey.D6)
                {
                    Console.WriteLine();
                    newProduct = AddProduct();
                    if (newProduct != null)
                    {
                        Console.WriteLine($"New Product created as \n{newProduct.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Product creation cancelled.");
                        continue;
                    }
                }

            } while (response != ConsoleKey.Escape);
        }
        public Customer AddCustomer()
        {
            newCustomer = new Customer();
            
            while (true)
            {
                Console.WriteLine("Customer First Name: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, namePattern)) break;
                Console.WriteLine("Invalid name. Please use only word characters.");
            }

            newCustomer.FirstName = temp;
            while (true)
            {
                Console.WriteLine("Customer Last Name: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, namePattern)) break;
                Console.WriteLine("Invalid name. Please use only word characters.");
            }
            newCustomer.LastName = temp;

            while (true)
            {
                Console.WriteLine("Customer Address Line 1: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, addressPattern)) break;
                Console.WriteLine("Invalid Address. Please use alphanumeric characters only.");
            }
            newCustomer.AddressLine1 = temp;
            while (true)
            {
                Console.WriteLine("Customer Address Line 2: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, addressPattern)) break;
                Console.WriteLine("Invalid Address. Please use alphanumeric characters only.");
            }
            newCustomer.AddressLine2 = temp;

            while (true)
            {
                Console.WriteLine("Customer City: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, cityPattern)) break;
                Console.WriteLine("Invalid City. Please use alphanumeric characters only.");
            }
            newCustomer.City = temp;

            while (true)
            {
                Console.WriteLine("Customer State (use two character code e.g. NY): ");
                temp = Console.ReadLine();
                if (stateAbbreviations.Contains(temp.ToUpper())) break;
                Console.WriteLine("Invalid State. Please enter correct State Abbreviation.");

            }
            newCustomer.State = temp;

            while (true)
            {
                Console.WriteLine("Customer Zip Code: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, zipPattern)) break;
                Console.WriteLine("Invalid Zip Code. Please enter 5 digits only.");
            }
            newCustomer.ZipCode = temp;

            while (true)
            {
                Console.WriteLine("Customer Phone Number: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, phonePattern)) break;
                Console.WriteLine("Invalid Phone Number. Please enter a 10-digit number with no dashes.");
            }
            newCustomer.Phone = "("+temp.Substring(0,3)+") " + temp.Substring(3,3) + "-"+temp.Substring(6);


            while (true)
            {
                Console.WriteLine("Customer email address: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, emailPattern)) break;
                Console.WriteLine("Invalid Email address. Please try again.");
            }
            newCustomer.Email = temp;

            newCustomer.PrintCustomerInfo();
            do
            {
                Console.WriteLine("Create new customer with this new information?");
                Console.WriteLine("Press Y to confirm");
                Console.WriteLine("Press N to reinput information");
                Console.WriteLine("Press C to cancel");

                response = Console.ReadKey(false).Key;
                if (response == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    db.Add(newCustomer);
                    db.SaveChanges();
                    return newCustomer;
                }
                if (response == ConsoleKey.N)
                {
                    Console.WriteLine();
                    return this.AddCustomer();
                }
                if (response == ConsoleKey.C)
                {
                    break;
                }

            } while (response != ConsoleKey.Y && response != ConsoleKey.N && response != ConsoleKey.C);
            return null;
        }
        public Product AddProduct()
        {
            newProduct = new Product();

            while (true)
            {
                Console.WriteLine("Product Name: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, productPattern)) break;
                Console.WriteLine("Invalid product name. Alphanumeric with . and - allowed.");
            }
            newProduct.ProductName = temp;

            while (true)
            {
                Console.WriteLine("Product Description: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, productPattern)) break;
                Console.WriteLine("Invalid product description. Alphanumeric with . and - and , allowed.");
            }
            newProduct.ProductDescription = temp;

            while (true)
            {
                Console.WriteLine("Product Price: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, pricePattern)) break;
                Console.WriteLine("Invalid price. Must be a decimal number with 2 decimal places at the end.");
            }
            newProduct.Price = Convert.ToDecimal(temp);

            newProduct.PrintProductInfo();
            do
            {
                Console.WriteLine("Create new product with this new information?");
                Console.WriteLine("Press Y to confirm");
                Console.WriteLine("Press N to reinput information");
                Console.WriteLine("Press C to cancel");

                response = Console.ReadKey(false).Key;
                if (response == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    db.Add(newProduct);
                    db.SaveChanges();
                    return newProduct;
                }
                if (response == ConsoleKey.N)
                {
                    Console.WriteLine();
                    return this.AddProduct();
                }
                if (response == ConsoleKey.C)
                {
                    break;
                }

            } while (response != ConsoleKey.Y && response != ConsoleKey.N && response != ConsoleKey.C);
            return null;


        }
        public void testMethod() {
           
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
