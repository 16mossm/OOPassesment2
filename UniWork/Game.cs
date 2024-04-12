using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWork
{
    class Game
    {
        /// <summary>
        /// plays the game fully for 1 player
        /// </summary>
        /// <returns></returns>
        public virtual int playGame()
        {

            return 0;
        }

        /// <summary>
        /// plays 1 round of the game for 1 player
        /// </summary>
        /// <returns></returns>
        public virtual int playRound(int scoreRollover) {
            return -1;
        }
    }

    class SevensOut : Game
    {
        public override int playGame()
        {
            //plays the game

            int total = 0;
            Die die = new Die();

            //using 2 die object does not work because c#'s random seeding is bad so just going to use 1 object


            while (true)   //roll 2 dice
            {
                int die1 = die.Roll();
                int die2 = die.Roll();
                int sum = (die1 + die2);

                Console.WriteLine("---");

                if (sum == 7)
                {
                    Console.WriteLine("7 rolled!");
                    Console.WriteLine("Die1: " + die1.ToString() + " ,Die2: " + die2.ToString());

                    Console.WriteLine("Score: " + total.ToString());
                    return total;
                }



                Console.WriteLine("Die1: " + die1.ToString() + " ,Die2: " + die2.ToString() + " total: " + sum.ToString());


                total += sum;     //if they arnt 7 add them to the score
                if (die1 == die2)
                {
                    Console.WriteLine("Double!! get extra score");
                    total += sum;     // if double add it twice.
                }
                Console.WriteLine("CurrentScore: " + total.ToString());
                Console.WriteLine("press enter to continue");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scoreRollover"></param>
        /// <returns>returns negative if game is over :).</returns>
        public virtual int playRound(int scoreRollover)
        {
            Die die = new Die();
            int total = scoreRollover;

            int die1 = die.Roll();
            int die2 = die.Roll();
            int sum = (die1 + die2);

            Console.WriteLine("---");

            if (sum == 7)
            {
                Console.WriteLine("7 rolled!");
                Console.WriteLine("Die1: " + die1.ToString() + " ,Die2: " + die2.ToString());

                Console.WriteLine("Score: " + total.ToString());
                return -total;
            }

            Console.WriteLine("Die1: " + die1.ToString() + " ,Die2: " + die2.ToString() + " total: " + sum.ToString());

            total += sum;     //if they arnt 7 add them to the score
            if (die1 == die2)
            {
                Console.WriteLine("Double!! get extra score");
                total += sum;     // if double add it twice.
            }
            Console.WriteLine("CurrentScore: " + total.ToString());
            Console.WriteLine("press enter to continue");
            Console.ReadLine();

            return total;
        }

    }


    class ThreeOrMore : Game
    {
        public override int playGame()
        {
            




            return 0;
        }

        public virtual int playRound(int scoreRollover)
        {
            return -1;
        }

    }

}
