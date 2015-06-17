using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LINQ_to_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //definiowanie obiektów

            //XDocument xml = new XDocument(
            //    new XDeclaration("1.0", "utf-8", "yes"),
            //    new XComment("Parametry aplikacji"),
            //    new XElement("opcje",
            //        new XAttribute("nazwa", this.Text),
            //        new XElement("pozycja",
            //            new XElement("X", this.Left),
            //            new XElement("Y", this.Top)
            //            ),
            //    new XElement("wielkosc",
            //        new XElement("Szer", this.Width),
            //        new XElement("Wys", this.Height)
            //        )
            //        )
            //        );

            XDocument xml = new XDocument();
            XDeclaration deklaracja = new XDeclaration("1.0", "utf-8", "yes");
            XComment komentarz = new XComment("Parametry aplikacji");
            XElement opcje = new XElement("opcje");
            XElement okno = new XElement("okno");
            XAttribute nazwa = new XAttribute("nazwa", this.Text);
            XElement pozycja = new XElement("pozycja");
            XElement X = new XElement("X", this.Left);
            XElement Y = new XElement("Y", this.Top);
            XElement wielkosc = new XElement("wielkosc");
            XElement Szer = new XElement("Szer", this.Width);
            XElement Wys = new XElement("Wys", this.Height);

            //budowanie drzewa (od gałęzi)
            pozycja.Add(X);
            pozycja.Add(Y);
            wielkosc.Add(Szer);
            wielkosc.Add(Wys);
            okno.Add(nazwa);
            okno.Add(pozycja);
            okno.Add(wielkosc);
            okno.Add(okno);

            xml.Declaration = deklaracja;
            xml.Add(komentarz);
            xml.Add(opcje);

            //zapis do pliku
            xml.Save("Ustawienia.xml");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                XDocument xml = XDocument.Load("Ustawienia.xml");

                //odczytywanie okna
                this.Text = xml.Root.Element("okno").Attribute("nazwa").Value;

                //odczytanie pozycji i wielkości
                XElement pozycja = xml.Root.Element("okno").Element("pozycja");
                this.Left = int.Parse(pozycja.Element("X").Value);
                this.Top = int.Parse(pozycja.Element("Y").Value);

                XElement wielkosc = xml.Root.Element("okno").Element("wielkosc");
                this.Width = int.Parse(wielkosc.Element("Szer").Value);
                this.Height = int.Parse(wielkosc.Element("Wys").Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad podczas odczytywania pliku XML:\n" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XDocument xml = XDocument.Load("Ustawienia.xml");

            //wersja XML
            string wersja = xml.Declaration.Version;
            MessageBox.Show("Wersja XML: " + wersja);

            //odczytanie nazwy głównego elementu
            string nazwaElementuGlownego = xml.Root.Name.LocalName;
            MessageBox.Show("Nazwa elementu glownego: " + nazwaElementuGlownego);

            //kolekcja podelementow ze wszystkich poziomow drzewa
            IEnumerable<XElement> wszystkiePodelementy = xml.Root.Descendants();
            string s = "Wszystkie podelementy:\n";
            foreach (XElement podelement in wszystkiePodelementy) s += podelement.Name + "\n";
            MessageBox.Show(s);

            //kolekcja podelementow elementu okno
            IEnumerable<XElement> podelementyOkno = xml.Root.Element("okno").Elements();
            s = "Podelementy elementu okno:\n";
            foreach (XElement podelement in podelementyOkno) s += podelement.Name + "\n";
            MessageBox.Show(s);
        }

        private void  DodajElementDoWezla(XElement elementXml, TreeNode wezelDrzewa, int poziom)
        {
            poziom++;

            IEnumerable<XElement> elementy = elementXml.Elements();
            foreach (XElement element in elementy)
            {
                string opis = element.Name.LocalName;
                if (!element.HasElements) opis += " (" + element.Value + ")";
                TreeNode nowyWezel = new TreeNode(opis);
                wezelDrzewa.Nodes.Add(nowyWezel);
                DodajElementDoWezla(element, nowyWezel, poziom);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument xml = XDocument.Load("http://www.nbp.pl/kursy/xml/LastC.xml");

                treeView1.BeginUpdate();
                treeView1.Nodes.Clear();

                TreeNode wezelGlowny = new TreeNode(xml.Root.Name.LocalName);
                DodajElementDoWezla(xml.Root, wezelGlowny, 0);
                treeView1.Nodes.Add(wezelGlowny);
                wezelGlowny.ExpandAll();
                treeView1.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad podczas odczytywania pliku XML:\n" + ex.Message);
            }
        }
    }
}
