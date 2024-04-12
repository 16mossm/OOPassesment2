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
            Game a = new SevensOut();
            a.playGame();

            Console.ReadLine();
        }
    }
}
