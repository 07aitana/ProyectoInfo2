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
        FlightPlanList flightplans = new FlightPlanList();
        FlightDataForm F2;
        double cycleTime;
        double safetyDistance;
        bool settingsLoaded;
        public MainForm()
        {
            InitializeComponent();
            ConfigureSubtitle(LoadFlightsBtn, label3);
            ConfigureSubtitle(SimulationBtn, label4);
            ConfigureSubtitle(AddFlightBtn, label5);
            ConfigureSubtitle(SettingsBtn, label6);
        }

        // Draw the subtitle on the button so its whole surface shares hover/click effects.
        private void ConfigureSubtitle(Button button, Label subtitle)
        {
            subtitle.Visible = false;
            button.AccessibleDescription = subtitle.Text;
            button.Paint += (sender, e) =>
            {
                Rectangle bounds = button.ClientRectangle;
                bounds.Y = bounds.Height / 2;
                bounds.Height = button.ClientSize.Height - bounds.Y - 4;
                TextRenderer.DrawText(e.Graphics, subtitle.Text, subtitle.Font, bounds,
                    button.Enabled ? button.ForeColor : SystemColors.GrayText,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadFlightsBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.Title = "Select a flight data file";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string nombreFichero = openFileDialog1.FileName;

                    flightplans.LoadFlightPlans(nombreFichero);

                    MessageBox.Show("Flights loaded successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error loading the file. Please check its contents.");
                }
            }
        }

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
            F4.Show();
        }

        private void AddFlightBtn_Click(object sender, EventArgs e)
        {
            AddFlightForm F5 = new AddFlightForm();
            F5.SetFlightPlans(flightplans);
            F5.Show();
        }
    }
}
                                