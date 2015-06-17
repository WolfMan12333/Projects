using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap bufor = null;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            bufor = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            for (int x = 0; x < this.ClientSize.Width; x++)
                for (int y = 0;  y < this.ClientSize.Height; y++)
                {
                    //Pen pioro = new Pen(Color.LemonCHiffon, 1);
                    int R = (int)(255 * 0.5 * (1 + Math.Sin(x / 10.0)));
                    int G = (int)(255 * 0.5 * (1 + Math.Sin(y / 10.0)));

                    //Pen pioro = new Pen(Color.FromArgb(R,G,0), 1);
                    //g.DrawLine(pioro, x, y, x + 1, y);

                    bufor.SetPixel(x, y, Color.FromArgb(R, G, 0));
                }

            g.DrawImage(bufor, 0, 0);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)19 && bufor != null)
            {
                string nazwaPliku = "Arras.png";
                bufor.Save(nazwaPliku);
                MessageBox.Show("Obraz zachowany w pliku " + nazwaPliku);
            }
        }
    }
}
