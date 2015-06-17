using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UstawieniaAplikacji.Properties;

namespace UstawieniaAplikacji
{
    public partial class Form1 : Form
    {
        Settings ustawienia = new Settings();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = ustawienia.Left;
            this.Top = ustawienia.Top;
            this.Width = ustawienia.Width;
            this.Height = ustawienia.Height;
            this.Text = ustawienia.Text;
        }

        private void Form1_FormCLosed(object sender, FormClosedEventArgs e)
        {
            ustawienia.Left = this.Left;
            ustawienia.Top = this.Top;
            ustawienia.Width = this.Width;
            ustawienia.Height = this.Height;
            ustawienia.Text = this.Text;
            ustawienia.Save();
        }
    }
}
