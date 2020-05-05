using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// An interface for object classes
    /// Requires they have a PrintInfo() method to print out information about their objects
    /// </summary>
    interface ITableObject
    {
        /// <summary>
        /// Required Method to Print Object Info
        /// </summary>
        void PrintInfo();
    }
}
