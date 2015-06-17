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
    public partial class Form1 : Form
    {
        private bool daneZmienione = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adresyDataSet.Osoby' table. You can move, or remove it, as needed.
            this.osobyTableAdapter.Fill(this.adresyDataSet.Osoby);

            daneZmienione = false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            daneZmienione = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!daneZmienione) return;
            switch (MessageBox.Show("Czy zapisac zmiany do bazy dancyh?", this.Text, MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    try
                    {
                        this.Validate();
                        this.osobyBindingSource.EndEdit();
                        this.osobyTableAdapter.Update(adresyDataSet.Osoby);
                        //MessageBox.Show("Dane zapisane do bazy");
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Zapisanie danych nie powiodło się (" + exc.Message + ")");
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            new Formularz().Show();
        }
    }
}
