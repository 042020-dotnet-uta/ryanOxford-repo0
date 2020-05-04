using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    public class UserType
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

		private string _Description;

		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		public UserType() { }
	}
}
