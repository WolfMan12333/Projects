using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzialanianaliczbie
{
    class Program
    {
        static void Main(string[] args)
        {
            string l = "";
            do
            {
                Console.WriteLine("Podaj liczbe z zakresu od 1 do 10: ");
                int n = int.Parse(Console.ReadLine());
                if (n > 10 || n < 0)
                    Console.WriteLine("Blad liczba z poza zakresu.");
                else
                {
                    int power = 2;
                    int wynik = (int)Math.Pow(n, power);
                    Console.WriteLine("{0}^{1} = {2}", n, power, wynik);

                    do
                    {
                        Console.WriteLine("Wybierz co chcesz zrobic:\n + 10\n * 2\n - 1\nexit");
                        l = Console.ReadLine();
                        if (l == "+ 10")
                        {
                            wynik += 10;
                            Console.WriteLine("Wynik dodania liczby 10: " + wynik);
                        }
                        else if (l == "* 2")
                        {
                            wynik *= 2;
                            Console.WriteLine("Wynik mnozenia przez 2: {0}", wynik);
                        }
                        else if (l == "- 1")
                        {
                            wynik -= 1;
                            Console.WriteLine("Wynik odejmowania od liczby 1: {0}", wynik);
                        }
                        else if (l == "exit")
                        {
                            Console.WriteLine("Chcesz wyjsc? tak lub nie:");
                            l = Console.ReadLine();
                            if (l == "tak")
                                break;
                            else
                                continue;
                        }
                    } while (l != "tak");
                }

            }while( l != "tak");

            //Console.ReadKey();
        }
    }
}
