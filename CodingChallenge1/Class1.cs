using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge1
{
    class SweetSalty
    {
        private int _sweetCount;
        private int _saltyCount;
        private int _comboCount;

        public SweetSalty()
        {
            _sweetCount = 0;
            _saltyCount = 0;
            _comboCount = 0;
        }

        public string TasteTest(int num)
        {
            if (num % 5 == 0 && num % 3 == 0)
            {
                _comboCount++;
                return "Sweet'nSalty";
            }
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
            else
            {
                return num.ToString();
            }
        }

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
