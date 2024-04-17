using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Statistics stats = new Statistics();

            Player[] players = new Player[2];

            Console.WriteLine("how many players? {1,2}");
            string Userinput = Console.ReadLine();
            while (Userinput != "1" && Userinput != "2") {
                Console.WriteLine("how many players? {1,2}");
                Userinput = Console.ReadLine();
            }
            if(Userinput == "1")
            {
                Console.WriteLine("enter player 1's name:");
                string p1 = Console.ReadLine();
                players = new Player[]
                {
                    new Player(p1),
                    new Player("bot")
                };
                players[1].bot = true;
            }
            if (Userinput == "2")
            {
                Console.WriteLine("enter player 1's name:");
                string p1 = Console.ReadLine();
                Console.WriteLine("enter player 2's name:");
                string p2 = Console.ReadLine();
                players = new Player[]
                {
                    new Player(p1),
                    new Player(p2)
                };
            }

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("- - - - - - -");
                
                

                Console.WriteLine("what game would you like to play {1 = SevensOut, 2 = ThreeOrMore, quit = quit , stats = show stats}");
                string GameChoice = Console.ReadLine();
                while (GameChoice != "1" && GameChoice != "2")
                {
                    if (GameChoice == "quit") {
                        quit = true;
                        break;
                            }

                    if (GameChoice == "stats")
                    {
                        Console.WriteLine("---stats---");
                        Console.WriteLine("SevensOut:");
                        Console.WriteLine("highscore: "+stats.getScore(new SevensOut()).ToString());
                        Console.WriteLine("plays: " + stats.getPlays(new SevensOut()).ToString());
                        Console.WriteLine("ThreeOrMore:");
                        Console.WriteLine("highscore: " + stats.getScore(new ThreeOrMore()).ToString());
                        Console.WriteLine("plays: " + stats.getPlays(new ThreeOrMore()).ToString());
                    }

                    Console.WriteLine("what game would you like to play {1 = SevensOut, 2 = ThreeOrMore, quit = quit}");
                    GameChoice = Console.ReadLine();
                }
                Game gameplaying = null;
                if(GameChoice == "1")
                {
                    gameplaying = new SevensOut();
                }
                if(GameChoice == "2")
                {
                    gameplaying = new ThreeOrMore();
                }


                ////////polymorphism
                // have the statistics class play the game and save the score because thats the funny way to do this
                if (!quit)
                {
                    stats.playGame(gameplaying, players);
                }

            }


            Console.ReadLine();            
        }
    }
}
