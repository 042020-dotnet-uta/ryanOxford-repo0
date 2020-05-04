using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    public class Location : IEquatable<Location>, ITableObject
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

		public override int GetHashCode()
		{
			return ID;


		}
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Location objAsLocation)) return false;
			else return Equals(objAsLocation);
		}
		public bool Equals(Location other)
		{
			if (other == null) return false;
			return (this.ID.Equals(other.ID));
		}


		public Location() { }

		public override string ToString()
		{
			return "*****************\nID: " + ID + "\nName: " + Name + "\n*****************";
		}

		public void PrintInfo()
		{
			string[] titles = { "ID","Location" };
			string[] data = { ID.ToString(),Name };
			Console.WriteLine("***************************");
			for (int i = 0; i < titles.Length; i++)
			{
				Console.WriteLine("{0,-20} {1,-20}", titles[i], data[i]);
			}
			Console.WriteLine("***************************");
		}
	}
}
