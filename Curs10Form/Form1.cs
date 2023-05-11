using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs10Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyGraphics g = new MyGraphics();
        private void Form1_Load(object sender, EventArgs e)
        {
            g.InitGraph(pictureBox1);
            //Patrat(200, 200, 120);
            PrimaFRec(300,300,220);
            g.RefreshGraph();
        }

        public void Patrat(float x, float y, float l)
        {
            g.grp.DrawLine(Pens.Black, x - l/ 2, y - l/ 2, x + l/2, y - l/2);
            g.grp.DrawLine(Pens.Black, x + l/2, y - l/2, x + l/2, y + l/2);
            g.grp.DrawLine(Pens.Black, x + l/2, y + l/2, x - l/2, y + l/2);
            g.grp.DrawLine(Pens.Black, x - l/2, y + l/2, x - l/2, y - l/2);
        }

        public void PrimaFRec(float x, float y, float l)
        {
            if (l > 3)
            {
                Patrat(x, y, l);
                PrimaFRec(x - l / 2, y - l / 2, l / 2);
                PrimaFRec(x + l / 2, y - l / 2, l / 2);
                PrimaFRec(x - l / 2, y + l / 2, l / 2);
                PrimaFRec(x + l / 2, y + l / 2, l / 2);
            }
        }
    }
}
