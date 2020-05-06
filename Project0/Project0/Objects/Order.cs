using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Project0
{
	/// <summary>
	/// The <c>Order</c> class
	/// Used to hold all the information about an order
	/// </summary>
    public class Order : ITableObject
    {
        #region Properties
        private int _ID;
		/// <summary>
		/// ID Property
		/// </summary>
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private Location _Location;
		/// <summary>
		/// Location Property
		/// </summary>
		public Location Location
		{
			get { return _Location; }
			set { _Location = value; }
		}

		private Customer _Customer;
		/// <summary>
		/// Customer Property
		/// </summary>
		public Customer Customer 
		{
			get { return _Customer; }
			set { _Customer = value; }
		}

		private DateTime _orderCompleteTime;
		/// <summary>
		/// OrderCompleTime Property
		/// </summary>
		public DateTime OrderCompleteTime
		{
			get { return _orderCompleteTime; }
			set { _orderCompleteTime = value; }
		}

		/// <summary>
		/// List of Products contained in the order
		/// </summary>
		public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();

        #endregion

        #region Constructors
        /// <summary>
        /// No argument constructor
        /// </summary>
        public Order() {}
		/// <summary>
		/// Two argument constructor
		/// </summary>
		/// <param name="NewCustomer">A <c>Customer</c> Object</param>
		/// <param name="NewLocation">A <c>Location</c> Object</param>
		public Order(Customer NewCustomer, Location NewLocation)
		{
			Customer = NewCustomer;
			Location = NewLocation;
		}
        #endregion

        #region Methods
        /// <summary>
        /// Checks the order to see if a product exists in it
        /// </summary>
        /// <param name="newProd">A <c>Product</c> object</param>
        /// <returns></returns>
        public OrderProduct checkExists(Product newProd)
		{
			if (newProd == null || !(newProd is Product))
			{
				return null;
			}
			foreach (OrderProduct op in this.Products)
			{
				if (op.Product.Equals(newProd))
				{
					return op;
				}
			}
			return null;
		}

		/// <summary>
		/// A method to add a product to the order
		/// </summary>
		/// <param name="newProd"> A <c>Product</c> object</param>
		/// <param name="quant">An int representing the quantity to add</param>
		/// <returns>A boolean value to represent success</returns>
		public bool AddToOrder(Product newProd, int quant = 1)
		{

			if (newProd == null) return false;
			if (!(newProd is Product)) return false;
			foreach (OrderProduct op in this.Products)
			{
				if (op.Product.Equals(newProd))
				{
					op.Quantity += quant;
					return true;
				}
			}
			this.Products.Add(new OrderProduct(this,newProd,quant));
			return true;

		}
		/// <summary>
		/// A method to delete a <c>Product</c> from the order
		/// </summary>
		/// <param name="newProd">A <c>Product</c> object</param>
		/// <returns>A boolean value to represent success</returns>
		public bool DeleteFromOrder(Product newProd)
		{
			if (newProd == null) return false;
			if (!(newProd is Product)) return false;
			foreach (OrderProduct op in this.Products)
			{
				if (op.Product.Equals(newProd))
				{
					Products.Remove(op);
					return true;
				}
			}
			Console.WriteLine($"Product {newProd.ID} not found. Nothing was deleted from the order.");
			return false;
		}
		/// <summary>
		/// A method to update the quantity of a <c>Product</c> on the order
		/// </summary>
		/// <param name="newProd">A <c>Product</c> object</param>
		/// <param name="newQuant">An int representing the quantity to add</param>
		/// <returns></returns>
		public bool UpdateQuantity(Product newProd, int newQuant)
		{
			if (!(newProd is Product)) return false;
			foreach(OrderProduct op in this.Products)
			{
				if (op.Product.Equals(newProd))
				{
					op.Quantity = newQuant;
					return true;
				}
			}
			Console.WriteLine($"Product {newProd.ID} not found. Quantity not updated, product not in order.");
			return false;
		}
		/// <summary>
		/// A method to print the info about the <c>Order</c>
		/// </summary>
		public void PrintInfo()
		{
			string start = "START OF ORDER";
			string end = "END OF ORDER";
			int formWidth = 45;
			start = BorderFormats(start, formWidth);
			end = BorderFormats(end, formWidth);
			string tempID;
			decimal total = 0;

			if (ID < 1)
			{
				tempID = "";
			}
			else
			{
				tempID = ID.ToString();
			}
			string tempTime;
			if (OrderCompleteTime == null)
			{
				tempTime = "";
			}
			else
			{
				tempTime = OrderCompleteTime.ToString("g", DateTimeFormatInfo.InvariantInfo);
			}
			Console.WriteLine(start);
			string[] titles = {"ID", "Customer Name", "Customer ID", "Location", "Location ID", "Order Completed"};
			string[] data = {tempID, Customer.FirstName + " " + Customer.LastName, Customer.ID.ToString(), Location.Name,Location.ID.ToString(), tempTime};
			string[] stars = { "*", "*", "*", "*", "*", "*" };
			for (int i = 0; i < titles.Length; i++)
			{
				Console.WriteLine("{0,-1} {1,-20} {2,-20} {3,1}", stars[i], titles[i], data[i], stars[i]);
			}
			string starstring = "";
			for(int i = 0; i < formWidth; i++)
			{
				starstring += "*";
			}
			Console.WriteLine(starstring);
			Console.WriteLine("{0,-1} {1,-20} {2,5} {3,14} {4,1}", "", "Product Name", "Qty", "Price","");
			Console.WriteLine(starstring);
			foreach(var obj in Products)
			{
				total = total + obj.Product.Price*obj.Quantity;
				Console.WriteLine("{0,-1} {1,-20} {2,5} {3,14} {4,1}", "*", obj.Product.ProductName, obj.Quantity,obj.Product.Price, "*");
			}
			Console.WriteLine(starstring);
			Console.WriteLine("{0,-1} {1,-15} {2,25} {3,1}", "", "Total Cost",total,"");

			Console.WriteLine(end);
			Console.WriteLine("\n\n\n");
		}
		/// <summary>
		/// A formatting helper method to adjust the upper and lower borders of the console print of the order
		/// It inserts a name into the center of the border
		/// </summary>
		/// <param name="str">Name to be imbedded in the border</param>
		/// <param name="len">Length of characters of the border</param>
		/// <returns></returns>
		public string BorderFormats(string str, int len)
		{
			if (len > str.Length) {
				int half = (len - str.Length) / 2;
				for(int i = 0; i < half; i++)
				{
					str = "*" + str;
				}
				while (str.Length < len)
				{
					str = str + "*";
				}
			}
			return str;
		}
		#endregion
	}
}
