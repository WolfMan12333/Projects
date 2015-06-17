using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrażenia_lambda
{
    class Program
    {
        delegate int DInc(int n);
        delegate bool DisEqual(double x, double y);
        delegate void DShow(int n);
        delegate bool IsNotEqual(double x, double y);

        static void Main(string[] args)
        {
            Console.WriteLine("Wyrazenia lambda:\n");

            DInc Inc = (int n) => n + 1;
            Console.WriteLine("Inc(1)=" + Inc(1));

            DisEqual IsEqual = (x, y) => x == y;
            int a = 10;
            int b = 20;
            Console.WriteLine("Czy rowne a=" + a + " i b=" + b + "? " + (IsEqual(a, b) ? "Tak" : "Nie"));
            Console.WriteLine("Czy rowne a=" + a + " i a=" + a + "? " + (IsEqual(a, a) ? "Tak" : "Nie"));

            DShow Show = n => { Console.WriteLine(n.ToString()); };
            Show(10);

            Console.WriteLine("\nNa zywo bez delegacji wyrazenie lambda:\n");
            IsNotEqual IsNotEqual = (x, y) => x != y;
            double c = 50.0;
            double d = 100.0;
            Console.WriteLine("Czy c="+c+" i d="+d+" sa od siebie rozne? " + (IsNotEqual(c, d) ? "Tak" : "Nie"));
            Console.WriteLine("czy d=" + d + " i d=" + d + " sa od siebie rozne?" + (IsNotEqual(d, d) ? "Tak" : "Nie"));
            Console.ReadKey();
        }
    }
}
