using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWork
{

    class Statistics
    {

        //array of scores. each game gets unique id. this is an auful way to do this but you cant have more classses????
        public int[] highscores;
        public int[] ammountOfPlays;

        public Statistics(int ammountOfGames = 2)
        {
            highscores = new int[2] { 0,0};
            ammountOfPlays = new int[2] { 0, 0 };
        }

        public void playGame(Iplayable game)
        {
            //sevensout = 0
            //threeormore = 1
            while (!game.playGame());
            int score = game.ShowWinner();
            int gameID = getGameID(game);

            if (highscores[gameID] < score)
            {
                highscores[gameID] = score;
            }
            ammountOfPlays[gameID]++;
        }

        int getGameID(Iplayable game) {
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
        public int getScore(Iplayable game)
        {
            return highscores[getGameID(game)];
        }
        public int getPlays(Iplayable game)
        {
            return ammountOfPlays[getGameID(game)];
        }

    }
}
