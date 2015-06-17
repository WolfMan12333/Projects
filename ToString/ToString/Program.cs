using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToString
{
    class Program
    {
        //pole
        public static Object obj;

        //metoda
        static void Main(string[] args)
        {
            Console.WriteLine("Wynik ponizej:");
            
            //inicjacja wartości 
            obj = 12333;
            Console.WriteLine(obj.ToString());

            Console.ReadLine();
        }

        //metoda
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
