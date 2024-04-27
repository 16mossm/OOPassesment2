using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWork
{
    class GameReturn
    {
        public int[] prevPlayerScore = new int[0];
        public bool[] playerOut;
        public bool gameOver;

        public static implicit operator bool(GameReturn gameReturn)
        {
            return gameReturn.gameOver;
        }

        public GameReturn(int[] scores, bool[] playersOut, bool over)
        {
            prevPlayerScore = scores;
            playerOut = playersOut;
            gameOver = over;
        }

    }
}
