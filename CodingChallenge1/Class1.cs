using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge1
{
    class SweetSalty
    {
        //Declare Class Variables
        private int _sweetCount;
        private int _saltyCount;
        private int _comboCount;

        //No Argument Constructor. Establish count numbers;
        public SweetSalty()
        {
            _sweetCount = 0;
            _saltyCount = 0;
            _comboCount = 0;
        }

        //Method to evaluate a number and return a string based on it's "Taste"
        public string TasteTest(int num)
        {
            //first check to see if both conditions are met. Return a combo and increment count
            if (num % 5 == 0 && num % 3 == 0)
            {
                _comboCount++;
                return "Sweet'nSalty";
            }
            //Check individual conditions and increment counts
            else if (num % 5 == 0)
            {
                _saltyCount++;
                return "Salty";
            }
            else if (num % 3 == 0)
            {
                _sweetCount++;
                return "Sweet";
            }
            //Convert the integer to a string to return
            else
            {
                return num.ToString();
            }
        }

        //With an end number as a parameter, method to count from 1 to the end and print to console the result of the TasteTest Method. Prints out the counts at the end.
        public void PrintResults(int end)
        {
            int i = 1;
            while (i <= end)
            {
                Console.WriteLine(TasteTest(i));
                i++;
            }
            Console.WriteLine($"There are {_sweetCount} sweet, {_saltyCount} salty, and {_comboCount} Sweet'nSalty.");
        }
    }
}
