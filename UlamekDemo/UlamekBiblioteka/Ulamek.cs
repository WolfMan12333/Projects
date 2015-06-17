using System;

namespace Helion
{
    public struct Ulamek : IComparable<Ulamek>
    {
        private int licznik, mianownik;

        //metoda CompareTo wymagana przez interfejs IComparable<Ulamek>
        public int CompareTo(Ulamek u)
        {
            double roznica = this.ToDouble() - u.ToDouble();
            if (roznica != 0) roznica /= Math.Abs(roznica);
            return (int)(roznica);
        }

        public Ulamek(int licznik, int mianownik = 1) : this()
        {
            Licznik = licznik;
            Mianownik = mianownik;

            //if (mianownik == 0)
            //    throw new ArgumentException("Mianownik musi być różny od zera");
            this.licznik = licznik;
            this.mianownik = mianownik;
        }

        public static readonly Ulamek Zero = new Ulamek(0);
        public static readonly Ulamek Jeden = new Ulamek(1);
        public static readonly Ulamek Polowa = new Ulamek(1, 2);
        public static readonly Ulamek Cwierc = new Ulamek(1, 4);

        public static string Info()
        {
            return "Struktura Ulamek, (c) Jacek Matulewski 2014";
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
            ////NWD
            //int mniejsza = Math.Min(Math.Abs(licznik), Math.Abs(mianownik));
            //for (int i = mniejsza; i > 1; i--)
            //    if ((licznik % i == 0) && (mianownik % i == 0))
            //    {
            //        licznik /= i;
            //        mianownik /= i;
            //        break;
            //    }

            ////znaki
            //if (licznik * mianownik < 0)
            //{
            //    licznik =- Math.Abs(licznik);
            //    mianownik = Math.Abs(mianownik);
            //}
            //else
            //{
            //    licznik = Math.Abs(licznik);
            //    mianownik = Math.Abs(mianownik);
            //}

            int a = licznik;
            int b = mianownik;

            //NWD
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
            //if ((licznik < 0 && mianownik > 0) || (licznik >= 0 && mianownik < 0))
            //{
            //    licznik = -Math.Abs(licznik);
            //    mianownik = Math.Abs(mianownik);
            //}
            //else
            //{
            //    licznik = Math.Abs(licznik);
            //    mianownik = Math.Abs(mianownik);
            //}
            if ( Math.Sign(licznik) * Math.Sign(mianownik) < 0)
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

        public static Ulamek DodajOvf(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(checked(u1.Licznik * u2.Mianownik + u2.Licznik * u1.Mianownik), checked(u1.Mianownik * u2.Mianownik));

            wynik.Uprosc();
            return wynik;
        }

        #region Wlasnoci
        public int Licznik { get; set; }
        //{
        //    get //odczyt
        //    {
        //        return licznik;
        //    }
        //    set //zapis
        //    {
        //        licznik = value;
        //    }
        //}

        public int Mianownik
        {
            get //odczyt
            {
                return mianownik;
            }
            set //zapis
            {
                if (value == 0)
                    throw new ArgumentException("Mianownik musi być różny od zera");
                mianownik = value;
            }
        }
        #endregion

        #region Operatory
        //operatory arytmetyczne
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
            return !(u1 == u2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ulamek)) return false;
            Ulamek u=(Ulamek)obj;
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

        //definicja operaotra jawnej konwersji na typ double
        public static explicit operator double(Ulamek u)
        {
            return u.ToDouble();
        }

        //definicja operator konwersji z typu int na Ulamek
        public static implicit operator Ulamek(int n)
        {
            return new Ulamek(n);
        }
        #endregion
    }
}
