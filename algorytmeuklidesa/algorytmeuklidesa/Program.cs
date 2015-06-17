using System;

namespace algorytmeuklidesa
{
    class Program
    {
        static void Main(string[] args)
        {
            nwdclass nwd = new nwdclass();

            var s = nwd.NWD(1, 10);
            var a = nwd.NWD(5, 125);
            var b = nwd.NWD(10, 253);
            var c = nwd.NWD(54, 250);
            var d = nwd.NWD(124, 342);

            Console.WriteLine(s.ToString());
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(c.ToString());
            Console.WriteLine(d.ToString());

            Console.ReadKey();
        }
    }

    public class nwdclass
    {

        public int a 
        {
            get
            {
                return a;
            }

            set
            {
                a = value;
            }
        }

        public int b
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
            }
        }

        public int NWD(int a, int b)
        {
            int c;
            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            return a;
        }
    }
}
