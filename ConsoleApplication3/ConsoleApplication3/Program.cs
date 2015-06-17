using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer();
            t.ToString();
            Console.ReadKey();
        }
    }

    class Timer
    {
        //delegacja
        delegate string metoda();

        //konstruktor
        public Timer()
        {
            metoda ob = kwadrat;
            for (int i = 0; i < Interval; i++)
            {
                if (i == Interval)
                    if (Enabled == true)
                        ob();
            }
        }

        //własności auto-implemented
        int Interval { get; set; }
        bool Enabled { get; set; }

        //metoda
        private static string kwadrat()
        {
            return "kwadrat";
        }

        public string ToString()
        {
            return kwadrat();
        }
    }
}
