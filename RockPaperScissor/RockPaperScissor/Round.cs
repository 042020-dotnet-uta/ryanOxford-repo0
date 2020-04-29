using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissor
{

    public class Round
    {
        public int RoundId { get; set; }
        public static Random rand = new Random();
        public static String[] convert = { "rock", "paper", "scissor" };
        public readonly int p1Choice;
        public readonly int p2Choice;
        public readonly int roundCount;
        public readonly int result;

        public Round() { }
        public Round(int n)
        {
            p1Choice = GenerateRPS();
            p2Choice = GenerateRPS();
            result = decideRoundOutcome();
            roundCount = n;
        }

        //Generate a random integer between 0 and 2
        //0 - Rock
        //1 - Paper
        //2 - Scissors
        //Use convert string array with associated integer to access string name
        static int GenerateRPS()
        {
            return rand.Next(3);
        }

        //Assigns the Player's choices, either a 0, 1, or 2
        //Rock      - 0
        //Paper     - 1
        //Scissors  - 2

        //Returns an integer that represents the outcome of the round
        //1     - win
        //0     - tie
        //-1    - loss
        public int decideRoundOutcome()
        {
            
            if (p1Choice != p2Choice)
            {

                //If there is no tie, check to see who wins and then write the round result to the console
                if (p1Choice + 1 == p2Choice //Rock loses to  Paper or Paper loses to Scissors
                || p2Choice + 2 == p1Choice)
                { //Scissors loses to Rock
                    return -1;

                }
                else
                {
                    return 1;
                }
            }
            //If there is a tie, write the result to the console and increment the ties variable
            else
            {

                return 0;
            }
        }


    }
}
