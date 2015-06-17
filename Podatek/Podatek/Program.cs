using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podatek
{
    class Program
    {
        static void podatek(int wyplata)
        {
            if (wyplata < 10000)
            {
                Console.WriteLine("Podatek przy kwocie: " + wyplata + ", wynosi : " + (wyplata / 10));
            }
            else if (wyplata >= 10000 && wyplata < 30000)
            {
                Console.WriteLine("Podatek przy kwocie: " + wyplata + ", wynosi: " + ((wyplata * 15) / 100));
            }
            else if (wyplata > 30000)
                Console.WriteLine("Podatek przy kwocie: " + wyplata + ", wynosi: " + ((wyplata * 2) / 10));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Podaj kwote ktora zarabiasz miesiecznie: ");
            int liczba;
            liczba = Convert.ToInt32(Console.ReadLine());

            podatek(liczba);
            Console.ReadKey();
        }
    }
}
