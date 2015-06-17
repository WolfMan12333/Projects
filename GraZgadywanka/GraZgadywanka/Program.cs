using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraZgadywanka
{
    class Program
    {
        static void Main(string[] args)
        {
            string ext = "";
            do
            {
                Console.WriteLine("Podaj liczbe:");
                ext = Console.ReadLine();
                int liczba = int.Parse(ext);

                Random rand = new Random();
                int liczbazgad = rand.Next(1, 10);

                if (liczba == liczbazgad)
                    Console.WriteLine("Gratulacje zgadles!!! Twoja liczba: " + liczba + " i moja: " + liczbazgad);
                else
                    Console.WriteLine("Nie zgadles!!! Twoja liczba: " + liczba + " i moja: " + liczbazgad);

                Console.WriteLine("Chcesz wyjsc czy kontynuowac gre?");
                ext = Console.ReadLine();
                if (ext == "continue")
                    continue;
                else if (ext == "exit")
                    break;

            } while (ext != "exit");
        }
    }
}
