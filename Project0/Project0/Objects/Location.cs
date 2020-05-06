using System;


namespace Project0
{
	/// <summary>
	/// A <c>Location</c> class to hold info on store locations
	/// </summary>
    public class Location : IEquatable<Location>, ITableObject
    {
        #region Properties
        private int _ID;
		/// <summary>
		/// ID Property
		/// </summary>
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _Name;
		/// <summary>
		/// Name Property
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		#endregion
		#region Constructors
		/// <summary>
		/// No argument constructor
		/// </summary>
		public Location() { }

		#endregion
		#region Methods
		/// <summary>
		/// Overrides the method to return the ID of the object;
		/// </summary>
		/// <returns>An int representing the ID</returns>
		public override int GetHashCode()
		{
			return ID;


		}
		/// <summary>
		/// Overrides to compare an object to one of this class
		/// </summary>
		/// <param name="obj">An object to compare</param>
		/// <returns>A boolean value representing if the object is of this type</returns>
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Location objAsLocation)) return false;
			else return Equals(objAsLocation);
		}
		/// <summary>
		/// Overrides to compare an object to see if it matches
		/// </summary>
		/// <param name="other">An object to compare</param>
		/// <returns>A boolean value representing if the object matches this one. If the ID is the same, it is considered equal</returns>
		public bool Equals(Location other)
		{
			if (other == null) return false;
			return (this.ID.Equals(other.ID));
		}
		/// <summary>
		/// Overrides ToString method
		/// </summary>
		/// <returns>A string with a custom format</returns>
		public override string ToString()
		{
			return "*****************\nID: " + ID + "\nName: " + Name + "\n*****************";
		}
		/// <summary>
		/// A method to print out info about this object
		/// </summary>
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
        #endregion
    }
}
