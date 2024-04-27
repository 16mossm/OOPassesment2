using System;
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
            bool gameover = false;
            GameReturn PrevStats = new GameReturn(new int[]{0,0 },new bool[]{ false, false }, false);
            while (!gameover) {
                GameReturn stats = game.playGame();
                if (game is SevensOut) {
                    for(int i = 0; i < stats.prevPlayerScore.Length; i++)
                    {

                        if(PrevStats.prevPlayerScore.Length > i)
                        {
                            Console.WriteLine(stats.playerOut[i]);
                            if (stats.prevPlayerScore[i] - PrevStats.prevPlayerScore[i] == 7)
                            {
                                Debug.Assert(stats.playerOut[i]);
                                Console.WriteLine("7 found");
                            }
                        }

                    }

                }
                gameover = stats.gameOver;
                PrevStats = stats;
            }


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
            else {
                throw new Exception("not a valid game");
            }
            return -1;
        }
    }
}
