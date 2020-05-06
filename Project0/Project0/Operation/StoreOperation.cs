#region Using Statements
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

#endregion


namespace Project0
{
    /// <summary>
    /// The <c>StoreOperation</c> class
    /// Contains the logic for operating the store
    /// </summary>
    public class StoreOperation
    {
        #region Variable declaration
        //Declaring variables
        private static ConsoleKey response;
        /// <summary>
        /// Placeholder Order Object
        /// </summary>
        public Order newOrder = new Order();
        /// <summary>
        /// Placeholder Customer Object
        /// </summary>
        public Customer newCustomer = new Customer();
        /// <summary>
        /// Placeholed List of Customer Objects
        /// </summary>
        public List<Customer> customerList = new List<Customer>();
        /// <summary>
        /// Placeholder Product object
        /// </summary>
        public Product newProduct = new Product();
        /// <summary>
        /// Placeholder List of Product objects
        /// </summary>
        public List<Product> productList = new List<Product>();
        /// <summary>
        /// Placeholder Inventory Object
        /// </summary>
        public Inventory newInventory = new Inventory();
        /// <summary>
        /// Placeholder List of Inventory objects
        /// </summary>
        public List<Inventory> InventoryList = new List<Inventory>();
        /// <summary>
        /// Placeholder Location object
        /// </summary>
        public Location newLocation = new Location();
        /// <summary>
        /// Placeholder List of Order objects
        /// </summary>
        public List<Order> orderList = new List<Order>();
        /// <summary>
        /// Placeholder List of OrderProduct objects
        /// </summary>
        public List<OrderProduct> orderProductList = new List<OrderProduct>();

        //db context to be used throughout the class
        Store_DbContext db = new Store_DbContext();


        String temp;

        //variables for controlling the console interface
        private string[] commands;
        private string[] commandkeys;
        #endregion
        #region Operation

        //This method will initiate the store operation
        /// <summary>
        /// Starts the operation
        /// Contains the main loop which runs through the program
        /// </summary>
        public void start()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("*****************************************");
                Console.WriteLine("Welcome to the store! Use the following keys to execute an action.");

                //Declaring two arrays to display the interface options
                commands = new string[]{"Create new order","Create new customer","Customer search","Look up customer order history","Update inventory","Create new product","Look up location order history","Check Inventory","Exit Program"};
                commandkeys = new string[] { "1", "2", "3", "4", "5","6","7","8", "ESC"};

                //Formatting the interface options
                for (int i = 0; i < commands.Length; i++)
                {
                    Console.WriteLine("{0,-5} {1,-20}", commandkeys[i], commands[i]);
                }
                response = Console.ReadKey(false).Key;

                #region First Section - Create new order
                //Code to execute with the first option
                if (response == ConsoleKey.D1)
                {
                    Console.WriteLine();
                    //Create a new order, prompting for a customer and location
                    //Calls the CreateOrder Method, which returns an order object
                    newOrder = CreateOrder();

                    if (newOrder == null) break;

                    //Call loop to add products to the order;
                    //Calls AddToOrder method, which returns an order object\
                    //If the order object is null, the order has been cancelled
                    newOrder = AddToOrderLoop(newOrder);
                    if (newOrder != null)
                    {
                        newOrder.OrderCompleteTime = DateTime.Now;
                        try
                        {
                            db.Add(newOrder);
                            foreach (OrderProduct obj in newOrder.Products)
                            {
                                newInventory = db.Inventory.Include("Product").Include("Location").FirstOrDefault(x => x.Location.ID == newOrder.Location.ID && x.Product.ID == obj.Product.ID);
                                newInventory.Quantity -= obj.Quantity;
                                db.Add(obj);
                            }
                            db.SaveChanges();
                            Console.WriteLine();
                            Console.WriteLine($"Order added as order {newOrder.ID}");
                        }
                        catch(System.Exception e)
                        {
                            Console.WriteLine($"Error writing the data to the database:\n{e}");
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Order cancelled.");
                    }
                    //Press any key method pauses the operation until a key is pressed
                    PressAnyKey();
                    
                }
                #endregion

                #region Second Section - Create new customer
                //Second option section
                else if (response == ConsoleKey.D2)
                {
                    Console.WriteLine();
                    //Calls the AddCustomer method, which returns a Customer object
                    //The object is saved to the database and the object is returned if successful
                    //If cancelled, returns a null object, and nothing is saved
                    newCustomer = AddCustomer();
                    if (newCustomer != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"New Customer created for {newCustomer.FirstName} {newCustomer.LastName} as customer ID: {newCustomer.ID}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Customer creating cancelled.");
                    }
                    PressAnyKey();
                }
                #endregion

