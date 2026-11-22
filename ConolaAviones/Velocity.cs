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
    public partial class Velocity : Form
    {
        double speed;
        FlightPlanList flightPlans;

        int selectedRowIndex = -1;

        // Sets up the form for changing flight speeds.
        public Velocity()
        {
            InitializeComponent();
        }

        // Returns the last speed read from the form in km/h.
        public double GetSpeed()
        {
            return this.speed;
        }

        // Sets the flightPlans whose speeds can be changed.
        public void SetFlightPlans(FlightPlanList flightPlans)
        {
            this.flightPlans = flightPlans;
        }

        // Checks the new speed and updates the selected flight and its table row (sender and e are unused).
        private void UpDateBtn_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex == -1)
            {
                MessageBox.Show("Please select a flight.");
                return;
            }

            try
            {
                speed = Convert.ToDouble(VelocityChangeBox.Text);

                if (speed <= 0)
                {
                    MessageBox.Show("Please enter a positive velocity.");
                    return;
                }

                string id = Convert.ToString(vuelosGrid.Rows[selectedRowIndex].Cells[0].Value);
                FlightPlan flight = flightPlans.FindFlightById(id);

                flight.SetSpeed(speed);

                vuelosGrid.Rows[selectedRowIndex].Cells[1].Value = speed;

                MessageBox.Show("Velocity updated successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid velocity.");
            }
        }

        // Fills the table with the flights, their speeds and positions (sender and e are unused).
        private void Velocity_Load(object sender, EventArgs e)
        {
            vuelosGrid.AllowUserToAddRows = false;
            vuelosGrid.ReadOnly = true;

            vuelosGrid.ColumnCount = 4;
            vuelosGrid.RowCount = flightPlans.GetFlightCount();

            vuelosGrid.Columns[0].HeaderText = "Id";
            vuelosGrid.Columns[1].HeaderText = "Speed (km/h)";
            vuelosGrid.Columns[2].HeaderText = "X";
            vuelosGrid.Columns[3].HeaderText = "Y";

            for (int i = 0; i < flightPlans.GetFlightCount(); i++)
            {
                FlightPlan flight = flightPlans.GetFlightPlan(i);

                vuelosGrid.Rows[i].Cells[0].Value = flight.GetId();
                vuelosGrid.Rows[i].Cells[1].Value = flight.GetSpeed();
                vuelosGrid.Rows[i].Cells[2].Value =
                    flight.GetCurrentPosition().GetX().ToString("F2");
                vuelosGrid.Rows[i].Cells[3].Value =
                    flight.GetCurrentPosition().GetY().ToString("F2");
            }

            vuelosGrid.ClearSelection();
        }

        // Saves the row number from e so the right flight is updated (sender is unused).
        private void vuelosGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
            }
            else
            {
                MessageBox.Show("Please click on a flight, not on the header.");
            }
        }
    }
}
