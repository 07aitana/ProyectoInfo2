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
        FlightPlan vuelo;
        // constructor del formulario
        public AircraftInformationForm()
        {
            InitializeComponent();
            
        }

        // recibe el vuelo del que se mostraran los datos
        public void SetFlightPlan(FlightPlan vuelo)
        {
            this.vuelo = vuelo;
            
        }
        

        // cierra el formulario
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // prepara la tabla con los datos del vuelo y arranca el timer para actualizarlos
        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 7; 


            // Nombres de las columnas
            dataGridView1.Columns[0].HeaderText = "Dato";
            dataGridView1.Columns[1].HeaderText = "Valor";

            // Identificador
            dataGridView1.Rows[0].Cells[0].Value = "ID";
            dataGridView1.Rows[0].Cells[1].Value = vuelo.GetId();

            // Compañía aérea
            dataGridView1.Rows[1].Cells[0].Value = "Airline";
            dataGridView1.Rows[1].Cells[1].Value = vuelo.GetCompany();

            // Posición actual
            dataGridView1.Rows[2].Cells[0].Value = "Current X";
            dataGridView1.Rows[2].Cells[1].Value = Convert.ToString(vuelo.GetCurrentPosition().GetX());

            dataGridView1.Rows[3].Cells[0].Value = "Current Y";
            dataGridView1.Rows[3].Cells[1].Value = Convert.ToString(vuelo.GetCurrentPosition().GetY());

            // Posición final
            dataGridView1.Rows[4].Cells[0].Value = "Final X";
            dataGridView1.Rows[4].Cells[1].Value = Convert.ToString(vuelo.GetFinalPosition().GetX());

            dataGridView1.Rows[5].Cells[0].Value = "Final Y";
            dataGridView1.Rows[5].Cells[1].Value = Convert.ToString(vuelo.GetFinalPosition().GetY());

            // Velocidad
            dataGridView1.Rows[6].Cells[0].Value = "Speed";
            dataGridView1.Rows[6].Cells[1].Value = vuelo.GetVelocidad();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            
            dataGridView1.RowHeadersVisible = false;

            ActualizarDatos();
            timer1.Start();
        }
        // actualiza en la tabla los datos que cambian (posicion y velocidad)
        private void ActualizarDatos()
        {
            // Identificador
            dataGridView1.Rows[0].Cells[1].Value = vuelo.GetId();

            // Companyia
            dataGridView1.Rows[1].Cells[1].Value = vuelo.GetCompany();

            // Posició actual
            dataGridView1.Rows[2].Cells[1].Value =
                vuelo.GetCurrentPosition().GetX();

            dataGridView1.Rows[3].Cells[1].Value =
                vuelo.GetCurrentPosition().GetY();

            // Velocitat
            dataGridView1.Rows[6].Cells[1].Value =
                vuelo.GetVelocidad();
        }

        // cada tick vuelve a mostrar los datos actualizados
        private void timer1_Tick(object sender, EventArgs e)
        {
            ActualizarDatos();
        }
    }

}

