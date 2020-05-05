using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
	/// <summary>
	/// An <c>Inventory</c> class that holds the information of an inventory item
	/// </summary>
    public class Inventory : IEquatable<Inventory>, ITableObject
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
		/// <c>Location</c> Property
		/// </summary>
		public Location Location
		{
			get { return _Location; }
			set { _Location = value; }
		}
		private Product _Product;
		/// <summary>
		/// <c>Product</c> property
		/// </summary>
		public Product Product
		{
			get { return _Product; }
			set { _Product = value; }
		}
		private int _Quantity;
		/// <summary>
		/// Quantity property
		/// </summary>
		public int Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}
        /// <summary>
        /// No argument constructor
        /// </summary>
        #endregion

        #region Constructors
        public Inventory() 
		{
		}
        #endregion

        #region Methods
        /// <summary>
        /// Overrides the Equals method. Determines if an object is of the same type
        /// </summary>
        /// <param name="obj">An object to check against</param>
        /// <returns>A boolean that represents if the object matches</returns>
        public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Inventory objAsProduct)) return false;
			else return Equals(objAsProduct);
		}
		/// <summary>
		/// Overrides the GetHashCode method
		/// </summary>
		/// <returns>An int that is the inventory ID</returns>
		public override int GetHashCode()
		{
			return ID;


		}
		/// <summary>
		/// Overrides the Equals method
		/// </summary>
		/// <param name="other">An object to compare to</param>
		/// <returns>A boolean if it matches. If the ID matches, it is considered equal.</returns>
		public bool Equals(Inventory other)
		{
			if (other == null) return false;
			return (this.Location.ID.Equals(other.Location.ID)&&this.Product.ID.Equals(other.Product.ID));
		}
		/// <summary>
		/// Overriding the ToString method for customer formatting
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string product;
			string location;
			if(Location != null)
			{
				location = Location.ToString();
			}
			else
			{
				location = "Location is null";
			}
			if (Product != null)
			{
				product = Product.ToString();
			}
			else
			{
				product = "Product is null";
			}
			return "*****************\nID: "+ ID +  "\nLocation: " + location + "\nProduct: " + product + "\n*****************";
		}
		/// <summary>
		/// Prints the information in a customer format
		/// </summary>
		public void PrintInfo()
		{
			string[] titles = { "Location", "Product ID","Product","Quantity"  };
			string[] data = { Location.Name, Product.ID.ToString(), Product.ProductName, Quantity.ToString() };

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
