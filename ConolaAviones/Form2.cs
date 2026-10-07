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
    public partial class Form2 : Form
    {
        FlightPlan flightPlan1;
        FlightPlan flightPlan2;
        int contador = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Comprobar que todos los campos estén rellenados
            if (txtId.Text == "" ||
                txtCurrentX.Text == "" ||
                txtCurrentY.Text == "" ||
                txtFinalX.Text == "" ||
                txtFinalY.Text == "" ||
                txtVelocidad.Text == "")
            {
                MessageBox.Show("All fields must be completed.");
                return;
            }

            try
            {
                // Leer los datos introducidos
                string id = txtId.Text;

                double currentX = Convert.ToDouble(txtCurrentX.Text);
                double currentY = Convert.ToDouble(txtCurrentY.Text);
                double finalX = Convert.ToDouble(txtFinalX.Text);
                double finalY = Convert.ToDouble(txtFinalY.Text);
                double velocidad = Convert.ToDouble(txtVelocidad.Text);

                // Cargar el primer FlightPlan
                if (contador == 0)
                {
                    flightPlan1 = new FlightPlan(id, currentX, currentY, finalX, finalY, velocidad);

                    contador++;

                    MessageBox.Show("First flight plan loaded");

                    // Limpiar los TextBox
                    txtId.Clear();
                    txtCurrentX.Clear();
                    txtCurrentY.Clear();
                    txtFinalX.Clear();
                    txtFinalY.Clear();
                    txtVelocidad.Clear();
                }

                // Cargar el segundo FlightPlan
                else if (contador == 1)
                {
                    flightPlan2 = new FlightPlan(id, currentX, currentY, finalX, finalY, velocidad);

                    contador++;

                    MessageBox.Show("Second flight plan loaded");

                    // Limpiar los TextBox
                    txtId.Clear();
                    txtCurrentX.Clear();
                    txtCurrentY.Clear();
                    txtFinalX.Clear();
                    txtFinalY.Clear();
                    txtVelocidad.Clear();
                }
            }
            catch
            {
                MessageBox.Show("The numerical data are not correct.");
            }
        }

        public FlightPlan GetFlightPlan1()
        {
            return flightPlan1;
        }

        public FlightPlan GetFlightPlan2()
        {
            return flightPlan2;

        }
        
    
    }

}º2