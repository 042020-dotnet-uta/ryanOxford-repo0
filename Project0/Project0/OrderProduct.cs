using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class OrderProduct: IEquatable<OrderProduct>
    {
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private Order _Order;

		public Order Order
		{
			get { return _Order; }
			set { _Order = value; }
		}
		private Product _Product;

		public Product Product
		{
			get { return _Product; }
			set { _Product = value; }
		}
		private int _Quantity;

		public int Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}

		public override string ToString()
		{
			return "Item ID: " + ID + "Order: " + Order.ID + " Name: " + Product.ProductName + " Quantity: " + Quantity;
		}
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is OrderProduct objAsProduct)) return false;
			else return Equals(objAsProduct);
		}
		public override int GetHashCode()
		{
			return ID;


		}

		public bool Equals(OrderProduct other)
		{
			if (other == null) return false;
			return (this.Order.ID.Equals(other.Order.ID))&&(this.Product.ID.Equals(other.Product.ID));
		}
		public OrderProduct() { }

		public OrderProduct(Order order, Product product, int quant)
		{
			Order = order;
			Product = product;
			Quantity = quant;
		}

	}
}
