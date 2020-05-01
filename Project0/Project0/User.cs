using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
	class User
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private int _UserTypeID;

		public int UserTypeID
		{
			get { return _UserTypeID; }
			set { _UserTypeID = value; }
		}
		private string _firstName;

		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}
		private string _lastName;

		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		private string _Password;

		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
		}

		public User() { }
	}
}
