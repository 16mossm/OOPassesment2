using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWork
{
    class GameReturn
    {
        public int[] playerScoreDifference;
        int[] prevPlayerScore = new int[0];
        public bool[] playerOut;
        bool gameOver;


        public static implicit operator bool(GameReturn gameReturn)
        {
            return gameReturn.gameOver;
        }

        public GameReturn(int[] scores, bool[] playersOut, bool over)
        {
            playerScoreDifference = new int[scores.Length];
            for(int i = 0; i < scores.Length; i++)
            {
                if (prevPlayerScore.Length > i)
                {
                    playerScoreDifference[i] = scores[i] - prevPlayerScore[i];
                }
                else
                {
                    playerScoreDifference[i] = scores[i];
                }
            }
            playerOut = playersOut;
            prevPlayerScore = scores;
            gameOver = over;
        }

    }
}
