using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortowaniebabelkowe
{
    class Program
    {
        static void Main(string[] args)
        {
            var liczby = new List<int>();
            liczby.Add(5);
            liczby.Add(251);
            liczby.Add(212);
            liczby.Add(20);
            liczby.Add(100);
            liczby.Add(2);
            liczby.Add(520);
            liczby.Add(12);
            liczby.Add(634);
            liczby.Add(253);

            for (int i = 0; i < liczby.Count; i++)
            {
                for (int j = 0; j < liczby.Count - 1; j++)
                {

                    if (liczby[j] > liczby[j + 1])
                    {
                        int temp = liczby[j];
                        liczby[j] = liczby[j + 1];
                        liczby[j + 1] = temp;
                    }
                }

                int l = i + 1;
                Console.WriteLine("Krok numer: {0}", l.ToString());

                foreach (var elem in liczby)
                {
                    Console.WriteLine(elem.ToString());
                }
            }

            Console.WriteLine("Uzycie interfejsu IComparable w sortowaniu babelkowym:");
            sortbab sort = new sortbab();
            sort.funsortbab(liczby);

            Console.WriteLine("Uzycie interfejsu IComparable<T> w sortowaniu babelkowym:");
            sortbab2 sort2 = new sortbab2();
            sort2.funsortbab(liczby);

            Console.ReadKey();
        }
    }

    public class sortbab : IComparable
    {
        protected int l;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            sortbab sort = obj as sortbab;
            if (sort != null)
                return this.l.CompareTo(sort.l);
            else
                throw new ArgumentException("Obiekt nie jest liczba");
        }

        public void funsortbab(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count - 1; j++)
                {

                    if (lista[j] > lista[j + 1])
                    {
                        int temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                    }
                }
            }

            foreach (var elem in lista)
                Console.WriteLine(elem.ToString());
        }
    }

    public class sortbab2 : IComparable<sortbab2>
    {
        protected int l;

        public int CompareTo(sortbab2 other)
        {
            if (other == null) return 1;

            return l.CompareTo(other.l);
        }

        public void funsortbab(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count - 1; j++)
                {
                    if (lista[j] > lista[j + 1])
                    {
                        int temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                    }
                }
            }

            foreach (var elem in lista)
                Console.WriteLine(elem.ToString());
        }
    }
}
