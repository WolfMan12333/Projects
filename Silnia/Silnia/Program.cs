using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnia
{
    class Program
    {
        static long Silnia(long argument)
        {
            if (argument < 1)
                return 1;
            else
                return argument * Silnia(argument - 1);
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Podaj liczbe ktora chcesz policzyc w funkcji silnia:\n");
                int arg;
                string line;
                line = Console.ReadLine();
                arg = int.Parse(line);

                Console.WriteLine(arg + "! = " + Silnia(arg));
                Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine("Message error: " + exc.ToString());
                Console.ReadKey();
            }
        }
    }
}
