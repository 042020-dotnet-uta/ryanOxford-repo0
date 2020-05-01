using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Project0
{
    class Product : IEquatable<Product>
    {
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _productName;

		public string ProductName
		{
			get { return _productName; }
			set { _productName = value; }
		}
		private decimal _Price;

		public decimal Price
		{
			get { return _Price; }
			set { _Price = value; }
		}


		public override string ToString()
		{
			return "Product ID: " + ID + " Name: " + ProductName;
		}
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Product objAsProduct)) return false;
			else return Equals(objAsProduct);
		}
		public override int GetHashCode()
		{
			return ID;

			
		}

		public bool Equals(Product other)
		{
			if (other == null) return false;
			return (this.ID.Equals(other.ID));
		}

		public Product() { }
	}
}
