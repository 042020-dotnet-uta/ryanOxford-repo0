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
			if (newProd == null ||!(newProd is Product))
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
			if (OrderCompleteTime != null)
			{
				tempTime = "";
			}
			else
			{
				tempTime = OrderCompleteTime.ToString("f", DateTimeFormatInfo.InvariantInfo);
			}
			string[] titles = { "ID", "Customer Name", "Customer ID", "Location", "Location ID", "Order Completed" };
			string[] data = { tempID, Customer.FirstName + " " + Customer.LastName, Customer.ID.ToString(), Location.Name,Location.ID.ToString(), tempTime};
			Console.WriteLine("***************************");
			for (int i = 0; i < titles.Length; i++)
			{
				Console.WriteLine("{0,-20} {1,-20}", titles[i], data[i]);
			}
			Console.WriteLine("***************************");
			foreach(var obj in Products)
			{
				obj.PrintInfo();
			}
			Console.WriteLine("*********END OF ORDER*********");
		}
	}
}
