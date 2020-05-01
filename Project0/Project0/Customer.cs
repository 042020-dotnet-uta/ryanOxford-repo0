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
		private string _Country;

		public string Country
		{
			get { return _Country; }
			set { _Country = value; }
		}
		private string _ZipCode;

		public string ZipCode
		{
			get { return _ZipCode; }
			set { _ZipCode = value; }
		}
		public Customer() { }
	}
}
