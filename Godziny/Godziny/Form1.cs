using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Godziny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Hide();
            timer1.Enabled = false;
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            timer1.Enabled = true;
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Close();
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIcon1.Text = "Godziny .NET 5 (" + DateTime.Now.ToShortDateString() + ")";
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string s = "Aktualna data: " + DateTime.Today.ToLongDateString();
            string[] DniTygodnia = { "Niedziela", "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota" };
            byte numerDniaTYgodnia = (byte)DateTime.Now.DayOfWeek;
            s += "\nDzień tygodnia: " + DniTygodnia[numerDniaTYgodnia];
            s += "\nDzień roku: " + DateTime.Now.DayOfYear;
            s += "\nAktualny czas: " + DateTime.Now.ToLongTimeString();
            s += "\n\n(c) Dawid Wordliczek 2015";
            notifyIcon1.BalloonTipText = s;
            notifyIcon1.ShowBalloonTip(20 * 1000);
        }
    }
}
