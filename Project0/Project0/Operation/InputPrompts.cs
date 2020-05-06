using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics.Contracts;

namespace Project0
{
    /// <summary>
    /// A class that holds Input Prompt methods with that use Regex patterns for  input validation
    /// </summary>
    public class InputPrompts
    {
        #region Pattern Declarations
        /// <summary>
        /// Stores the name pattern
        /// </summary>
        public static string namePattern = @"^([a-zA-Z-]{2,30})$";
        /// <summary>
        /// Stores the email pattern
        /// </summary>
        public static string emailPattern = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$";
        /// <summary>
        /// Stores the address line 1 pattern
        /// </summary>
        public static string address1Pattern = @"^([a-zA-Z0-9 .-]{2,50})$";
        /// <summary>
        /// Stores the address line 2 pattern
        /// </summary>
        public static string address2Pattern = @"^([a-zA-Z0-9 .-]{0,50})*$";
        /// <summary>
        /// Stores the city pattern
        /// </summary>
        public static string cityPattern = @"^([a-zA-Z -]{2,30})$";
        /// <summary>
        /// Stores the phone pattern
        /// </summary>
        public static string phonePattern = @"^\d{10}$";
        /// <summary>
        /// Stores the zip code pattern
        /// </summary>
        public static string zipPattern = @"^\d{5}$";
        /// <summary>
        /// Stores the Product name pattern
        /// </summary>
        public static string productPattern = @"^([a-zA-Z0-9 .,-]{0,300})$";
        /// <summary>
        /// Stores the Price pattern
        /// </summary>
        public static string pricePattern = @"^\d{0,8}(\.\d{2})?$";
        /// <summary>
        /// Stores the location pattern
        /// </summary>
        public static string locationPattern = @"^([a-zA-Z-. ]{2,30})$";
        /// <summary>
        /// Stores the ID pattern
        /// </summary>
        public static string idPattern = @"^\d{1,10}$";
        /// <summary>
        /// Stores the quantity pattern
        /// </summary>
        public static string quantityPattern = @"^\d{1,3}$";
        /// <summary>
        /// Stores the list of acceptable state abbreviations
        /// </summary>
        public static string[] stateAbbreviations = {
            "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FM", "FL", "GA",
            "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MH", "MD", "MA",
            "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND",
            "MP", "OH", "OK", "OR", "PW", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT",
            "VT", "VI", "VA", "WA", "WV", "WI", "WY" };

        #endregion
        #region Variable Declaration
        /// <summary>
        /// Temp string to hold inputs for validation
        /// </summary>
        public string temp;
        #endregion
        #region Input Prompt Methods
        #region Prompt Template
        /// <summary>
        /// A method to prompt the user for a value
        /// Loops until the input is validated
        /// </summary>
        /// <param name="prompt">The message to display for the prompt</param>
        /// <param name="pattern">The Regex pattern to use for validation</param>
        /// <param name="error">The message to display if the input validation does not pass</param>
        /// <returns></returns>

        public static string PromptTemplate(string prompt, string pattern, string error) 
        {
            string temp;
            while (true)
            {
                Console.WriteLine(prompt);
                temp = Console.ReadLine();
                if (Regex.IsMatch(temp, pattern)) break;
                Console.WriteLine(error);
            }
            return temp;
        }

        #endregion
        #region Customer Prompts
        //Unique operation, cannot use the template
        /// <summary>
        /// Prompt for State value
        /// </summary>
        /// <returns>
        /// A string with the state Abbreviation
        /// </returns>
        public static string StatePrompt()
        {
            string temp;
            while (true)
            {
                Console.WriteLine("Enter State: ");
                temp = Console.ReadLine();
                if (stateAbbreviations.Contains(temp.ToUpper())) break;
                Console.WriteLine("Invalid State. Please use the two character state abbreviation");
            }
            temp = temp.ToUpper();
            return temp;
        }
        /// <summary>
        /// Prompt for First Name
        /// </summary>
        /// <returns>A string with the First Name</returns>
        public static string FirstNamePrompt()
        {
            string temp;
            temp = PromptTemplate("Enter First name: ", namePattern, "Invalid name. Please use word characters only.");
            return temp;
        }
        /// <summary>
        /// Prompt for Last Name
        /// </summary>
        /// <returns>A string with the Last Name</returns>
        public static string LastNamePrompt()
        {
            string temp;
            temp = PromptTemplate("Enter Last name: ", namePattern, "Invalid name. Please use word characters only.");
            return temp;
        }
        /// <summary>
        /// Prompt for Address Line 1
        /// </summary>
        /// <returns>A string with the Address Line 1</returns>
        public static string Address1Prompt()
        {
            string temp;
            temp = PromptTemplate("Enter Address Line 1: ", address1Pattern, "Invalid Address. Please use alphanumeric characters only.");
            return temp;
        }
        /// <summary>
        /// Prompt for Address Line 2
        /// </summary>
        /// <returns>A string with the Address Line 2</returns>
        public static string Address2Prompt()
        {
            string temp;
            temp = PromptTemplate("Enter Address Line 2: ", address2Pattern, "Invalid Address. Please use alphanumeric characters only.");
            return temp;
        }

