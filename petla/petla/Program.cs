using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petla
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            for (int i = n; i >= 1; --i)
            {
                Console.Write("*");
            }
            Console.Write("\t");

            int m = 5;
            for (int i = m; i >= 1; --i)
            {
                Console.Write(i);
            }
            Console.Write("\t");

            for (int i = 1; i <= 3; ++i )
            {
                Console.Write("12");
            }
            Console.Write("\t");

            for (int i = 1; i < 6; ++i )
            {
                if (i == 1)
                    Console.Write(i);
                
                if (i == 2)
                {
                    for (int z = 0; z < 2; ++z)
                        Console.Write(i);
                }

                if (i == 3)
                {
                    for (int z = 0; z < 2; ++z)
                        Console.Write(i);
                }
            }
            Console.Write("\n");
            //***********************************************************

            for (int i = 1; i <= 3; ++i)
                Console.Write("*");
            Console.Write("\t");

            for (int i = 6; i >= 2; --i)
                Console.Write(i);
            Console.Write("\t");

            for (int i = 1; i <= 3; ++i)
                Console.Write("21");
            Console.Write("\t");

            for (int i = 1; i <= 9; ++i)
            {
                if (i == 2)
                {
                    for (int z = 1; z <= i; ++z)
                        Console.Write(i);
                }

                if (i == 3)
                {
                    for (int z = 1; z <= i; ++z)
                        Console.Write(i);
                }

                if (i == 4)
                {
                    for (int z = 1; z <= i; ++z)
                        Console.Write(i);
                }
            }
            Console.Write("\n");
            //*******************************************************************

            for (int i = 1; i <= 2; ++i)
                Console.Write('*');
            Console.Write("\t");

            for (int i = 7; i >= 3; --i)
                Console.Write(i);
            Console.Write("\t");

            for (int i = 1; i <= 3; ++i)
                Console.Write("12");
            Console.Write("\t");

            for (int i = 1; i <= 12; ++i)
            {
                if (i == 3)
                {
                    for (int z = 1; z <= i; ++z)
                        Console.Write(i);
                }

                if (i == 4)
                {
                    for (int z = 1; z <= i; ++z)
                        Console.Write(i);
                }

                if (i == 5)
                {
                    for (int z = 1; z <= i; ++z)
                        Console.Write(i);
                }
            }
            Console.Write("\n");
            //***********************************************************

            Console.Write('*');
            Console.Write("\t");

            for (int i = 8; i >= 4; --i)
                Console.Write(i);
            Console.Write("\t");

            for (int i = 1; i <= 3; ++i)
                Console.Write("21");
            Console.Write("\t");

            for (int i = 1; i <= 15; ++i)
            {
                if (i == 4)
                {
                    for (int z = 1; z <= i; ++z)
                    {
                        Console.Write(i);
                    }
                }

                if (i == 5)
                {
                    for (int z = 1; z <= i; ++z)
                    {
                        Console.Write(i);
                    }
                }

                if (i == 6)
                {
                    for (int z = 1; z <= i; ++z)
                        Console.Write(i);
                }
            }

            Console.ReadKey();
        }
    }
}
