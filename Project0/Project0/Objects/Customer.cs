using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Project0
{
	/// <summary>
	/// A <c>Customer</c> class to contain information about a customer
	/// </summary>
    public class Customer : ITableObject
    {
        #region Properties
        //Property Declarations
        private int _ID;
		/// <summary>
		/// ID property
		/// </summary>
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _FirstName;
		/// <summary>
		/// FirstName Property
		/// </summary>
		public string FirstName
		{
			get { return _FirstName; }
			set { _FirstName = value; }
		}
		private string _LastName;
		/// <summary>
		/// LastName Property
		/// </summary>
		public string LastName
		{
			get { return _LastName; }
			set { _LastName = value; }
		}
		private string _AddressLine1;
		/// <summary>
		/// Address Line 1 Property
		/// </summary>
		public string AddressLine1
		{
			get { return _AddressLine1; }
			set { _AddressLine1 = value; }
		}
		private string _AddressLine2;
		/// <summary>
		/// Address Line 2 Property
		/// </summary>
		public string AddressLine2
		{
			get { return _AddressLine2; }
			set { _AddressLine2 = value; }
		}
		private string _city;
		/// <summary>
		/// City Property
		/// </summary>
		public string City
		{
			get { return _city; }
			set { _city = value; }
		}
		private string _State;
		/// <summary>
		/// State Property
		/// </summary>
		public string State
		{
			get { return _State; }
			set { _State = value; }
		}
		private string _Phone;
		/// <summary>
		/// Phone Number Property
		/// </summary>
		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

		private string _ZipCode;
		/// <summary>
		/// Zip Code Property
		/// </summary>
		public string ZipCode
		{
			get { return _ZipCode; }
			set { _ZipCode = value; }
		}
		private string _Email;
		/// <summary>
		/// Email property
		/// </summary>
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}
        #endregion
        #region Constructors
		/// <summary>
		/// No argument Constructor
		/// </summary>
        public Customer() { }
        #endregion
        #region Methods
		/// <summary>
		/// A method to print out info about the contents of this object
		/// </summary>
        public void PrintInfo()
		{
			string tempID;
			if(ID < 1)
			{
				tempID = "";
			}
			else
			{
				tempID = ID.ToString();
			}
			string[] titles = { "ID","First name", "Last Name", "Address Line 1", "Address Line 2", "City", "State", "Zip Code", "Phone", "Email" };
			string[] data = { tempID, FirstName, LastName, AddressLine1, AddressLine2, City, State, ZipCode, Phone, Email };
			Console.WriteLine("***************************");
			for(int i = 0; i < titles.Length; i++)
			{
				Console.WriteLine("{0,-20} {1,-20}", titles[i],data[i]);
			}
			Console.WriteLine("***************************");
		}
        #endregion
    }
}
