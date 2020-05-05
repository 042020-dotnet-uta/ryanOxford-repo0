using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
	/// <summary>
	/// An <c>OrderProduct</c> class to represent products and quantities present on an order
	/// </summary>
    public class OrderProduct: IEquatable<OrderProduct>, ITableObject
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

		private Order _Order;
		/// <summary>
		/// Order Property
		/// </summary>
		public Order Order
		{
			get { return _Order; }
			set { _Order = value; }
		}
		private Product _Product;
		/// <summary>
		/// Product Property
		/// </summary>
		public Product Product
		{
			get { return _Product; }
			set { _Product = value; }
		}
		private int _Quantity;
		/// <summary>
		/// Quantity Property
		/// </summary>
		public int Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}
		#endregion
		#region Constructors
		/// <summary>
		/// No argument constructor
		/// </summary>
		public OrderProduct() { }
		/// <summary>
		/// Constructor with 3 arguments
		/// </summary>
		/// <param name="order"><c>Order</c> object that this exists on</param>
		/// <param name="product"><c>Product</c> contained</param>
		/// <param name="quant">Quantity of the product</param>
		public OrderProduct(Order order, Product product, int quant)
		{
			Order = order;
			Product = product;
			Quantity = quant;
		}
        #endregion
        #region Methods
		/// <summary>
		/// Override ToString method
		/// </summary>
		/// <returns>A string with custom formatting</returns>
        public override string ToString()
		{
			return "Item ID: " + ID + "Order: " + Order.ID + " Name: " + Product.ProductName + " Quantity: " + Quantity;
		}
		/// <summary>
		/// Override method
		/// Checks to see if the object is of this type
		/// </summary>
		/// <param name="obj">Object to be compared</param>
		/// <returns>Boolean representing if the object is of this type</returns>
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is OrderProduct objAsProduct)) return false;
			else return Equals(objAsProduct);
		}
		/// <summary>
		/// Override hash code retrieval
		/// </summary>
		/// <returns>An int that is the object ID</returns>
		public override int GetHashCode()
		{
			return ID;


		}
		/// <summary>
		/// Override method
		/// Checks to see if object matches this one
		/// </summary>
		/// <param name="other">Object to be compared</param>
		/// <returns>Boolean representing whether this object matches. If the Order ID and Product ID match, it is considered equal</returns>
		public bool Equals(OrderProduct other)
		{
			if (other == null) return false;
			return (this.Order.ID.Equals(other.Order.ID))&&(this.Product.ID.Equals(other.Product.ID));
		}
		
		/// <summary>
		/// Method to print out information about the object
		/// </summary>
		public void PrintInfo()
		{
			string[] titles = {"Order ID","Product ID","Product","Quantity"};
			string[] data = { Order.ID.ToString(), Product.ID.ToString(),Product.ProductName,Quantity.ToString() };
			Console.WriteLine("***************************");
			for (int i = 0; i < titles.Length; i++)
			{
				Console.WriteLine("{0,-20} {1,-20}", titles[i], data[i]);
			}
			Console.WriteLine("***************************");
		}
        #endregion
    }
}
