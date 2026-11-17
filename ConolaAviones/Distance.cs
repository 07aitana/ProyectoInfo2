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
    public partial class DistanceForm : Form
    {
        // constructor: muestra la distancia que recibe
        public DistanceForm(double distancia)
        {
            InitializeComponent();
            distanciaLbl.Text = "Distance: " + distancia.ToString("F2") + " km";
        }

        // cierra el formulario
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // no hace nada al cargar
        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
