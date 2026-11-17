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
        FlightPlanList flightplans;

        int filaseleccionada = -1;

        
        // constructor del formulario
        public Velocity()
        {
            InitializeComponent();
        }
        // devuelve la ultima velocidad introducida
        public double GetVelocidad()
        {
            return this.velocidad;
        }

        // recibe la lista de vuelos
        public void SetFlightPlans(FlightPlanList flightplans)
        {
            this.flightplans = flightplans;
        }

        // cambia la velocidad del vuelo seleccionado si el valor es correcto
        private void UpDateBtn_Click(object sender, EventArgs e)
        {
            if (filaseleccionada == -1)
            {
                MessageBox.Show("Please select a flight.");
                return;
            }

            try
            {
                velocidad = Convert.ToDouble(VelocityChangeBox.Text);

                if (velocidad <= 0)
                {
                    MessageBox.Show("Please enter a positive velocity.");
                    return;
                }

                FlightPlan vuelo = flightplans.GetFlightPlan(filaseleccionada);

                vuelo.SetVelocidad(velocidad);

                vuelosGrid.Rows[filaseleccionada].Cells[1].Value = velocidad;

                MessageBox.Show("Velocity updated successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid velocity.");
            }

        }


        // rellena la tabla con los vuelos y sus velocidades
        private void Velocity_Load(object sender, EventArgs e)
        {
            vuelosGrid.AllowUserToAddRows = false;
            vuelosGrid.ReadOnly = true;

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
                vuelosGrid.Rows[i].Cells[2].Value =
                    vuelo.GetCurrentPosition().GetX().ToString("F2");
                vuelosGrid.Rows[i].Cells[3].Value =
                    vuelo.GetCurrentPosition().GetY().ToString("F2");
            }

            vuelosGrid.ClearSelection();
        }

        // guarda que fila (vuelo) ha seleccionado el usuario
        private void vuelosGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filaseleccionada = e.RowIndex;
            }

        }
    }

}
