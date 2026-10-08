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

namespace ConolaAviones
{
    public partial class Form5 : Form
    {
        FlightPlan vuelo;
        public Form5(FlightPlan vuelo)
        {
            InitializeComponent();
            this.vuelo = vuelo;
            CargarDatos();
        }
        private void CargarDatos()
        {
            dataGridView1.Columns.Add("Dato", "Dato");
            dataGridView1.Columns.Add("Valor", "Valor");

            double xActual = vuelo.GetCurrentPosition().GetX();
            double yActual = vuelo.GetCurrentPosition().GetY();

            double xFinal = vuelo.GetFinalPosition().GetX();
            double yFinal = vuelo.GetFinalPosition().GetY();

            dataGridView1.Rows.Add("ID", vuelo.GetId());

            dataGridView1.Rows.Add("Current X", xActual);
            dataGridView1.Rows.Add("Current Y", yActual);

            dataGridView1.Rows.Add("Final X", xFinal);
            dataGridView1.Rows.Add("Final Y", yFinal);

            dataGridView1.Rows.Add("Speed", vuelo.GetVelocidad());

            //entender cosas de la tabla 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.RowHeadersVisible = false;
        }
    }
}