                #region Third Section - Customer search
                else if (response == ConsoleKey.D3)
                {
                    //Prompts for a first and last name, and returns all customers that match
                    //Returns customer object and prints the customer info
                    //If null is returned, the customer was not found
                    Console.WriteLine();
                    customerList = CustomerSearch();
                    if(customerList.Count > 0)
                    {
                        foreach(var obj in customerList)
                        {
                            obj.PrintInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No customer found matching that name.");
                    }
                    PressAnyKey();
                }
                #endregion

                #region Fourth Section - Look up customer order history
                else if (response == ConsoleKey.D4)
                {
                    //Prompts for customer ID, then returns all customer orders in a list of orders
                    //If List is returned, displays the info for all of the customer orders
                    //If null is returned, the customer has no orders
                    //If wrong customer ID is entered, returns to main menu
                    Console.WriteLine();
                    orderList = CustomerOrderList();
                    if(orderList != null)
                    {
                        foreach(Order obj in orderList)
                        {
                            obj.PrintInfo();
                        }
                    }
                    PressAnyKey();
                }
                #endregion

                #region Fifth Section - Update inventory
                else if (response == ConsoleKey.D5)
                {
                    //Prompts for Location and Product IDs, and a quantity, then adds a quantity to the given inventory
                    //If no product inventory is found, one is created, then the quantity is updated

                    Console.WriteLine();
                    newInventory = AddToInventory();
                    if (newInventory != null)
                    {
                        Console.WriteLine($"Inventory for {newInventory.Product.ProductName} at {newInventory.Location.Name} updated to {newInventory.Quantity}.");
                    }
                    else
                    {
                        Console.WriteLine("Inventory update cancelled.");
                    }
                    PressAnyKey();
                }
                #endregion

                #region Sixth Section - Create new product
                else if (response == ConsoleKey.D6)
                {
                    //Prompts for a product name and description, then adds the product to the product list
                    //Ability to confirm or cancel upon creation
                    Console.WriteLine();
                    newProduct = AddProduct();
                    if (newProduct != null)
                    {
                        Console.WriteLine();
                        db.Add(newProduct);
                        db.SaveChanges();
                        Console.WriteLine($"New Product created as \n{newProduct.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Product creation cancelled.");
                    }
                    PressAnyKey();
                }
                #endregion

                #region Seventh Section - Look up location order history
                else if (response == ConsoleKey.D7)
                {
                    //Prompts for a location name, then displays all orders for the location
                    //Returns a list of orders
                    //If null is returned, no orders exist for the location
                    Console.WriteLine();
                    orderList = LocationOrderList();
                    if (orderList != null)
                    {
                        foreach (Order obj in orderList)
                        {
                            obj.PrintInfo();
                        }
                    }
                    PressAnyKey();
                }
                #endregion

                #region Eighth Section - Check Inventory
                else if (response == ConsoleKey.D8)
                {
                    //Displays locations, then prompts for a location ID
                    //Returns the inventory at this location
                    PrintInventory();
                    PressAnyKey();

                }
                #endregion

            } while (response != ConsoleKey.Escape);
            
        }

