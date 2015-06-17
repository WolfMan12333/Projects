using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace AplikacjaZBazaDanych
{
    

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            //pobieranie danych z tabeli
            AdresyDataContext bazaDanychAdresy = new AdresyDataContext();
            var listaOsob = bazaDanychAdresy.Osobas;

            InitializeComponent();

            dataGridView1.DataSource = bazaDanychAdresy.Osobas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pobieranie danych z tabeli
            AdresyDataContext bazaDanychAdresy = new AdresyDataContext();
            var listaOsob = bazaDanychAdresy.Osobas;

            //pobierani kolekcji
            var listaOsobPelnoletnich2 = from osoba in listaOsob
                                         where osoba.Wiek >= 30
                                         orderby osoba.Nazwisko
                                         select osoba;

            //wyświetlanie pobranej kolekcji
            string s = "Lista osob pelnoletnich:\n";
            foreach (Osoba osoba in listaOsobPelnoletnich2)
                s += osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")\n";
            MessageBox.Show(s);

            

            //pobieranie kolekcji
            var listaOsobPelnoletnich = from osoba in listaOsob
                                        where osoba.Wiek >= 18
                                        select osoba;

            //wyświetlanie pobranej kolekcji
            string s = "Lista osob pelnoletnich:\n";
            foreach (Osoba osoba in listaOsobPelnoletnich)
                s += osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")\n";
            MessageBox.Show(s);

            //informacje o pobranych danych
            MessageBox.Show("Typ: " + listaOsobPelnoletnich.GetType().FullName);
            MessageBox.Show("Ilosc pobranych rekordow: " + listaOsobPelnoletnich.Count().ToString());
            MessageBox.Show("Suma wieku wybranych osob: " + listaOsobPelnoletnich.Sum(osoba => osoba.Wiek).ToString());
            MessageBox.Show("Imie pierwszej osoby: " + listaOsobPelnoletnich.First().Imie);

            s = "Pelna lista osob:\n";
            foreach (Osoba osoba in listaOsob) s += osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")\n";
            MessageBox.Show(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pobieranie danych z tabeli
            AdresyDataContext bazaDanychAdresy = new AdresyDataContext();
            var listaOsob = bazaDanychAdresy.Osobas;

            //pobieranie kolekcji
            var listaOsobDoZmianyWieku = from osoba in listaOsob
                                         where (osoba.Wiek < 18 || !osoba.Imie.EndsWith("a"))
                                         select osoba;

            //wyświetlanie pobranej kolekcji
            string s = "Lista osob niebedacych pelnoletnimi kobietami:\n";
            foreach (Osoba osoba in listaOsobDoZmianyWieku) s += osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")\n";
            MessageBox.Show(s);

            //modyfikowanie kolekcji
            foreach (Osoba osoba in listaOsobDoZmianyWieku) osoba.Wiek++;

            //wyświetlanie pełnej listy osób kolekcji po zmianie
            s = "Lista wszystkich osob:\n";
            foreach (Osoba osoba in listaOsob) s += osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")\n";

            MessageBox.Show(s);

            //zapisywanie  zmian
            bazaDanychAdresy.SubmitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //pobieranie danych z tabeli
            AdresyDataContext bazaDanychAdresy = new AdresyDataContext();
            var listaOsob = bazaDanychAdresy.Osobas;

            //dodawanie osoby do tabeli
            int noweId = listaOsob.Max(osoba => osoba.Id) + 1;
            MessageBox.Show("Nowe Id: " + noweId);
            Osoba noworodek = new Osoba { Id = noweId, Imie = "Nela", Nazwisko = "Boderska", Email = "nb@bocian.pl", NumerTelefonu = null, Wiek = 0 };
            listaOsob.InsertOnSubmit(noworodek);

            //zapisywanie zmian
            bazaDanychAdresy.SubmitChanges();   //w bazie dodawany jest nowy rekord

            //wyświetlanie tabeli
            string s = "Lista osob:\n";
            foreach (Osoba osoba in listaOsob) s += osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")\n";
            MessageBox.Show(s);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //pobieranie danych z tabeli
            AdresyDataContext bazaDanychAdresy = new AdresyDataContext();
            var listaOsob = bazaDanychAdresy.Osobas;

            //wybieranie elementów do usunięcia i ich oznaczenie
            IEnumerable<Osoba> doSkasowania = from osoba in listaOsob
                                              where osoba.Imie == "Nela"
                                              select osoba;
            listaOsob.DeleteAllOnSubmit(doSkasowania);

            //zapisywanie zmian
            bazaDanychAdresy.SubmitChanges();

            //wyświetlanie tabeli
            string s = "Lista osob:\n";
            foreach (Osoba osoba in listaOsob) s += osoba.Imie + " " + osoba.Nazwisko + " ( " + osoba.Wiek + ")\n";
            MessageBox.Show(s);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            //pobieranie danych z tabeli
            AdresyDataContext bazaDanychAdresy = new AdresyDataContext();
            var listaOsob = bazaDanychAdresy.Osobas;
            var rozmowy = bazaDanychAdresy.Rozmowies;
            var listaDlugichRozmow = from rozmowa in rozmowy
                                     where rozmowa.CzasTrwania > 10
                                     select rozmowa.Osoba.Imie + " " +
                                     rozmowa.Osoba.Nazwisko + ", " +
                                     rozmowa.Data.ToString() + " (" + rozmowa.CzasTrwania + ")";

            IEnumerable<string> listDlugichRozmow =
                from osoba in listaOsob
                join rozmowa in rozmowy on osoba.Id equals rozmowa.Id
                where rozmowa.CzasTrwania > 10
                select osoba.Imie + " " + osoba.Nazwisko + ", " + rozmowa.Data.ToString() + " (" + rozmowa.CzasTrwania + ")";

            string s = "Lista rozmow trwajacych dluzej niz 10 sekund:\n";
            foreach (string opis in listaDlugichRozmow) s += opis + "\n";
            MessageBox.Show(s);

            var listaRozmowWincenterKostka = from rozmowa in rozmowy
                                             where rozmowa.Id == 3
                                             select rozmowa;

            IEnumerable<ListaOsobPelnoletnichResult> listaOsobPelnoletnich = bazaDanychAdresy.ListaOsobPelnoletnich();

            string s = "Lista osob pelnoletnich (prcoedura skladowana:\n";
            foreach (var osoba in listaOsobPelnoletnich)
                s += osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek + ")\n";
            MessageBox.Show(s);

            try
            {
                bazaDanychAdresy.TworzNowaTabele();
                MessageBox.Show("Tabela 'Faktury' zostala utworzona");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Blad podczas tworzenia tabeli 'Faktury' : " + exc.Message);
            }
        }
    }

    //[Table(Name = "Osoby")]
    //public class Osoba
    //{
    //    [Column(Name = "Id", IsPrimaryKey = true, CanBeNull = false)]
    //    public int Id;
    //    [Column(CanBeNull = false)]
    //    public string Imie;
    //    [Column(CanBeNull = false)]
    //    public string Nazwisko;
    //    [Column(CanBeNull = true)]
    //    public string Email;
    //    [Column(CanBeNull = true)]
    //    public int? NumerTelefonu;
    //    [Column(CanBeNull = false)]
    //    public int Wiek;

    //    const string connectionString = @"Data Source=(LocalDB)\11.0;AttachDbFilename=|DataDirectory|\Adresy.mdf;Integrated Security=True";
    //    static DataContext bazaDanychAdresy = new DataContext(connectionString);
    //    static Table<Osoba> listaOsob = bazaDanychAdresy.GetTable<Osoba>();
    //}
}
