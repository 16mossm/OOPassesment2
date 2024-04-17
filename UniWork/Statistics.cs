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

        public void playGame(Game game, Player[] players)
        {
            //sevensout = 0
            //threeormore = 1
            int score = game.playGame(players);
            int gameID = getGameID(game);

            if (highscores[gameID] < score)
            {
                highscores[gameID] = score;
            }
            ammountOfPlays[gameID]++;
        }

        int getGameID(Game game) {
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
        public int getScore(Game game)
        {
            return highscores[getGameID(game)];
        }
        public int getPlays(Game game)
        {
            return ammountOfPlays[getGameID(game)];
        }

    }
}