        #endregion
        #region Add Elements
        /// <summary>
        /// The method to add customer records
        /// Runs through prompt to gather and validate customer info
        /// </summary>
        /// <returns>
        /// A <c>Customer</c> object containing the new customer info
        /// </returns>
        public Customer AddCustomer()
        {
            newCustomer = new Customer();
            //While true loops used to control the data prompting - Thanks @Will Ruiz for the idea!
            //Does not break until input is validated
            //uses Regex patterns to validate the inputs
            //Pattens contained in Regex pattern class

            #region Customer Input Prompts

            

            try
            {
                newCustomer.FirstName = InputPrompts.FirstNamePrompt();
                newCustomer.LastName = InputPrompts.LastNamePrompt();
                newCustomer.AddressLine1 = InputPrompts.Address1Prompt();
                newCustomer.AddressLine2 = InputPrompts.Address2Prompt();
                newCustomer.City = InputPrompts.CityPrompt();
                newCustomer.State = InputPrompts.StatePrompt();
                newCustomer.ZipCode = InputPrompts.ZipPrompt();
                newCustomer.Phone = InputPrompts.PhonePrompt();
                newCustomer.Email = InputPrompts.EmailPrompt();
            }
            catch(System.Exception e)
            {
                Console.WriteLine($"Error inputting customer information:\n{e}.");
            }

            #endregion
            //Print out the information that was input for confirmation
            newCustomer.PrintInfo();


            //Do loop to prompt for confirmation. If confirmed, data is stored to the database as a new customer
            do
            {
                Console.WriteLine("Create new customer with this new information?");
                Console.WriteLine("Press Y to confirm");
                Console.WriteLine("Press N to reinput information");
                Console.WriteLine("Press C to cancel");

                //Using this readkey object to manage navigation
                response = Console.ReadKey(false).Key;
                if (response == ConsoleKey.Y)
                {
                    //If confirmed, add the customer to the database
                    Console.WriteLine();
                    db.Add(newCustomer);
                    db.SaveChanges();
                    return newCustomer;
                }
                if (response == ConsoleKey.N)
                {
                    //Recall the method to reinput the customer information
                    Console.WriteLine();
                    return this.AddCustomer();
                }
                if (response == ConsoleKey.C)
                {
                    //break the loop to cancel the customer creation
                    break;
                }

            } while (response != ConsoleKey.Y && response != ConsoleKey.N && response != ConsoleKey.C);
            return null;
        }

        /// <summary>
        /// The method to add product records
        /// Runs through a prompt to gather and validate product info
        /// </summary>
        /// <remarks>
        /// Checks to see if the product name already exists, and prevents addition
        /// </remarks>
        /// <returns>
        /// A <c>Product</c> object containing the new Product info
        /// </returns>
        public Product AddProduct()
        {
            string productTemp = "";
            //while true loop to handle data input
            //Regex pattern to validate input, repeat loop until correct
            try
            {
                productTemp = InputPrompts.ProductNamePrompt();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error entering product name:\n{e}");
            }
            //Query the database to check for another product with the same name
            //If it exists, re-prompt
            newProduct = db.Products.Where(x => x.ProductName == productTemp).FirstOrDefault();
            if (newProduct != null)
            {
                Console.WriteLine("Product already exists. Please enter a unique product name.");
                newProduct = AddProduct();
            }

            try
            {
                //Call a new instance of the Product class, and assign the ProductName property the newly input value
                newProduct = new Product();
                newProduct.ProductName = productTemp;

                //Prompt for the product description

                newProduct.ProductDescription = InputPrompts.ProductDescriptionPrompt();


                //Prompt for the product price

                newProduct.Price = InputPrompts.ProductPricePrompt();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error entering product information:\n{e}");
            }
            //Print the newly input information and confirm the saving
            newProduct.PrintInfo();
            do
            {
                Console.WriteLine("Create new product with this new information?");
                Console.WriteLine("Press Y to confirm");
                Console.WriteLine("Press N to reinput information");
                Console.WriteLine("Press C to cancel");

                //Console Key used to control the navigation
                response = Console.ReadKey(false).Key;
                if (response == ConsoleKey.Y)
                {
                    //Return the new product object
                    return newProduct;
                }
                if (response == ConsoleKey.N)
                {
                    //Recall the method if you choose to reinput the information
                    Console.WriteLine();
                    return this.AddProduct();
                }
                if (response == ConsoleKey.C)
                {
                    //End the loop and return null to cancel the creation
                    break;
                }

            } while (response != ConsoleKey.Y && response != ConsoleKey.N && response != ConsoleKey.C);
            return null;


        }
        #endregion
        #region Inventory
        /// <summary>
        /// The method to increase the inventory of an item
        /// Prompts for location and product id
        /// </summary>
        /// <remarks>
        /// If there is no inventory item present, one is created
        /// </remarks>
        /// <returns>
        /// An <c>Inventory</c> object containing the new Inventory status
        /// </returns>
        public Inventory AddToInventory()
        {
            int idTemp = 0;
            int quantityTemp = 0;
            newInventory = new Inventory();
            var dbLocations = db.Locations.ToList();
            //Print out a list of locations to select from
            Console.WriteLine("List of Locations:\n");
            foreach(var obj in dbLocations)
            {
                Console.WriteLine(obj.ToString());
            }
            var dbLocation = new Location();

            //Loop to check if Location ID is present
            while (true)
            {
                idTemp = InputPrompts.IDPrompt("Location");
                dbLocation = db.Locations.FirstOrDefault(x => x.ID == idTemp);
                if (dbLocation != null) break;
                Console.WriteLine("Location ID not found. Please try again.");
            }

            //List out the products available at the location given
            var dbentry = db.Products.ToList();
            Console.WriteLine("List of products:\n");
            foreach(var obj in dbentry)
            {
                Console.WriteLine(obj.ToString());
            }
            var dbProduct = new Product();
            while (true)
            {
                idTemp = InputPrompts.IDPrompt("Product");
                //Check to see if the product exists
                dbProduct = db.Products.FirstOrDefault(x => x.ID == idTemp);
                if (dbProduct != null) break;
                Console.WriteLine("Product ID not found. Please try again.");
            }
            try
            {
                quantityTemp = InputPrompts.QuantityPrompt();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error with quantity prompt:\n{e}");
            }
            //Check to see if Product Exists in inventory. 
            //If it does not, create an object and add it. 
            //If it does, add the quantity to the existing object
            var dbInventory = db.Inventory.Include("Product").Include("Location").FirstOrDefault(x => x.Product == dbProduct && x.Location == dbLocation);
            if (dbInventory != null)
            {
                dbInventory.Quantity += quantityTemp;
                newInventory = dbInventory;
            }
            else
            {
                newInventory.Product = dbProduct;
                newInventory.Location = dbLocation;
                newInventory.Quantity = quantityTemp;
                db.Add(newInventory);
            }
            db.SaveChanges();
            return newInventory;
        }

