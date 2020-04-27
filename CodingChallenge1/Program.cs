using System;

namespace CodingChallenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sweetCount = 0;
            int saltyCount = 0; 
            int comboCount = 0;
            for(int i = 0; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("Sweet'nSalty");
                    comboCount++;
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Salty");
                    saltyCount++;
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Sweet");
                    sweetCount++;
                }
                else
                {
                    Console.WriteLine(i);
                }    
            }
            Console.WriteLine($"There are {sweetCount} sweet, {saltyCount} salty, and {comboCount} sweet'nSalty present.");
        }
    }
}
