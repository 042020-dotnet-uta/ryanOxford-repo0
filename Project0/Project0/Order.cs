using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Order
    {
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private User _User;

		public User User
		{
			get { return _User; }
			set { _User = value; }
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
		public Order() { }

		public Order(User NewUser, Customer NewCustomer, Location NewLocation)
		{
			User = NewUser;
			Customer = NewCustomer;
			Location = NewLocation;


		}

		public bool AddToOrder(Product newProd, int quant = 1)
		{

			if (newProd == null) return false;
			if (!(newProd is Product)) return false;
			foreach (OrderProduct op in this.Products)
			{
				if (op.Product.Equals(newProd))
				{
					op.Quantity+=quant;
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

		public void SubmitOrder()
		{
			this.OrderCompleteTime = DateTime.Now;

		}
	}
}
