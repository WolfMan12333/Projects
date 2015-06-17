using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziedziczenie
{
    class Osoba
    {
        public string Imie;
        public string Nazwisko;
        public int Wiek;

        public override string ToString()
        {
            return Imie + " " + Nazwisko + " (" + Wiek + ")";
        }

        private string Personalia
        {
            get
            {
                return Imie + " " + Nazwisko;
            }
        }
    }

    class Adres
    {
        public string Miasto;
        public string Ulica;
        public int NumerDomu;
        public int? NumerMieszkania;

        public override string ToString()
        {
            return Miasto + ", ul. " + Ulica + " " + NumerDomu + (NumerMieszkania.HasValue ? ("/" + NumerMieszkania) : "");
        }
    }

    //Definicja interfejsu i jego impementacja
    interface IPosiadaTelefonStacjonarny
    {
        int? NumerTelefonu { get; set; }
    }

    class OsobaZameldowana : Osoba, IPosiadaTelefonStacjonarny
    {
        public Adres AdresZameldowania;

        public override string ToString()
        {
            return base.ToString() + "; " + AdresZameldowania.ToString();
        }

        private int? numerTelefonu;

        public int? NumerTelefonu
        {
            get
            {
                return numerTelefonu;
            }
            set
            {
                numerTelefonu = value;
            }
        }

        public bool CzyPosiadaTelefonStacjonarny
        {
            get
            {
                return numerTelefonu.HasValue;
            }
        }
    }
}
