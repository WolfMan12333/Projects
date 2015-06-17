using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaAiB
{
    class B : A
    {
        public override void M1()
        {
            Console.WriteLine("Klasa B.M1");
        }

        new public void M2()
        {
            Console.WriteLine("Klasa B.M2");
        }
    }
}
