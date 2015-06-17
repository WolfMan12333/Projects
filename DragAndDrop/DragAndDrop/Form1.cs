using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDrop
{
    public partial class Form1 : Form
    {
        object dragDropSource = null;
        private int indeksSource = -1;
        private const int promienProgowy = 30;
        private bool przeciaganie = false;
        private Point polozenieMyszy = new Point();

        public Form1()
        {
            InitializeComponent();

            //Wypełnianie list
            for (int i = 0; i < 10; i++)
            {
                listBox1.Items.Add("lista 1, pozycja " + i.ToString());
                listBox2.Items.Add("lista 2, pozycja " + i.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lbSender = sender as ListBox;
            //int indeks = lbSender.IndexFromPoint(e.X, e.Y);
            dragDropSource = sender; //przechowanie referencji dla DragOver
            //indeksSource = indeks;

            if (e.Button == MouseButtons.Left && (lbSender.SelectedIndices.Count > 0))
            {
                DragDropEffects operacja =
                lbSender.DoDragDrop(lbSender.SelectedItems, DragDropEffects.Copy | DragDropEffects.Move);
                if (operacja == DragDropEffects.Move)
                    //foreach (int indeks in lbSender.SelectedIndices)
                    for (int i = lbSender.SelectedItems.Count - 1; i >= 0; i--)
                        lbSender.Items.Remove(lbSender.SelectedItems[i]);

                //przeciaganie = true;
                //polozenieMyszy.X = e.X;
                //polozenieMyszy.Y = e.Y;
            }

            //usunięte polecenie czyszczące referencję dragDropSource
            dragDropSource = null;
        }

        private void listBox2_DragOver(object sender, DragEventArgs e)
        {
            if (sender == dragDropSource)
                e.Effect = DragDropEffects.None;
            else
                if ((e.KeyState & 8) == 8)
                    e.Effect = DragDropEffects.Copy;    //z CTRL
                else
                    e.Effect = DragDropEffects.Move;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DragDrop_1(object sender, DragEventArgs e)
        {
            ListBox lbSender = sender as ListBox;
            ListBox lbSource = dragDropSource as ListBox;
            int indeks = lbSender.IndexFromPoint(lbSender.PointToClient(new Point(e.X, e.Y)));
            if (indeks == -1) indeks = lbSender.Items.Count;
            //lbSender.Items.Insert(indeks, e.Data.GetData(DataFormats.Text).ToString());
            for (int i = lbSource.SelectedItems.Count - 1; i >= 0; i--)
                lbSender.Items.Insert(indeks, lbSource.Items[lbSource.SelectedIndices[i]]);
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ListBox lbSource = dragDropSource as ListBox;
            if (przeciaganie)
            {
                //int dx = e.X - polozenieMyszy.X;
                //int dy = e.Y - polozenieMyszy.Y;
                //if ((dx*dx+dy*dy) > promienProgowy*promienProgowy)
                //{
                //    //przeniesione z listBox1_MouseDown
                //    DragDropEffects operacja = lbSource.DoDragDrop(lbSource.Items[indeksSource], DragDropEffects.Copy | DragDropEffects.Move);
                //    if (operacja == DragDropEffects.Move)
                //        lbSource.Items.RemoveAt(indeksSource);
                //    przeciaganie = false;
                //    dragDropSource = null;
                //}

                if (indeksSource > -1) lbSource.SelectedIndex = indeksSource;
            }
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            przeciaganie = false;
        }
    }
}
