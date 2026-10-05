using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConolaAviones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void planesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 F2=new Form2();
            F2.Show();
        }

        private void distanciaYTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 F3=new Form3();
            F3.Show();
        }
    }
}
