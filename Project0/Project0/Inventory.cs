using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Project0
{

    class Inventory
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

		public Inventory() { }
		public bool AddToInventory(Product newProd, int quant)
		{
			return true;
		}
	}
}
