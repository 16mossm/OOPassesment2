﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWork
{
    class Testing
    {
        public void playGame(Iplayable game)
        {
            //sevensout = 0
            //threeormore = 1
            while (!game.playGame()) ;


            //run the game again and assert that the game did not end early;
            Debug.Assert(game.playGame());

            if (game is ThreeOrMore)
            {
                //assert that the game only ends if score is greater than 20
                Debug.Assert(game.ShowWinner() >= 20);
            }
            else
            {
                game.ShowWinner();
            }
        }

        int getGameID(Iplayable game)
        {
            if (game is SevensOut)
            {
                return 0;
            }

            if (game is ThreeOrMore)
            {
                return 1;
            }
            return -1;
        }
    }
}
