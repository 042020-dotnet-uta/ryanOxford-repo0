using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    public class Location : ITableObject
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
