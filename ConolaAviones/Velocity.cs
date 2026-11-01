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
        double velocidad;

        FlightPlan vuelo1;

        FlightPlan vuelo2;

        int filaseleccionada = -1;

        string id;
        public Velocity()
        {
            InitializeComponent();
        }
        public double GetVelocidad()
        {
            return this.velocidad;
        }

        public void SetFlightPlans(FlightPlan vuelo1, FlightPlan vuelo2)
        {
            this.vuelo1 = vuelo1;
            this.vuelo2 = vuelo2;
        }

        private void UpDateBtn_Click(object sender, EventArgs e)
        {
            velocidad = Convert.ToDouble(VelocityChangeBox.Text);

            if (id == vuelo1.GetId())
            {
                vuelo1.SetVelocidad(velocidad);
            }
            else if (id == vuelo2.GetId())
            {
                vuelo2.SetVelocidad(velocidad);
            }

            vuelosGrid.Rows[filaseleccionada].Cells[1].Value = velocidad;

            MessageBox.Show("Velocity updated successfully");


        }


        private void Velocity_Load(object sender, EventArgs e)
        {
            vuelosGrid.ColumnCount = 4;
            vuelosGrid.RowCount = 2;
            vuelosGrid.Columns[0].HeaderText = "Id";
            vuelosGrid.Columns[1].HeaderText = "Speed (km/h)";
            vuelosGrid.Columns[2].HeaderText = "X";
            vuelosGrid.Columns[3].HeaderText = "Y";
            vuelosGrid.Rows[0].Cells[0].Value = vuelo1.GetId();
            vuelosGrid.Rows[0].Cells[1].Value = vuelo1.GetVelocidad();
            vuelosGrid.Rows[0].Cells[2].Value = vuelo1.GetCurrentPosition().GetX().ToString("F2");
            vuelosGrid.Rows[0].Cells[3].Value = vuelo1.GetCurrentPosition().GetY().ToString("F2");
            vuelosGrid.Rows[1].Cells[0].Value = vuelo2.GetId();
            vuelosGrid.Rows[1].Cells[1].Value = vuelo2.GetVelocidad();
            vuelosGrid.Rows[1].Cells[2].Value = vuelo2.GetCurrentPosition().GetX().ToString("F2");
            vuelosGrid.Rows[1].Cells[3].Value = vuelo2.GetCurrentPosition().GetY().ToString("F2");
        }

        private void vuelosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vuelosGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            filaseleccionada = e.RowIndex;
            if (filaseleccionada == 0)
            {
                id = vuelo1.GetId();
            }
            else if (filaseleccionada == 1)
            {
                id = vuelo2.GetId();
            }

        }
    }

}
