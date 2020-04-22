using System;

namespace RockPaperScissor
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] user = new String[2];
            int[] scores =  new int[2];
            int roundcount = 1;
            int ties = 0;
            String[] convert = {"rock", "paper", "scissor"};

            console.Write("Player 1 name: ");
            users[0] = console.Readline();
            console.Write("Player 2 name: ");
            users[1] = console.Readline();
            
            do {
                int choice[] = new Int[2];
                choice[0] = GenerateRPS();
                choice[1] = generateRPS();
                if(choice[0] != choice[1]){
                    if(choice[0] + 1 == choice[1] //R - P or P - S
                    || choice[1] + 2 == choice[0]) //S - R
                    {
                        scores[1]++;
                        Console.WriteLine($"Round {roundcount}: {user[0]}: {convert[choice[0]]} 
                        {user[1]}: {convert[choice[1]]} Winner: {user[1]}");

                    }
                    else {
                        scores[0]++;
                        Console.WriteLine($"Round {roundcount}: {user[0]}: {convert[choice[0]]} 
                        {user[1]}: {convert[choice[1]]} Winner: {user[0]}");
                    }    
                }
                else{
                    Console.WriteLine($"Round {roundcount}: {user[0]}: {convert[choice[0]]} 
                        {user[1]}: {convert[choice[1]]} Winner: Tie");
                    ties++;
                    
                }
                roundcount++;
            } while (scores[0]<2 && scores[1]<2);

            if(scores[0] == 2){
                Console.WriteLine($"Winner is {user[0]} with {ties} ties.");
            }
            else{
                Console.WriteLine($"Winner is {user[1]} with {ties} ties.");
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
        static String convertChoice(int choice){
            switch(choice){
                case 0:
                    return "Rock";
                    break;
                case 1:
                    return "Paper";
                    break;
                case 2:
                    return "Scissors";
                    break;
            }
        }
        
        }
    }
}
