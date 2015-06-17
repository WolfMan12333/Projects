using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przyrostludziwmiescie
{
    class Program
    {
        static void Main(string[] args)
        {
            int cityT = 100000;
            int cityB = 300000;

            int rok = 1;
            while ( cityT < cityB)
            {
                cityT = ((cityT * 3) / 100) + cityT;
                cityB = ((cityB * 2) / 100) + cityB;
               
                Console.WriteLine("W miescie T po roku: " + rok + ", jest osob: " + cityT);
                Console.WriteLine("W miescie B po roku: " + rok + ", jest osob: " + cityB);

                rok++;
            }

            Console.ReadKey();
        }
    }
}
