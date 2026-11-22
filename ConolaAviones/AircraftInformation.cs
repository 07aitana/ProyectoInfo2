using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace AirTrafficSimForms
{
    public partial class AircraftInformationForm : Form
    {
        FlightPlan flight;

        // Sets up the aircraft details form.
        public AircraftInformationForm()
        {
            InitializeComponent();
        }

        // Sets which flight the form shows.
        public void SetFlightPlan(FlightPlan flight)
        {
            this.flight = flight;
        }

        // Closes the form (sender and e are unused).

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Fills the details table and starts the update timer (sender and e are unused).
        private void AircraftInformation_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 7;

            dataGridView1.Columns[0].HeaderText = "Field";
            dataGridView1.Columns[1].HeaderText = "Value";

            dataGridView1.Rows[0].Cells[0].Value = "ID";
            dataGridView1.Rows[0].Cells[1].Value = flight.GetId();

            dataGridView1.Rows[1].Cells[0].Value = "Airline";
            dataGridView1.Rows[1].Cells[1].Value = flight.GetAirline();

            dataGridView1.Rows[2].Cells[0].Value = "Current X";
            dataGridView1.Rows[2].Cells[1].Value = Convert.ToString(flight.GetCurrentPosition().GetX());

            dataGridView1.Rows[3].Cells[0].Value = "Current Y";
            dataGridView1.Rows[3].Cells[1].Value = Convert.ToString(flight.GetCurrentPosition().GetY());

            dataGridView1.Rows[4].Cells[0].Value = "Final X";
            dataGridView1.Rows[4].Cells[1].Value = Convert.ToString(flight.GetDestination().GetX());

            dataGridView1.Rows[5].Cells[0].Value = "Final Y";
            dataGridView1.Rows[5].Cells[1].Value = Convert.ToString(flight.GetDestination().GetY());

            dataGridView1.Rows[6].Cells[0].Value = "Speed (km/h)";
            dataGridView1.Rows[6].Cells[1].Value = flight.GetSpeed();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;

            dataGridView1.RowHeadersVisible = false;

            RefreshFlightDetails();
            timer1.Start();
        }

        // Updates the flight ID, airline, position and speed shown in the table.
        private void RefreshFlightDetails()
        {
            dataGridView1.Rows[0].Cells[1].Value = flight.GetId();

            dataGridView1.Rows[1].Cells[1].Value = flight.GetAirline();

            dataGridView1.Rows[2].Cells[1].Value =
                flight.GetCurrentPosition().GetX().ToString("F2");

            dataGridView1.Rows[3].Cells[1].Value =
                flight.GetCurrentPosition().GetY().ToString("F2");

            dataGridView1.Rows[6].Cells[1].Value =
                flight.GetSpeed();
        }

        // Updates the table each time the timer fires (sender and e are unused).
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshFlightDetails();
        }

        
    }
}
