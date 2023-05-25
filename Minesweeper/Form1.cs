using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n = 18;
        int m = 16;
        Button[,] gMatrix;
        bool[,] b;
        int k = 20;
        int[,] a; 
        static Random rnd = new Random();

        void PA(int i, int j)
        {
            if(i >= 0 && j>=0 && i < n && j < m && !b[i,j])
            {
                if(a[i,j] == 0)
                {
                    b[i, j] = true;
                    PA(i - 1, j);
                    PA(i, j + 1);
                    PA(i + 1, j);
                    PA(i, j - 1);
                }
                else
                {
                    b[i, j] = true;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int t = 0;
            a = new int[n, m];
            b = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = -1;
                    t++;
                    if (t >= k) break;
                }
                if (t >= k) break;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int l1 = rnd.Next(n);
                    int c1 = rnd.Next(m);
                    int l2 = rnd.Next(n);
                    int c2 = rnd.Next(m);
                    int aux = a[l1, c1];
                    a[l1, c1] = a[l2, c2];
                    a[l2, c2] = aux;
                }
            }
            
            int[] d1 = {-1,-1,-1,0,1,1,1,0};
            int[] d2 = { -1, 0, 1, 1, 1, 0, -1, -1 };

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    if (a[i, j] == 0)
                    { 
                        int s = 0;
                        for (int k = 0; k < d1.Length; k++)
                        {
                            if (i + d1[k] >= 0 && j + d2[k] >= 0 && i + d1[k] < n && j + d2[k] < m)
                                if (a[i + d1[k], j + d2[k]] == -1) s++;
                        }
                        a[i, j] = s;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                string s = "";
                for (int j = 0; j < m; j++)
                { 
                    s += a[i, j];
                    s += " "; 
                }
                listBox1.Items.Add(s);
            }
            gMatrix = new Button[n,m];
            for (int i = 0;i<n;i++)
                for (int j = 0; j < m; j++)
                {
                    gMatrix[i, j] = new Button();
                    gMatrix[i, j].Size = new Size(40, 40);
                    gMatrix[i, j].Location = new Point(i*42,j*42);
                    gMatrix[i, j].Parent = panel1;
                }
        }
    }
}
