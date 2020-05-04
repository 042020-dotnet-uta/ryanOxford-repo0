using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    public class Regexvars
    {
        public static string namePattern = @"^([a-zA-Z-]{2,30})$";
        public static string emailPattern = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$";
        public static string address1Pattern = @"^([a-zA-Z0-9 .-]{2,50})$";
        public static string address2Pattern = @"^([a-zA-Z0-9 .-]{0,50})*$";
        public static string cityPattern = @"^([a-zA-Z -]{2,30})$";
        public static string phonePattern = @"^\d{10}$";
        public static string zipPattern = @"^\d{5}$";
        public static string productPattern = @"^([a-zA-Z0-9 .,-]{0,300})$";
        public static string pricePattern = @"^\d{0,8}(\.\d{2})?$";
        public static string locationPattern = @"^([a-zA-Z- ]{2,30})$";
        public static string idPattern = @"^\d{1,10}$";
        public static string quantityPattern = @"^\d{1,3}$";
        public static string[] stateAbbreviations = {
            "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FM", "FL", "GA",
            "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MH", "MD", "MA",
            "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND",
            "MP", "OH", "OK", "OR", "PW", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT",
            "VT", "VI", "VA", "WA", "WV", "WI", "WY" };
    }
}
