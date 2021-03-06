﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissor
{

        //ints correspond to RPS values.
        public enum RPS
        {
            rock,
            paper,
            scissors
        }



        public class Game
        {

            #region Fields and Constructor
            public int GameId { get; set; }
            public readonly Player[] players;
            public readonly List<Round> rounds;           
            public int ties; //Stores number of tie rounds.



        private readonly ILogger _logger;
        public Game(ILogger<Game> logger)
        {
            _logger = logger;
            players = new Player[2];
            rounds = new List<Round>();
            ties = 0;
            PromptPlayerNames(); //Console prompt for player names.
        }

        public Game() { }
            //public Game()
            //{

            //    players = new Player[2];
            //    rounds = new List<Round>();
            //    ties = 0;
            //    PromptPlayerNames(); //Console prompt for player names.

            //}

            #endregion

            #region New Methods

            /*
            Method for getting the player names.
            Writes to console and prompts user input.
            Uses String inputs to instantiate two Player objects.
            */
            public void PromptPlayerNames()
            {
                _logger.LogInformation("LogInformation = Hello. My name is Log Information");
                _logger.LogWarning("LogWarning = Now I'm Loggy McLoggerton");
                _logger.LogCritical("LogCritical = As of now, I'm Scrog McLog");
                _logger.LogDebug("Log Debug");
                _logger.LogError("LogError");
                _logger.LogTrace("Log Trace = Tracing my way back home");

                //Console prompt for Player 1 name.
                Console.Write("Player 1 Name: ");
                players[0] = new Player(Console.ReadLine());

                //Console prompt for Player 2 name.
                Console.Write("Player 2 Name: ");
                players[1] = new Player(Console.ReadLine());
            }

            /*
            Method that starts the game simulation.
            Simulates rounds of RPS. Ends when a player has acquired two wins.
            RPS choices each round are randomly generated.
            Console output details each round result and choices.
            */
            public void Start()
            {
                //Random rand = new Random();
                int n = 1;
                
                do
                {
                    StartRound(n); //Instantiates a new Round object.
                    n++; //Increment the round number.
                } while (players[0].wins < 2 && players[1].wins < 2); //Ends when a player acquires two wins.

            String tiesWord;
            if (ties == 1) { tiesWord = "tie"; }
            else { tiesWord = "ties"; }
            if (players[0].wins == 2) Console.WriteLine($"{players[0].Name} Wins {players[0].wins} - {players[1].wins} With {ties} Ties.");
                else Console.WriteLine($"{players[1].Name} Wins {players[1].wins} - {players[0].wins} With {ties} {tiesWord}.");
            }

            /* Method to instantiate and simulate a Round.
            Outputs to console the Player RPS choices and the round outcome.
            Stores Round object into rounds field.
            */
            public void StartRound(int n)
            {
            Round newRound = new Round(n);
                rounds.Add(newRound);

                Console.Write($"Round {newRound.roundCount}: {players[0].Name} chose {newRound.p1Choice}, {players[1].Name} chose {newRound.p2Choice}. - ");

                //Determines the result of each round from the RPS choices.
                switch (newRound.result)
                {
                    case -1: //Player 2 wins.
                    _logger.LogInformation("Player 2 Won");
                        players[1].wins++;
                        //Console.WriteLine($"{players[1].Name} Won");
                        break;
                    case 0: //Tied round.
                    _logger.LogInformation("Tie");
                        ties++;
                        //Console.WriteLine($"It's a Tie");
                        break;
                    case 1: //Player 1 wins.
                    _logger.LogInformation("Player 1 Won");
                        players[0].wins++;
                        //Console.WriteLine($"{players[0].Name} Won");
                        break;
                }

            }

        }

        #endregion

    }

