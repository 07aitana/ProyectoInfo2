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
        Form2 F2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void planesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F2 = new Form2();
            F2.Show();
        }

        private void distanciaYTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 F3=new Form3();
            F3.Show();
        }

        private void airspaceAndInitialLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F2 == null)
            {
                MessageBox.Show("First enter the two flight plans.");
                return;
            }
            FlightPlan vuelo1 = F2.GetFlightPlan1();
            FlightPlan vuelo2 = F2.GetFlightPlan2();
           
            if (vuelo1 == null || vuelo2 == null)
            {
                MessageBox.Show("You must enter both flight plans first.");
                return;
            }

            Form4 F4 = new Form4(vuelo1, vuelo2);
            F4.Show();
        }
    }
}
                                