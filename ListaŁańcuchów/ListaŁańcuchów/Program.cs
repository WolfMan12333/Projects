using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaŁańcuchów
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lista = new List<string>();
            string choice;
            do 
            {
                Console.WriteLine("Co chcesz zrobic?\n1.Dodaj kolejna pozycje do listy - wpisz 1\n2.Sortuj liste - wpisz 2\n3.Usuwanie z listy lancucha wskazanej pozycji - wpisz 3\nWpisz: exit jesli chcesz wyjsc");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Podaj zdanie ktore chcesz wprowadzic do listy:");
                    string zdanie = Console.ReadLine();
                    lista.Add(zdanie);
                    lista.ForEach(Print);
                    Console.WriteLine();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Lista posortowana:");
                    lista.Sort();
                    lista.ForEach(Print);
                    Console.WriteLine();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Podaj pozycje ktora chcesz usunac:");
                    string poz = Console.ReadLine();
                    int poz2;
                    poz2 = int.Parse(poz);
                    poz2 -= 1;
                    lista.RemoveAt(poz2);
                    Console.WriteLine("Wyglad twojej listy:");
                    lista.ForEach(Print);
                    Console.WriteLine();
                }
                else if (choice == "exit")
                    break;
            } while(choice != "exit");
        }

        private static void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
