using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziedziczenie
{
    abstract class Figura
    {
        public Figura()
        {
            Console.WriteLine("Konstruktor klasy FIgura");
        }

        public Figura(string argument)
        {
            Console.WriteLine("Konstruktor klasy FIgura, komunikat: " + argument);
        }

        public abstract int IleWierzcholkow();
        public virtual int LiczbaWierzcholkow
        {
            get
            {
                return IleWierzcholkow();
            }
        }
    }

    class Okrag : Figura
    {
        public override int IleWierzcholkow()
        {
            return 0;
        }

        public override int LiczbaWierzcholkow
        {
            get
            {
                return IleWierzcholkow();
            }
        }
    }

    class Trojkat : Figura
    {
        public Trojkat()
        {
            Console.WriteLine("Konstruktor klasy Trojkat");
        }

        public Trojkat(string argument)
            : base(argument)
        {
            Console.WriteLine("Konstruktor klasy Trojkat, komuniakt : " + argument);
        }

        public override int IleWierzcholkow()
        {
            return 3;
        }

        public override int LiczbaWierzcholkow
        {
            get 
            {
                return IleWierzcholkow();    
            }
        }
    }

    class Prostokat : Figura
    {
        public override int IleWierzcholkow()
        {
            return 4;
        }

        public override int LiczbaWierzcholkow
        {
            get 
            {
                return IleWierzcholkow();    
            }
        }
    }

    class Kwadrat : Prostokat
    {
        public override int IleWierzcholkow()
        {
            return 4;
        }

        public override int LiczbaWierzcholkow
        {
            get
            {
                return IleWierzcholkow();
            }
        }
    }
}
