using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.VisualBasic.CompilerServices;
using System;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissor
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                Game game = serviceProvider.GetService<Game>();
                game.Start();

            }

            #region old code
            /*
            //Declare variables                           
            //users and scores stored in arrays
            //integer variable for round count and the tie count
            //convert array for rock paper and scissors to convert choice int to a string
            String[] user = new String[2];
            int[] scores =  new int[2];
            int roundcount = 1;
            int ties = 0;
            String[] convert = {"rock", "paper", "scissor"};


            //Prompt the console to enter names for the players
            Console.Write("Player 1 name: ");
            user[0] = Console.ReadLine();
            Console.Write("Player 2 name: ");
            user[1] = Console.ReadLine();
            

            //start of the loop to iterate each round of the game

            do {
                //declare a choice array to hold the choice of the players for the round. Uses a method to generate a random integer between 0 and 2
                int[] choice = new int[2];
                choice[0] = GenerateRPS();
                choice[1] = GenerateRPS();

                //If statement to check if there is a tie    
                if(choice[0] != choice[1]){

                    //If there is no tie, check to see who wins and then write the round result to the console
                    if(choice[0] + 1 == choice[1] //Rock loses to  Paper or Paper loses to Scissors
                    || choice[1] + 2 == choice[0]){ //Scissors loses to Rock
                        scores[1]++;
                        Console.WriteLine($"Round {roundcount}: {user[0]}: {convert[choice[0]]} {user[1]}: {convert[choice[1]]} Winner: {user[1]}");

                    }
                    else {
                        scores[0]++;
                        Console.WriteLine($"Round {roundcount}: {user[0]}: {convert[choice[0]]} {user[1]}: {convert[choice[1]]} Winner: {user[0]}");
                    }    
                }
                //If there is a tie, write the result to the console and increment the ties variable
                else{
                    Console.WriteLine($"Round {roundcount}: {user[0]}: {convert[choice[0]]} {user[1]}: {convert[choice[1]]} Winner: Tie");
                    ties++;
                    
                }
                //Increment the round count
                roundcount++;
            } while (scores[0]<2 && scores[1]<2);

            //Write to the console the winner and the number of ties
            string tieSyntax = "";
            if(ties == 1)
            {
                tieSyntax = "tie";
            }
            else
            {
                tieSyntax = "ties";
            }
            if(scores[0] == 2){
                Console.WriteLine($"Winner is {user[0]} with {ties} {tieSyntax}.");
            }
            else{
                Console.WriteLine($"Winner is {user[1]} with {ties} {tieSyntax}.");
            }
        }

        static Random rand = new Random();


        //Generate a random integer between 0 and 2
        //0 - Rock
        //1 - Paper
        //2 - Scissors
        static int GenerateRPS()
        {
            return rand.Next(3);
        }
        */
            #endregion
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole()).AddTransient<Game>();
        }
    }
}

