using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.trackBar1_ValueChanged(this, null);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);

            //panel1.BackColor = Color.Purple;

            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\u001B') Close();
        }
    }
}
