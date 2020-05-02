using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Project0
{
    class Customer
    {
		//Property Declarations
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _FirstName;

		public string FirstName
		{
			get { return _FirstName; }
			set { _FirstName = value; }
		}
		private string _LastName;

		public string LastName
		{
			get { return _LastName; }
			set { _LastName = value; }
		}
		private string _AddressLine1;

		public string AddressLine1
		{
			get { return _AddressLine1; }
			set { _AddressLine1 = value; }
		}
		private string _AddressLine2;

		public string AddressLine2
		{
			get { return _AddressLine2; }
			set { _AddressLine2 = value; }
		}
		private string _city;

		public string City
		{
			get { return _city; }
			set { _city = value; }
		}
		private string _State;

		public string State
		{
			get { return _State; }
			set { _State = value; }
		}
		private string _Phone;

		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

		private string _ZipCode;

		public string ZipCode
		{
			get { return _ZipCode; }
			set { _ZipCode = value; }
		}
		private string _Email;

		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}

		public Customer() { }

		public void PrintCustomerInfo()
		{
			string[] titles = { "First name", "Last Name", "Address Line 1", "Address Line 2", "City", "State", "Zip Code", "Phone" };
			string[] data = { FirstName, LastName, AddressLine1, AddressLine2, City, State, ZipCode, Phone };
			Console.WriteLine("***************************");
			for(int i = 0; i < titles.Length; i++)
			{
				Console.WriteLine("{0,-20} {1,-20}", titles[i],data[i]);
			}
			Console.WriteLine("***************************");
		}

	}
}
