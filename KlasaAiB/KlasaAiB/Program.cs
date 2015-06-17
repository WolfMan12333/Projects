using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaAiB
{
    class Program
    {
        static void Main(string[] args)
        {
            A aa = new A();
            A ab = new B();
            B bb = new B();
            B ba = (B)new A();

            Console.WriteLine("A aa = new A():");
            aa.M1();
            aa.M2();

            Console.WriteLine("A ab = new B():");
            ab.M1();
            ab.M2();

            Console.WriteLine("B bb = new B():");
            bb.M1();
            bb.M2();

            Console.WriteLine("B ba = new A():");
            ba.M1();
            ba.M2();

            Console.ReadKey();
        }
    }
}
