﻿////#define TEST
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


#if TEST
            Player[] players = { new Player("test1"), new Player("test2") };
            Testing test = new Testing();
            test.playGame(new SevensOut(players));
            test.playGame(new ThreeOrMore(players));
#else

            Game game = new Game();
            game.addPlayers();



            bool quit = false;
            while (!quit)
            {
                quit = game.gameloop();

            }


            Console.ReadLine();  
#endif
        }

    }
}
