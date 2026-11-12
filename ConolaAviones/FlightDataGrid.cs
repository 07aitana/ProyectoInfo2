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
        FlightPlanList flightplans;
        int primeraFila = -1;
        public FlightDataGridForm()
        {
            InitializeComponent();
            
        }

        public void SetFlightPlans(FlightPlanList flightplans)
        {
            this.flightplans = flightplans;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            vuelosGrid.AllowUserToAddRows = false;

            vuelosGrid.ColumnCount = 4;
            vuelosGrid.RowCount = flightplans.GetNumber();

            vuelosGrid.Columns[0].HeaderText = "Id";
            vuelosGrid.Columns[1].HeaderText = "Speed (km/h)";
            vuelosGrid.Columns[2].HeaderText = "X";
            vuelosGrid.Columns[3].HeaderText = "Y";

            for (int i = 0; i < flightplans.GetNumber(); i++)
            {
                FlightPlan vuelo = flightplans.GetFlightPlan(i);

                vuelosGrid.Rows[i].Cells[0].Value = vuelo.GetId();
                vuelosGrid.Rows[i].Cells[1].Value = vuelo.GetVelocidad();
                vuelosGrid.Rows[i].Cells[2].Value = vuelo.GetCurrentPosition().GetX().ToString("F2");
                vuelosGrid.Rows[i].Cells[3].Value = vuelo.GetCurrentPosition().GetY().ToString("F2");
            }

            vuelosGrid.ClearSelection();
        }

        private void vuelosGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (primeraFila == -1)
            {
                primeraFila = e.RowIndex;
            }
            else
            {
                int segundaFila = e.RowIndex;

                if (primeraFila == segundaFila)
                {
                    MessageBox.Show("Please select two different flights.");
                    return;
                }

                FlightPlan vuelo1 = flightplans.GetFlightPlan(primeraFila);
                FlightPlan vuelo2 = flightplans.GetFlightPlan(segundaFila);

                double distancia = vuelo1.Distance(vuelo2);

                DistanceForm f7 = new DistanceForm(distancia);
                f7.Show();

                primeraFila = -1;
                vuelosGrid.ClearSelection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