        /// <summary>
        /// This method prompts for a location ID then prints the current inventory at this location
        /// </summary>
        public void PrintInventory()
        {
            var dbLocations = db.Locations.ToList();
            Console.WriteLine("List of Locations:\n");
            foreach (var obj in dbLocations)
            {
                Console.WriteLine(obj.ToString());
            }
            try
            {
                newLocation = db.Locations.FirstOrDefault(x => x.ID == InputPrompts.IDPrompt("Location"));
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error retrieving Location from the database:\n{e}");
            }
            if (newLocation != null)
            {
                try
                {
                    InventoryList = db.Inventory.Include("Product").Include("Location").Where(x => x.Location.ID == newLocation.ID).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error retrieving inventory list from database:\n{e}");
                }
                if (InventoryList.Count>0)
                {
                    Console.WriteLine("Current Inventory Items:\n");
                    foreach(Inventory inv in InventoryList)
                    {
                        inv.PrintInfo();
                    }
                }
                else
                {
                    Console.WriteLine("Currently no items have been added to this inventory.");
                }
            }
        }
        #endregion
        #region Order control
        /// <summary>
        /// Creates a new order object that can be used to submit a new order
        /// </summary>
        /// <returns>An <c>Order</c> object</returns>
        public Order CreateOrder()
        {
            newOrder = new Order();
            var dbLocations = db.Locations.ToList();
            Console.WriteLine("List of Locations:\n");
            foreach (var obj in dbLocations)
            {
                Console.WriteLine(obj.ToString());
            }
            
            var dbLocation = new Location();
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Enter Location ID: ");
                    temp = Console.ReadLine();
                    if (Regex.IsMatch(temp, InputPrompts.idPattern)) break;
                    Console.WriteLine("Invalid id. Please use only numbers.");
                }
                newLocation = db.Locations.FirstOrDefault(x => x.ID == Int32.Parse(temp));
                if (newLocation != null) break;