        /// <summary>
        /// Propmt for City
        /// </summary>
        /// <returns>A string with the City</returns>
        public static string CityPrompt()
        {
            string temp;
            temp = PromptTemplate("Enter City: ", cityPattern, "Invalid City. Please use alphanumeric characters only.");
            return temp;
        }
        /// <summary>
        /// Prompt for Zip Code
        /// </summary>
        /// <returns>A string with the Zip Code</returns>
        public static string ZipPrompt()
        {
            string temp;
            temp = PromptTemplate("Enter Zip Code: ", zipPattern, "Invalid Zip Code. Please enter 5 digits only.");
            return temp;
        }
        /// <summary>
        /// Prompt for Phone Number
        /// </summary>
        /// <returns>A string with the Phone number in (555)555-5555 format</returns>
        public static string PhonePrompt()
        {
            string temp;
            temp = PromptTemplate("Enter Phone number: ", phonePattern, "Invalid Phone Number. Please enter a 10-digit number with no dashes.");
            temp = "(" + temp.Substring(0, 3) + ")" + temp.Substring(3, 3) + "-" + temp.Substring(6);
            return temp;
        }
        /// <summary>
        /// Prompt for email
        /// </summary>
        /// <returns>A string with the email</returns>
        public static string EmailPrompt()
        {
            string temp;
            temp = PromptTemplate("Enter Email: ", emailPattern, "Invalid Email address. Please try again.");
            return temp;
        }
        #endregion


        #region Product prompts
        /// <summary>
        /// Product Name Prompt
        /// </summary>
        /// <returns>A string with the product name</returns>
        public static string ProductNamePrompt()
        {
            string temp;
            temp = PromptTemplate("Enter Product name: ", productPattern, "Invalid product name. Please use alpha characters and hyphens, periods, and commas only.");
            return temp;
        }
        /// <summary>
        /// Product Description Prompt
        /// </summary>
        /// <returns>A string with the Product Description</returns>
        public static string ProductDescriptionPrompt()
        {
            string temp;
            temp = PromptTemplate("Enter Product description: ", productPattern, "Invalid product description. Please use alpha characters and hyphens, periods, and commas only.");
            return temp;
        }
        /// <summary>
        /// Propmt for Product Price
        /// </summary>
        /// <returns>A decimal value with the price of the product</returns>
        public static decimal ProductPricePrompt()
        {
            string temp;
            temp = PromptTemplate("Enter Product price: ", pricePattern, "Invalid price. Must be a decimal number with 2 decimal places at the end.");
            return Convert.ToDecimal(temp);
        }

        #endregion


        #region ID Prompts
        /// <summary>
        /// Prompt for an ID
        /// Can be used for any ID
        /// </summary>
        /// <param name="type">A string to display which type the ID is for</param>
        /// <returns></returns>
        public static int IDPrompt(string type)
        {
            string temp;
            temp = PromptTemplate($"Enter {type} ID: ", idPattern, "Invalid ID. Use only int values.");
            return Int32.Parse(temp);
        }
        #endregion

        #region Other Prompts
        /// <summary>
        /// Prompt for Quantity
        /// </summary>
        /// <returns>An int for the quantity to be used</returns>
        public static int QuantityPrompt()
        {
            string temp;
            temp = PromptTemplate("Enter quantity: ",quantityPattern, "Invalid quantity. Use int values less than 1000 only.");
            return Int32.Parse(temp);
        }
        #endregion
        #endregion
    }
}

          