using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWork
{


    abstract class Game
    {
        public virtual int playGame(Player[] players)
        {
            return -1;
        }
    }

    class SevensOut : Game
    {
        int previousScore = 0;

        public int getScore()
        {
            return previousScore;
        }

        public override int playGame(Player[] players) {
            //sets all the players to not being out
            bool[] PlayerOut = new bool[players.Length];
            int[] PlayerScore = new int[players.Length];
            for (int i = 0; i < PlayerOut.Length; i++) {
                PlayerOut[i] = false;
                PlayerScore[i] = 0;
            }

            Die die = new Die();
            //while there is a player who isnt out
            while (PlayerOut.Contains<bool>(false))
            {
                Console.WriteLine("- - - - - - -");
                
                for(int playerID = 0; playerID < players.Length; playerID++)
                {
                    if (PlayerOut[playerID])
                    {
                        //psudoReturn
                        goto LOOPEND;
                    }
                    Console.WriteLine("-" + players[playerID].name + "'s turn:");
                    int die1 = die.Roll();
                    int die2 = die.Roll();
                    int sum = (die1 + die2);

                    Console.WriteLine("Die1: " + die1.ToString() + " ,Die2: " + die2.ToString());

                    if (sum == 7)
                    {
                        Console.WriteLine("7 rolled!");
                        Console.WriteLine(players[playerID].name + " OUT!");
                        PlayerOut[playerID] = true;
                    }
                    else
                    {
                        PlayerScore[playerID] += die1 + die2;
                        if (die1 == die2)
                        {
                            Console.WriteLine("DOUBLE! score extra points");
                            PlayerScore[playerID] += die1 + die2;
                        }

                    }
                    LOOPEND:
                    Console.WriteLine(players[playerID].name + "'s score: " + PlayerScore[playerID].ToString());
                }
                Console.WriteLine("press enter to continue");
                Console.ReadLine();
            }

            //find the highest Scoring player(s):
            int highestScore = 0;
            List<string> winningPlayers = new List<string>();
            for (int i = 0; i < PlayerScore.Length; i++)
            {
                if (PlayerScore[i] > highestScore)
                {
                    winningPlayers.Clear();
                    winningPlayers.Add(players[i].name);
                    highestScore = PlayerScore[i];
                }
                else
                {
                    if (PlayerScore[i] == highestScore)
                    {
                        winningPlayers.Append(players[i].name);
                    }
                }

            }


            //show the winning player:
            Console.WriteLine("GAME OVER!");


            if(winningPlayers.Count() == 1)
            {
                Console.WriteLine(winningPlayers[0] + " WINS");
                
            }
            else
            {
                Console.WriteLine("its a tie between:");
                foreach(string names in winningPlayers)
                {
                    Console.WriteLine("-" + names);
                }
            }

            Console.WriteLine("score: " + highestScore.ToString());
            return highestScore;
        }
    }


    class ThreeOrMore : Game
    {
        public override int playGame(Player[] players){

            bool gameOver = false;
            bool[] PlayerOut = new bool[players.Length];
            int[] PlayerScore = new int[players.Length];
            for (int i = 0; i < PlayerOut.Length; i++)
            {
                PlayerOut[i] = false;
                PlayerScore[i] = 0;
            }

            Die die = new Die();
            //if 0 is in the array it means a player isnt out
            while (!gameOver)
            {
                
                Console.WriteLine("- - - - - - -");
                
                for (int playerID = 0; playerID < players.Length; playerID++)
                {
                    Console.WriteLine();
                    Console.WriteLine("-" + players[playerID].name + "'s turn:");

                    Console.Write("rolled: ");
                    //roll 5 dice
                    int[] DiceRolled = new int[5];
                    for(int i = 0; i < 5; i++)
                    {
                        DiceRolled[i] = die.Roll();
                        Console.Write(DiceRolled[i].ToString() + " ");
                    }
                    Console.WriteLine();


                    //find out if there is multiple of the same
                    // the ammount of dice of specified value
                    int[] NumCount = { 0, 0, 0, 0, 0, 0 };
                    foreach(int i in DiceRolled)
                    {
                        NumCount[i - 1]++;//increase that count by 1
                    }
                    //if 2 of a kind is rolled ask if they want to reroll
                    if (NumCount.Contains(2))
                    {
                        bool userInputSuccess = false;
                        
                        
                        while (!userInputSuccess)
                        {
                            Console.WriteLine("2 of a kind rolled, Reroll? {r = remaining, a = all, n = none}");
                            string UserInput;
                            if (!players[playerID].bot)
                            {
                                UserInput = Console.ReadLine();

                            }
                            else
                            {
                                UserInput = "r";
                            }
                            
                            if (UserInput.Length != 0)
                            {
                                if (UserInput[0] == 'r' || UserInput[0] == 'R')
                                {
                                    //reroll remaining

                                    for (int i = 0; i < DiceRolled.Length; i++)
                                    {
                                        //if the die isnt part of a 2 of a kind
                                        if (NumCount[DiceRolled[i] - 1] != 2)
                                        {
                                            //reroll
                                            DiceRolled[i] = die.Roll();
                                        }
                                    }

                                    userInputSuccess = true;

                                    //print it out
                                    Console.Write("rolled: ");
                                    for (int i = 0; i < 5; i++)
                                    {
                                        Console.Write(DiceRolled[i].ToString() + " ");
                                    }
                                    Console.WriteLine();
                                }
                                if (UserInput[0] == 'a' || UserInput[0] == 'A')
                                {
                                    //reroll ALL
                                    for (int i = 0; i < DiceRolled.Length; i++)
                                    {
                                        //reroll all
                                        DiceRolled[i] = die.Roll();
                                    }
                                    userInputSuccess = true;

                                    //print it out
                                    Console.Write("rolled: ");
                                    for (int i = 0; i < 5; i++)
                                    {
                                        Console.Write(DiceRolled[i].ToString() + " ");
                                    }
                                    Console.WriteLine();


                                }
                                if (UserInput[0] == 'n' || UserInput[0] == 'N')
                                {
                                    //reroll None
                                    userInputSuccess = true;
                                }
                            }
                        }

                    }

                    //recalculate dice rolls
                    NumCount = new int[]{ 0, 0, 0, 0, 0, 0 };
                    foreach (int i in DiceRolled)
                    {
                        NumCount[i - 1]++;//increase that count by 1
                    }


                    //score points
                    if (NumCount.Contains(5))
                    {
                        Console.WriteLine("5 of a kind!! 12 points");
                        PlayerScore[playerID] += 12;
                    }
                    if (NumCount.Contains(4))
                    {
                        Console.WriteLine("4 of a kind!! 6 points");
                        PlayerScore[playerID] += 6;
                    }
                    if (NumCount.Contains(3))
                    {
                        Console.WriteLine("3 of a kind!! 3 points");
                        PlayerScore[playerID] += 3;
                    }
                    Console.WriteLine(players[playerID].name + "'s score: " + PlayerScore[playerID].ToString());
                    if(PlayerScore[playerID] >= 20)
                    {
                        gameOver = true;
                        PlayerOut[playerID] = true;
                        Console.WriteLine(players[playerID].name + " OUT!!");
                    }
                }
                Console.WriteLine("press enter to continue");
                Console.ReadLine();

            }
            //determine winner 
            List<string> winningPlayers = new List<string>();
            int highestScore = 0;
            for (int i = 0; i< players.Length; i++)
            {
                if (PlayerScore[i] > highestScore) { highestScore = PlayerScore[i]; }
                if (PlayerOut[i]) {
                    winningPlayers.Add(players[i].name);
                }
            }


            if (winningPlayers.Count() == 1)
            {
                Console.WriteLine(winningPlayers[0] + " WINS");

            }
            else
            {
                Console.WriteLine("its a tie between:");
                foreach (string names in winningPlayers)
                {
                    Console.WriteLine("-" + names);
                }
            }

            Console.WriteLine("score: " + highestScore.ToString());
            return highestScore;


        }

    }

}