                Console.WriteLine("Location ID not found. Please try again.");
            }

           
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Enter Customer ID: ");
                    temp = Console.ReadLine();
                    if (Regex.IsMatch(temp, InputPrompts.idPattern)) break;
                    Console.WriteLine("Invalid id. Use only numbers.");
                }
                newCustomer = db.Customers.FirstOrDefault(x => x.ID == Int32.Parse(temp));
                if (newCustomer != null) break;
                else
                {
                    Console.WriteLine("Customer ID not found. Use the customer search to find a customer by their first and last name. \nReturning to main menu.");
                    return null;
                }
            }
            return newOrder = new Order(newCustomer, newLocation);
        }

        /// <summary>
        /// Loop to operate adding products to the order
        /// </summary>
        /// <param name="order">Passing in an order to add to</param>
        /// <returns>An order with products added to it</returns>
        public Order AddToOrderLoop(Order order)
        {
            ConsoleKey newResponse;

            do
            {
                //Display current inventory for the location selected
                Console.WriteLine("Current inventory at location");
                InventoryList = db.Inventory.Include("Product").Include("Location").Where(x => x.Location.ID == order.Location.ID).ToList();
                //Console.WriteLine(InventoryList.Count);

                //Print out the inventory for the location
                foreach (Inventory obj in InventoryList)
                {
                    obj.PrintInfo();
                }
                Console.WriteLine("Add new product to the order?\nY for yes\nN for no");
                while (true)
                {
                    newResponse = Console.ReadKey(false).Key;
                    Console.WriteLine();
                    if (newResponse == ConsoleKey.Y)
                    {
                        order = AddToOrder(order);
                        break;
                    }
                    else if (newResponse == ConsoleKey.N)
                    {
                        break;
                    }
                }
                //Prints out the order in it's current state
                order.PrintInfo();
                Console.WriteLine("Do you wish to submit this order?\nY for yes\nN for no\nEscape to cancel order");
                while(true)
                {
                    newResponse = Console.ReadKey(false).Key;
                    if (newResponse == ConsoleKey.Y)
                    {
                        //Checks to see if the order has no products added
                        if (order.Products.Count < 1)
                        {
                            Console.WriteLine("Order does not have any products added. Add products to submit.");
                            break;
                        }

                        return order;
                    }
                    else if (newResponse == ConsoleKey.N)
                    {

                        break;
                    }
                    if(newResponse == ConsoleKey.Escape)
                    {
                        return null;
                    }
                } 
            } while (newResponse != ConsoleKey.Escape);
            return null;
        }
        /// <summary>
        /// Adds a product to the order
        /// </summary>
        /// <param name="order">Order to be added to</param>
        /// <returns>Order with a product added to it</returns>
        public Order AddToOrder(Order order)
        {
            OrderProduct check = new OrderProduct();
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Enter Product ID: ");
                    temp = Console.ReadLine();
                    if (Regex.IsMatch(temp, InputPrompts.idPattern)) break;
                    Console.WriteLine("Invalid id. Use only numbers.");
                }
                newProduct = db.Products.FirstOrDefault(x => x.ID == Int32.Parse(temp));
                if (newProduct != null) break;
                else
                {
                    Console.WriteLine("Product ID not found. Nothing added.");
                    return null;
                }
            }
            while(true)
            {
                Console.WriteLine("Enter quantity: ");
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, InputPrompts.quantityPattern)) break;
                Console.WriteLine("Invalid id. Use only numbers.");
            }
            int newQuantity = Int32.Parse(temp);

            var dbInventory = db.Inventory.Include("Product").Include("Location").FirstOrDefault(x => x.Product == newProduct && x.Location == newLocation);
            if (dbInventory != null)
            {
                check = order.checkExists(newProduct);
                if (check != null)
                {
                    newQuantity = newQuantity + check.Quantity;
                }
                if(dbInventory.Quantity >= newQuantity)
                {
                    order.AddToOrder(newProduct, newQuantity);
                    Console.WriteLine("Added to Order.");
                    return order;
                }
            }
            Console.WriteLine("Not enough inventory to add to order. Nothing added to order.");
            return order;
        }
        #endregion
        #region Searching and Displaying
        /// <summary>
        /// Method to search through all <c>Customer</c> objects
        /// </summary>
        /// <returns>
        /// A list of <c>Customer</c> objects from the database. If not found, returns null
        /// </returns>
        public List<Customer> CustomerSearch()
        {
            newCustomer = new Customer();


            newCustomer.FirstName = InputPrompts.FirstNamePrompt();
            newCustomer.LastName = InputPrompts.LastNamePrompt();

            var dbCustomerSearch = db.Customers.Where(x => x.FirstName == newCustomer.FirstName && x.LastName == newCustomer.LastName).ToList();
            return dbCustomerSearch;
        }
        /// <summary>
        /// Method to search for all orders made for a <c>Customer</c>
        /// </summary>
        /// <returns>
        /// A list of <c>Order</c> objects
        /// </returns>
        public List<Order> CustomerOrderList()
        {
            newOrder = new Order();
            int tempid;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Enter Customer ID: ");
                    temp = Console.ReadLine();
                    if (Regex.IsMatch(temp, InputPrompts.idPattern)) break;
                    Console.WriteLine("Invalid id. Use only numbers.");
                }
                tempid = Int32.Parse(temp);
                newCustomer = db.Customers.FirstOrDefault(x => x.ID == tempid);
                if (newCustomer != null) break;
                else
                {
                    Console.WriteLine("Customer ID not found. Use the customer search to find a customer by their first and last name. \nReturning to main menu.");
                    return null;
                }
            }
            var dbOrder = db.Orders.Include("Customer").Include("Location").Where(x => x.Customer.ID == tempid).ToList();
            if(dbOrder.Count>0)
            {
                foreach(Order obj in dbOrder)
                {
                    orderProductList = db.OrderProducts.Include("Order").Include("Product").Where(x => x.Order.ID == obj.ID).ToList();
                    if(orderProductList != null)
                    {
                        obj.Products = orderProductList;
                    }
                }

                return dbOrder;
            }
            else
            {
                Console.WriteLine("No orders exist for this customer.");
                return null;
            }
        }
        /// <summary>
        /// Method to search for all orders made at a <c>Location</c>
        /// </summary>
        /// <returns>
        /// A list of <c>Order</c> objects
        /// </returns>
        public List<Order> LocationOrderList()
        {
            newOrder = new Order();
            int tempid;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Enter Location ID: ");
                    temp = Console.ReadLine();
                    if (Regex.IsMatch(temp, InputPrompts.idPattern)) break;
                    Console.WriteLine("Invalid id. Use only numbers.");
                }
                tempid = Int32.Parse(temp);
                newLocation = db.Locations.FirstOrDefault(x => x.ID == tempid);
                if (newLocation != null) break;
                else
                {
                    Console.WriteLine("Location not found. Enter a valid location ID.");
                    return null;
                }
            }
            var dbOrder = db.Orders.Include("Customer").Include("Location").Where(x => x.Location.ID == tempid).ToList();
            if (dbOrder.Count>0)
            {
                foreach (Order obj in dbOrder)
                {
                    orderProductList = db.OrderProducts.Include("Order").Include("Product").Where(x => x.Order.ID == obj.ID).ToList();
                    if (orderProductList != null)
                    {
                        obj.Products = orderProductList;
                    }
                }

                return dbOrder;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region System Control
        /// <summary>
        /// Method to pause operation and clear console
        /// </summary>
        public void PressAnyKey()
        {
            //Idea from Michael Wong's code
            //Empty prompt to pause operation and clear console
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Seeder Methods

        public void SeedDB()
        {
            AddNewLocations();
            AddNewProducts();
            AddNewCustomers();
        }
        public Location CreateLocation(string name) {

            Location newloc = new Location();
            if (Regex.IsMatch(name, InputPrompts.locationPattern))
            {
                newloc.Name = name;
                return newloc;
            }
            return null;
        }

        public Product CreateProduct(string name, string description, string price)
        {
            Product prod = new Product();
            if (
                Regex.IsMatch(name, InputPrompts.productPattern) && 
                Regex.IsMatch(description, InputPrompts.productPattern) &&
                Regex.IsMatch(price, InputPrompts.pricePattern))
            {
                prod.ProductName = name;
                prod.ProductDescription = description;
                prod.Price = Convert.ToDecimal(price);
                return prod;
            }
            return null;
        }

        public Customer CreateCustomer(
            string fname, string lname, string addr1, string addr2, string city, string state, string zip, string phone, string email)
        {
            Customer cust = new Customer();
            if(
                Regex.IsMatch(fname, InputPrompts.namePattern) &&
                Regex.IsMatch(lname, InputPrompts.namePattern) &&
                Regex.IsMatch(addr1, InputPrompts.address1Pattern) &&
                Regex.IsMatch(addr2, InputPrompts.address2Pattern) &&
                Regex.IsMatch(city, InputPrompts.cityPattern) &&
                InputPrompts.stateAbbreviations.Contains(state.ToUpper()) &&
                Regex.IsMatch(zip, InputPrompts.zipPattern) &&
                Regex.IsMatch(phone, InputPrompts.phonePattern) &&
                Regex.IsMatch(email, InputPrompts.emailPattern))
            {
                cust.FirstName = fname;
                cust.LastName = lname;
                cust.AddressLine1 = addr1;
                cust.AddressLine2 = addr2;
                cust.City = city;
                cust.State = state.ToUpper();
                cust.ZipCode = zip;
                cust.Phone = "(" + phone.Substring(0, 3) + ")" + phone.Substring(3, 3) + "-" + phone.Substring(6);
                cust.Email = email;
                return cust;
            }
            return null;
        }

        public void AddNewLocations()
        {
            string[] names = { "New York", "Boston", "Chicago", "Washington D.C." };
            List<Location> locationsList = new List<Location>();
            foreach(string nm in names)
            {
                locationsList.Add(CreateLocation(nm));
            }
            foreach(Location loc in locationsList)
            {
                try
                {
                    if(loc!=null) db.Add(loc);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"Error in adding location to db:\n{e}.");
                }
            }
            try
            {
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Error in saving changes to the db:\n{e}.");
            }
        }


        public void AddNewProducts()
        {
            string[] names =
            {
                "Road Cycle",
                "Mountain Bike",
                "Beach Cruiser",
                "Triathalon Cycle"
            };
            string[] descriptions =
            {
                "A high-performance cycle for long rides",
                "A robust off-road bike for trail riding",
                "A simple, heavy bike perfect for casual rides",
                "A light-weight bike for use in triathalons"
            };

            string[] prices =
            {
                "1499.99",
                "999.99",
                "299.99",
                "799.99"
            };
            List<Product> prodlist = new List<Product>();
            for (int i = 0; i < names.Length; i++)
            {
                prodlist.Add(CreateProduct(names[i], descriptions[i], prices[i]));
            }

            foreach (Product prod in prodlist)
            {
                try
                {
                    if (prod != null) db.Add(prod);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"Error in adding products to the db:\n{e}");
                }
            }
            try
            {
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Error in adding products to the db:\n{e}");
            }
        }


        public void AddNewCustomers()
        {
            string[] fnames =
            {
            "Mike",
            "Steve",
            "Sally",
            "Carly"
            };
            string[] lnames =
            {
            "Jones",
            "Smith",
            "Peters",
            "Caruthers"
            };

            string[] addr1s =
            {
            "123 Birch Ln.",
            "7754 Huntington St.",
            "890 Little Rd.",
            "400 Main St."
            };

            string[] addr2s =
            {
            "Apt 24",
            "",
            "Unit 400",
            "Number 7"
            };

            string[] cities =
            {
            "New York",
            "Baltimore",
            "Aurora",
            "New Jersey"
            };

            string[] states =
            {
            "NY",
            "MD",
            "IL",
            "NJ"
            };

            string[] zips =
            {
            "76565",
            "99876",
            "22343",
            "44323"
            };

            string[] phones =
            {
            "2223334444",
            "5556787654",
            "4335432234",
            "2432232453"
            };

            string[] emails =
            {
            "mike@jones.com",
            "steve@smith.com",
            "sally@peters.com",
            "carly@caruthers.com"
            };

            List<Customer> custlist = new List<Customer>();
            for (int i = 0; i < fnames.Length; i++)
            {
                custlist.Add(CreateCustomer(
                    fnames[i],
                    lnames[i],
                    addr1s[i],
                    addr2s[i],
                    cities[i],
                    states[i],
                    zips[i],
                    phones[i],
                    emails[i]));
            }

            foreach (Customer cust in custlist)
            {
                try
                {
                    if (cust != null) db.Add(cust);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"Error in adding products to the db:\n{e}");
                }
            }
            try
            {
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Error in adding products to the db:\n{e}");
            }

        }
        public void test()
        {
            var newQuery = db.Inventory.Include("Product").Include("Location").ToList();


            foreach (var obj in newQuery)
            {
                Console.WriteLine(obj.ToString());
            }
        }
        #endregion
    }
}
