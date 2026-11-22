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
        FlightPlanList flightPlans = new FlightPlanList();
        double cycleTime;
        double safetyDistance;
        bool settingsLoaded;

        // Sets up the main menu.
        public MainForm()
        {
            InitializeComponent();
        }

        // Lets the user choose a flight file and shows whether it loaded (sender and e are unused).
        private void LoadFlightsBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.Title = "Select a flight data file";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;

                    int result = flightPlans.LoadFlights(filePath);

                    if (result == 0)
                    {
                        MessageBox.Show(flightPlans.GetFlightCount() + " flights loaded successfully.");
                    }
                    else if (result == -1)
                    {
                        MessageBox.Show("The file does not exist.");
                    }
                    else if (result == -2)
                    {
                        MessageBox.Show("The file does not contain any flight.");
                    }
                    else if (result == -3)
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

        // Opens settings and saves the values if the user confirms (sender and e are unused).
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();

            if (settings.ShowDialog() == DialogResult.OK)
            {
                cycleTime = settings.GetCycleTime();
                safetyDistance = settings.GetSafetyDistance();
                settingsLoaded = true;
            }
        }

        // Starts the simulation if flights and settings are ready (sender and e are unused).
        private void SimulationBtn_Click(object sender, EventArgs e)
        {
            if (!settingsLoaded)
            {
                MessageBox.Show("First enter the safety distance and cycle time.");
                return;
            }

            if (flightPlans.GetFlightCount() == 0)
            {
                MessageBox.Show("You must load the flight plans first.");
                return;
            }

            SimulationForm simulationForm = new SimulationForm();
            simulationForm.ConfigureSimulation(flightPlans, cycleTime, safetyDistance);
            simulationForm.ShowDialog();
        }

        // Opens the form for adding a flight by hand (sender and e are unused).
        private void AddFlightBtn_Click(object sender, EventArgs e)
        {
            AddFlightForm addFlightForm = new AddFlightForm();
            addFlightForm.SetFlightPlans(flightPlans);
            addFlightForm.ShowDialog();
        }
    }
}
