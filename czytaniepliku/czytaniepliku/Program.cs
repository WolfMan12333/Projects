using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czytaniepliku
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            //int counter = 0;
            Console.WriteLine("Podaj nazwe pliku: ");
            string fileName = Console.ReadLine();
            System.IO.StreamReader file = new System.IO.StreamReader(@fileName);

            while ((line = file.ReadLine()) != null)
            {
                //for while do else if switch
                //Console.ForegroundColor = ConsoleColor.Blue;
                //Console.WriteLine(line);
                
                if (line.IndexOf("while") == 1 || line.IndexOf("for") == 1 || line.IndexOf("do") == 1 || line.IndexOf("if") == 1 || line.IndexOf("switch") == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(line);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(line);
                }
            }
            

            file.Close();
            Console.ReadLine();
        }
    }
}
