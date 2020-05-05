using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Project0
{
	/// <summary>
	/// A <c>Product</c> class to conain information about the products in the store
	/// </summary>
    public class Product : IEquatable<Product>, ITableObject
    {
		private int _ID;
		/// <summary>
		/// ID property
		/// </summary>
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _ProductName;
		/// <summary>
		/// Product Name Property
		/// </summary>
		public string ProductName
		{
			get { return _ProductName; }
			set { _ProductName = value; }
		}

		private string _ProductDescription;
		/// <summary>
		/// Product Name Property
		/// </summary>
		public string ProductDescription
		{
			get => _ProductDescription;
			set => _ProductDescription = value;
		}

		private decimal _Price;
		/// <summary>
		/// Price Property
		/// </summary>
		public decimal Price
		{
			get { return _Price; }
			set { _Price = value; }
		}
		/// <summary>
		/// No argument constructor
		/// </summary>
		public Product() { }


		/// <summary>
		/// Overrides the ToString method to give custom formatting
		/// </summary>
		/// <returns>
		/// A string with the <c>Product</c> information
		/// </returns>
		public override string ToString()
		{
			return "*****************\nProduct ID: " + ID + "\nName: " + ProductName + "\nProduct Description: " + ProductDescription + "\nProduct Price: " + Price + "\n*****************";
		}
		/// <summary>
		/// Overrides the Equals Method
		/// Calls another overridden equals method and passes an  determines if it is the same type
		/// </summary>
		/// <param name="obj">An object to check to see if it matches</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Product objAsProduct)) return false;
			else return Equals(objAsProduct);
		}
		/// <summary>
		/// Overrides this method to return the ID property
		/// </summary>
		/// <returns>
		/// An int that is the ID of the object
		/// </returns>
		public override int GetHashCode()
		{
			return ID;

			
		}
		/// <summary>
		/// Overrides the Equals method to perform a check
		/// If the ID of this object matches, it is considered equal
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(Product other)
		{
			if (other == null) return false;
			return (this.ID.Equals(other.ID));
		}
		/// <summary>
		/// Prints out the Product information with customer formatting
		/// </summary>
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



		
	}
}
