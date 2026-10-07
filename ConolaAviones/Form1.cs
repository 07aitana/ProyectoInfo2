using FlightLib;
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
        FlightPlanList lista = new FlightPlanList();

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

        private void airspaceAndInitialLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 F4 = new Form4(lista);
            F4.Show();
        }
    }
}
                                