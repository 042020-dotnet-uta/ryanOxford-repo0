using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Project0
{

    public class Inventory : IEquatable<Inventory>, ITableObject
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

		public Inventory() 
		{
		}
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Inventory objAsProduct)) return false;
			else return Equals(objAsProduct);
		}
		public override int GetHashCode()
		{
			return ID;


		}
		public bool Equals(Inventory other)
		{
			if (other == null) return false;
			return (this.Location.ID.Equals(other.Location.ID)&&this.Product.ID.Equals(other.Product.ID));
		}
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

	}
}
