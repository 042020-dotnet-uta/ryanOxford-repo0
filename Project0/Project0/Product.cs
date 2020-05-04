using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Project0
{
    public class Product : IEquatable<Product>, ITableObject
    {
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _ProductName;

		public string ProductName
		{
			get { return _ProductName; }
			set { _ProductName = value; }
		}

		private string _ProductDescription;

		public string ProductDescription
		{
			get => _ProductDescription;
			set => _ProductDescription = value;
		}

		private decimal _Price;

		public decimal Price
		{
			get { return _Price; }
			set { _Price = value; }
		}


		public override string ToString()
		{
			return "*****************\nProduct ID: " + ID + "\nName: " + ProductName + "\nProduct Description: " + ProductDescription + "\nProduct Price: " + Price + "\n*****************";
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

		public void PrintInfo()
		{
			string[] titles = { "Product", "Description", "Price" };
			string[] data = { ProductName, ProductDescription, Price.ToString("0.00") };
			Console.WriteLine("***************************");
			for (int i = 0; i < titles.Length; i++)
			{
				Console.WriteLine("{0,-20} {1,-20}", titles[i], data[i]);
			}
			Console.WriteLine("***************************");
		}



		public Product() { }
	}
}
