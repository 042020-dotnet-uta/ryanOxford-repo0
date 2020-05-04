using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Project0
{
    public class Order : ITableObject
    {
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private Location _Location;

		public Location Location
		{
			get { return _Location; }
			set { _Location = value; }
		}

		private Customer _Customer;

		public Customer Customer 
		{
			get { return _Customer; }
			set { _Customer = value; }
		}

		private DateTime _orderCompleteTime;

		public DateTime OrderCompleteTime
		{
			get { return _orderCompleteTime; }
			set { _orderCompleteTime = value; }
		}


		public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();
		public Order() {}

		public Order(Customer NewCustomer, Location NewLocation)
		{
			Customer = NewCustomer;
			Location = NewLocation;
		}
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

		public void PrintInfo()
		{
			string start = "START OF ORDER";
			string end = "END OF ORDER";
			int formWidth = 45;
			start = BorderFormats(start, formWidth);
			end = BorderFormats(end, formWidth);
			string tempID;

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
			Console.WriteLine("{0,-1} {1,-20} {2,-20} {3,1}", "", "Product Name", "Quantity", "");
			Console.WriteLine(starstring);
			foreach(var obj in Products)
			{
				Console.WriteLine("{0,-1} {1,-20} {2,-20} {3,1}", "*", obj.Product.ProductName, obj.Quantity, "*");
			}
			Console.WriteLine(end);
			Console.WriteLine("\n\n\n");
		}
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
	}
}
