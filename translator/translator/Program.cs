using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> trans = new Dictionary<string, string>();
            
            trans.Add("jest", "is");
            trans.Add("ma", "has");
            trans.Add("lubi", "likes");
            trans.Add("ogladac", "to watch");
            trans.Add("kot", "cat");
            trans.Add("wlosy", "hair");
            trans.Add("filmy", "movies");
            trans.Add("bardzo", "very");
            trans.Add("rudy", "red");
            trans.Add("rude", "red");
            trans.Add("wysoki", "tall");

            Console.WriteLine("Podaj zdanie do tlumaczenia:");
            List<string> lista = new List<string>();
            string txt = Console.ReadLine();
            lista.Add(txt);
            Console.WriteLine("Oryginalny tekst: {0}", txt);
            List<string> lista2 = new List<string>();
            foreach (string sa in lista)
            {
                if (sa == "jest")
                {
                    string s = trans["jest"];
                    Console.Write(s);
                }
                if (sa == "ma")
                {
                    string s = sa.Replace(sa, trans["ma"]);
                    Console.Write(s);
                }
                if (sa == "lubi")
                {
                    string s = sa.Replace(sa, trans["lubi"]);
                    Console.Write(s);
                }
                if (sa == "ogladac")
                {
                    string s = sa.Replace(sa, trans["ogladac"]);
                    Console.Write(s);
                }
                if (sa == "kot")
                {
                    string s = sa.Replace(sa, trans["kot"]);
                    Console.Write(s);
                }
                if (sa == "wlosy")
                {
                    string s = sa.Replace(sa, trans["wlosy"]);
                    Console.Write(s);
                }
                if (sa == "filmy")
                {
                    string s = sa.Replace(sa, trans["filmy"]);
                    Console.Write(s);
                }
                if (sa == "bardzo")
                {
                    string s = sa.Replace(sa, trans["bardzo"]);
                    Console.Write(s);
                }
                if (sa == "rudy")
                {
                    string s = sa.Replace(sa, trans["red"]);
                    Console.Write(s);
                }
                if (sa == "rude")
                {
                    string s = sa.Replace(sa, trans["rude"]);
                    Console.Write(s);
                }
                if (sa == "wysoki")
                {
                    string s = sa.Replace(sa, trans["wysoki"]);
                    Console.Write(s);
                }
            }

            Console.ReadKey();
        }
    }
}
