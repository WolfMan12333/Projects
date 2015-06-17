using System;

namespace Helion
{
    public struct Ulamek : IComparable<Ulamek>
    {
        private int licznik, mianownik;

        public Ulamek(int licznik, int mianownik = 1)
            //: this()
        {
            if (mianownik == 0)
                throw new ArgumentException("Mianownik musi byc rozny od zera.");
            this.licznik = licznik;
            this.mianownik = mianownik;
            //Licznik = licznik;
            //Mianownik = mianownik;
        }

        public static readonly Ulamek Zero = new Ulamek(0);
        public static readonly Ulamek Jeden = new Ulamek(1);
        public static readonly Ulamek Polowa = new Ulamek(1, 2);
        public static readonly Ulamek Cwierc = new Ulamek(1, 4);

        public static string Info()
        {
            return "Struktura Ulamek, Dawid Wordliczek";
        }

        public override string ToString()
        {
            return licznik.ToString() + "/" + mianownik.ToString();
        }

        public double ToDouble()
        {
            return licznik / (double)mianownik;
        }

        public void Uprosc()
        {
            int a = licznik;
            int b = mianownik;

            //NWD
            //int mniejsza = Math.Min(Math.Abs(licznik), Math.Abs(mianownik));
            //for (int i = mniejsza; i > 1; --i)
            //    if ((licznik % i ==0) && (mianownik % i == 0))
            //    {
            //        licznik /= i;
            //        mianownik /= i;
            //        break;
            //    }
            int c;
            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            licznik /= a;
            mianownik /= a;

            //znaki
            if (Math.Sign(licznik) * Math.Sign(mianownik) < 0)
            {
                licznik = -Math.Abs(licznik);
                mianownik = Math.Abs(mianownik);
            }
            else
            {
                licznik = Math.Abs(licznik);
                mianownik = Math.Abs(mianownik);
            }
        }

        #region Własności
        public int Licznik 
        {
            get
            {
                return licznik;
            }
            set
            {
                licznik = value;
            }
        }

        public int Mianownik
        {
            get //odczyt
            {
                return mianownik;
            }
            set //zapis
            {
                if (value == 0)
                    throw new ArgumentException("Mianownik musi byc rozny od zera.");
                else
                    mianownik = value;
            }
        }
        #endregion

        #region Operatory
        //operaotyr arytmetyczne
        public static Ulamek operator -(Ulamek u)
        {
            return new Ulamek(-u.Licznik, u.Mianownik);
        }

        public static Ulamek operator +(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(u1.Licznik * u2.Mianownik + u2.Licznik * u1.Mianownik, u1.Mianownik * u2.Mianownik);
            wynik.Uprosc();
            return wynik;
        }

        public static Ulamek operator -(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(u1.Licznik * u2.Mianownik - u2.Licznik * u1.Mianownik, u1.Mianownik * u2.Mianownik);
            wynik.Uprosc();
            return wynik;
        }

        public static Ulamek operator *(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(u1.Licznik * u2.Licznik, u1.Mianownik * u2.Mianownik);
            wynik.Uprosc();
            return wynik;
        }

        public static Ulamek operator /(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(u1.Licznik * u2.Mianownik, u1.Mianownik * u2.Licznik);
            wynik.Uprosc();
            return wynik;
        }

        //operatory logiczne
        public static bool operator ==(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() == u2.ToDouble());
        }

        public static bool operator !=(Ulamek u1, Ulamek u2)
        {
            return (u1 != u2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ulamek))
                return false;
            Ulamek u = (Ulamek)obj;
            return (this == u);
        }

        public override int GetHashCode()
        {
            return Licznik ^ Mianownik;
        }

        public static bool operator >(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() > u2.ToDouble());
        }

        public static bool operator >=(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() >= u2.ToDouble());
        }

        public static bool operator <(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() < u2.ToDouble());
        }

        public static bool operator <=(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() <= u2.ToDouble());
        }
        #endregion

        //definicja operatora jawnej konwersji na typ double
        public static explicit operator double(Ulamek u)
        {
            return u.ToDouble();
        }

        //definicja operatora konwersji z typu int na Ulamek
        public static implicit operator Ulamek(int n)
        {
            return new Ulamek(n);
        }

        //CompareTo wymagana przez interfejs IComparable<Ulamek>
        public int CompareTo(Ulamek u)
        {
            double roznica = this.ToDouble() - u.ToDouble();
            if (roznica != 0) roznica /= Math.Abs(roznica);
            return (int)(roznica);
        }

        public static Ulamek DodajOvf(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(checked(u1.Licznik * u2.Mianownik + u2.Licznik * u1.Mianownik), checked(u1.Mianownik * u2.Mianownik));

            wynik.Uprosc();
            return wynik;
        }
    }
}
