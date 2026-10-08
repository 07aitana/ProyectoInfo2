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
        Form3 F3;
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
            F3= new Form3();
            F3.Show();
        }

        private void airspaceAndInitialLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Comprobar que se han introducido los Flight Plans
            if (F2 == null)
            {
                MessageBox.Show("First enter the two flight plans.");
                return;
            }

            // Comprobar que se han introducido Safety Distance y Cycle Time
            if (F3 == null)
            {
                MessageBox.Show("First enter the safety distance and cycle time.");
                return;
            }

            // Obtener los dos Flight Plans del Form2
            FlightPlan vuelo1 = F2.GetFlightPlan1();
            FlightPlan vuelo2 = F2.GetFlightPlan2();
            

            // Comprobar que los dos Flight Plans existen
            if (vuelo1 == null || vuelo2 == null)
            {
                MessageBox.Show("You must enter both flight plans first.");
                return;
            }

            // Obtener el Cycle Time del Form3
            double cycleTime = F3.GetCycleTime();
            double safetyDistance = F3.GetSafetyDistance();

            // Abrir el formulario de simulación
            Form4 F4 = new Form4(vuelo1, vuelo2, cycleTime, safetyDistance);
            F4.Show();
        }
    }
}
                                