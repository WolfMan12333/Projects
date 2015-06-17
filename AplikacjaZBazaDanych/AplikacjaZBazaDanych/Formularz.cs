using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaZBazaDanych
{
    public partial class Formularz : Form
    {
        public Formularz()
        {
            InitializeComponent();
        }

        private void Formularz_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adresyDataSet.Osoby' table. You can move, or remove it, as needed.
            this.osobyTableAdapter.Fill(this.adresyDataSet.Osoby);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wynikZapytania = from osoba in adresyDataSet.Osoby
                                 where osoba.Wiek > 18
                                 orderby osoba.Wiek
                                 select osoba.Imie + " " + osoba.Nazwisko + " (" + osoba.Wiek.ToString() + ")";

            string s = "Osoby pelnoletnie:\n";
            foreach (string element in wynikZapytania) s += element + "\n";
            MessageBox.Show(s);

            var pierwszyPelnolenti = adresyDataSet.Osoby.First(o => o.Wiek > 18);
        }
    }
}
