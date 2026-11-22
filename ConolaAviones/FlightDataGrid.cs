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
    public partial class FlightDataGridForm : Form
    {
        FlightPlanList flightPlans;

        // Sets up the flight table form.
        public FlightDataGridForm()
        {
            InitializeComponent();
        }

        // Sets the flightPlans to show in the table.
        public void SetFlightPlans(FlightPlanList flightPlans)
        {
            this.flightPlans = flightPlans;
        }

        // Fills the table with the flights and their current positions (sender and e are unused).
        private void FlightData_Load(object sender, EventArgs e)
        {
            vuelosGrid.AllowUserToAddRows = false;

            vuelosGrid.ColumnCount = 5;
            vuelosGrid.RowCount = flightPlans.GetFlightCount();

            vuelosGrid.Columns[0].HeaderText = "Id";
            vuelosGrid.Columns[1].HeaderText = "Airline";
            vuelosGrid.Columns[2].HeaderText = "Speed (km/h)";
            vuelosGrid.Columns[3].HeaderText = "X";
            vuelosGrid.Columns[4].HeaderText = "Y";

            for (int i = 0; i < flightPlans.GetFlightCount(); i++)
            {
                FlightPlan flight = flightPlans.GetFlightPlan(i);

                vuelosGrid.Rows[i].Cells[0].Value = flight.GetId();
                vuelosGrid.Rows[i].Cells[1].Value = flight.GetAirline();
                vuelosGrid.Rows[i].Cells[2].Value = flight.GetSpeed();
                vuelosGrid.Rows[i].Cells[3].Value = flight.GetCurrentPosition().GetX().ToString("F2");
                vuelosGrid.Rows[i].Cells[4].Value = flight.GetCurrentPosition().GetY().ToString("F2");
            }

            vuelosGrid.ClearSelection();
        }

        // Uses the row in e to show distances from that flight to the others (sender is unused).
        private void vuelosGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Please click on a flight, not on the header.");
                return;
            }

            string id = Convert.ToString(vuelosGrid.Rows[e.RowIndex].Cells[0].Value);
            FlightPlan vuelo1 = flightPlans.FindFlightById(id);

            string message = "Distances from flight " + vuelo1.GetId() + ":\n\n";

            for (int i = 0; i < flightPlans.GetFlightCount(); i++)
            {
                FlightPlan vuelo2 = flightPlans.GetFlightPlan(i);

                if (vuelo2.GetId() != vuelo1.GetId())
                {
                    double distancia = vuelo1.DistanceTo(vuelo2);

                    message += vuelo2.GetId() + ": " + distancia.ToString("F2") + "\n";
                }
            }

            MessageBox.Show(message, "Flight distances");
        }

        // Closes the flight table (sender and e are unused).
        
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
