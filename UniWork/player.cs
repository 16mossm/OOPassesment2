using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWork
{
    class Player
    {
        public string name;
        public bool bot = false;


        public Player(string name , bool bot = false)
        {
            this.name = name;
            this.bot = bot;
        }
    }
}
