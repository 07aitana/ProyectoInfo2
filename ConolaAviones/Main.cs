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

namespace AirTrafficSimForms
{
    public partial class MainForm: Form
    {
        FlightDataForm F2;
        SettingsForm F3;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void planesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F2 = new FlightDataForm();
            F2.Show();
        }

        private void distanciaYTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F3= new SettingsForm();
            F3.Show();
        }

        private void airspaceAndInitialLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Comprobar que se han introducido los Flight Plans
            if (F2 == null)
            {
                MessageBox.Show("First load the flight plans");
                return;
            }

            // Comprobar que se han introducido Safety Distance y Cycle Time
            if (F3 == null)
            {
                MessageBox.Show("First enter the safety distance and cycle time.");
                return;
            }

            // Obtener los dos Flight Plans del Form2
            FlightPlanList flightplans = F2.GetFlightPlanList();
            
            

            // Comprobar que los dos Flight Plans existen
            if (flightplans.GetNumber () == 0)
            {
                MessageBox.Show("You must load the flight plans first.");
                return;
            }

            // Obtener el Cycle Time del Form3
            double cycleTime = F3.GetCycleTime();
            double safetyDistance = F3.GetSafetyDistance();

            // Abrir el formulario de simulación
            SimulationForm F4 = new SimulationForm();
            F4. SetInformation (flightplans, cycleTime, safetyDistance);
            F4.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
                                