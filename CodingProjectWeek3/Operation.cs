using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodingProjectWeek3
{
    public class Operation
    {
        //Declae a ConsoleKey variable to record responses for action triggers. Static so any classes can make use of it.
        public static ConsoleKey response;
        public string[] commands;
        public string[] commandKeys;
        //declare a string to hold inputs from the user
        public string temp;

        //Regex pattern to use in validating the input
        public static string numberPattern = @"^\d{1,}$";
        public void Start()
        {
            //Starting a do while loop to cycle through the options of the program
            do
            {
                //Print out an introduction to the program
                Console.WriteLine("*****************************************");
                Console.WriteLine("Welcome to the program! Use the following keys to execute an action.");
                //Create two string arrays that hold action names with their corresponding key triggers.
                commands = new string[] { "Is the number even?", "Multiplication Table", "Alternating Elements", "Exit Program" };
                commandKeys = new string[] { "1", "2", "3", "ESC" };
                //Use a for loop to print out the commands in the proper format
                for (int i = 0; i < commands.Length; i++)
                {
                    Console.WriteLine("{0,-5} {1,-20}", commandKeys[i], commands[i]);
                }
                //Record the next key press
                response = Console.ReadKey(false).Key;

                if (response == ConsoleKey.D1)
                {
                    //Is the number even section
                    Console.WriteLine(IsTheNumberEven());
                }
                else if (response == ConsoleKey.D2)
                {
                    //Multiplication Table section
                }
                else if (response == ConsoleKey.D3)
                {
                    //Alternating Elements section
                }
            //While exit condition being the Escape key being pressed at the main menu
            } while (response != ConsoleKey.Escape);
        }

        public string IsTheNumberEven()
        {
            Console.WriteLine("Please enter a number");
            temp = Console.ReadLine();
            //Print an extra line to fix the formatting issue with the ReadLine key value
            Console.WriteLine();
            //Use the Regex value to check if the input is a number;
            if (Regex.IsMatch(temp, numberPattern))
            {
                //If the number is valid, it is safe to use the Parse function
                //Use the modulus to determine if the number is even and return a string
                if (Int32.Parse(temp) % 2 == 0)
                {
                    return "Number is even.";
                }
                else
                {
                    return "Number is odd.";
                }
            }
            //If the number is not valid, return a string saying so
            else
            {
                return "Input is not a number.";
            }

        }

        public string MultiplicationTable()
        {
            int x;
            //Use a loop that runs until a break command or return is issued
            while (true)
            {
                Console.WriteLine("Please enter a number");
                temp = Console.ReadLine();
                Console.WriteLine();
                if (Regex.IsMatch(temp, numberPattern))
                {
                    x = Int32.Parse(temp);
                    return $"{x} X {x} = {x * x}";
                }
                //Print to the console that the number is invalid. Since there is no return or break, the loop runs again.
                Console.WriteLine("Invalid number. Please try again using an integer value.");
            }
        }

        public void Shuffle()
        {
            string[] array1 = new string[5];
            string[] array2 = new string[5];
            Console.WriteLine("You will be asked to make two string arrays with 5 elements each");
            for(int i = 0; i < 5, i++)
            {
                Console.WriteLine($"Please enter Element {i} for first array:");
            }
            
        }


    
    }
}
