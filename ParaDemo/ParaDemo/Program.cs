using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Para;
using ParaInt = Para.Para<int, int>;
using ParaDouble = Para.Para<double, double>;
using ParaString = Para.Para<string, string>;
using ParaIntDouble = Para.Para<int, double>;

namespace ParaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            //int
            Para<int, int>[] pi = new Para<int, int>[10];
            for (int i = 0; i < pi.Length; i++)
                pi[i] = new Para<int, int>(r.Next(10), r.Next(10));
            Console.WriteLine("Para<int>:");
            foreach (Para<int, int> para in pi) Console.WriteLine(para.ToString());

            //sortowanie
            Array.Sort(pi);
            Console.WriteLine("\nPara<int> po sortowaniu:");
            foreach (Para<int, int> para in pi) Console.WriteLine(para.ToString());

            //double
            Para<double, double>[] pd = new Para<double, double>[10];
            for (int i = 0; i < pi.Length; i++)
                pd[i] = new Para<double, double>(r.NextDouble(), r.NextDouble());
            Console.WriteLine("\nPara<double>:");
            foreach (Para<double, double> para in pd) Console.WriteLine(para.ToString());
            Array.Sort(pd);
            Console.WriteLine("\nPara<double> po sortowaniu:");
            foreach (Para<double, double> para in pd) Console.WriteLine(para.ToString());

            //string
            Para<string, string>[] ps = new Para<string, string>[12];
            ps[0] = new Para<string, string>("Bexter", "Alfred");
            ps[1] = new Para<string, string>("Dick", "Philip");
            ps[2] = new Para<string, string>("Tolkien", "John");
            ps[3] = new Para<string, string>("Lem", "Stanisław");
            ps[4] = new Para<string, string>("Anderson", "Poul");
            ps[5] = new Para<string, string>("Pohl", "Frederik");
            ps[6] = new Para<string, string>("Le Guin", "Ursula");
            ps[7] = new Para<string, string>("Card", "Orson");
            ps[8] = new Para<string, string>("Gibson", "William");
            ps[9] = new Para<string, string>("Asimov", "Isaac");
            ps[10] = new Para<string, string>("Niven", "Larry");
            ps[11] = new Para<string, string>("Herbert", "Frank");
            Console.WriteLine("\nPara<string>:");
            foreach (Para<string, string> para in ps) Console.WriteLine(para.ToString());
            Array.Sort(ps);
            Console.WriteLine("\nPara<string> po sortowaniu:");
            foreach (Para<string, string> para in ps) Console.WriteLine(para.ToString());

            //int-double
            ParaIntDouble[] p = new ParaIntDouble[10];
            for (int i = 0; i < p.Length; i++)
                p[i] = new ParaIntDouble(r.Next(10), r.NextDouble());
            Console.WriteLine("Para<int, double>:");
            foreach (ParaIntDouble para in p) Console.WriteLine(para.ToString());
            Array.Sort(p);
            Console.WriteLine("Para<int, double> po sortowaniu:");
            foreach (ParaIntDouble para in p) Console.WriteLine(para.ToString());

            Console.ReadKey();
        }
    }
}
