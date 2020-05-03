using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Location
    {
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _Name;

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public Location() { }

		public override string ToString()
		{
			return "*****************\nID: " + ID + "\nName: " + Name + "\n*****************";
		}
	}
}
