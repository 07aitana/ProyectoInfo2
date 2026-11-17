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
    public partial class MainForm : Form
    {
        FlightPlanList flightplans = new FlightPlanList();
        FlightDataForm F2;
        double cycleTime;
        double safetyDistance;
        bool settingsLoaded;
        // constructor del menu principal
        public MainForm()
        {
            InitializeComponent();
        }

        // no hace nada al cargar
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Deja elegir un fichero de vuelos con un selector y lo carga.
        // Muestra un mensaje diferente según el resultado de la carga.
        private void LoadFlightsBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.Title = "Select a flight data file";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string nombreFichero = openFileDialog1.FileName;

                    int resultado = flightplans.LoadFlightPlans(nombreFichero);

                    if (resultado == 0)
                    {
                        MessageBox.Show(flightplans.GetNumber() + " flights loaded successfully.");
                    }
                    else if (resultado == -1)
                    {
                        MessageBox.Show("The file does not exist.");
                    }
                    else if (resultado == -2)
                    {
                        MessageBox.Show("The file does not contain any flight.");
                    }
                    else if (resultado == -3)
                    {
                        MessageBox.Show("The file has a wrong line. Each line must be:\nID Company Xinitial Yinitial Xfinal Yfinal Speed\n(speed must be greater than 0).\nNo flights have been loaded.");
                    }
                    else
                    {
                        MessageBox.Show("The file has two flights with the same ID. No flights have been loaded.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error loading the file. Please check its contents.");
                }
            }
        }

        // abre el formulario de settings y guarda la distancia de seguridad y el tiempo de ciclo
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            using (SettingsForm settings = new SettingsForm())
            {
                if (settings.ShowDialog(this) == DialogResult.OK)
                {
                    cycleTime = settings.GetCycleTime();
                    safetyDistance = settings.GetSafetyDistance();
                    settingsLoaded = true;
                }
            }
        }

        // comprueba que hay vuelos y settings y abre la simulacion
        private void SimulationBtn_Click(object sender, EventArgs e)
        {

            // Comprobar que se han introducido Safety Distance y Cycle Time
            if (!settingsLoaded)
            {
                MessageBox.Show("First enter the safety distance and cycle time.");
                return;
            }


            // Comprobar que los dos Flight Plans existen
            if (flightplans.GetNumber() == 0)
            {
                MessageBox.Show("You must load the flight plans first.");
                return;
            }

            // Abrir el formulario de simulación
            SimulationForm F4 = new SimulationForm();
            F4.SetInformation(flightplans, cycleTime, safetyDistance);
            F4.ShowDialog();
        }

        // abre el formulario para añadir un vuelo a mano
        private void AddFlightBtn_Click(object sender, EventArgs e)
        {
            AddFlightForm F5 = new AddFlightForm();
            F5.SetFlightPlans(flightplans);
            F5.ShowDialog();
        }
    }
}
