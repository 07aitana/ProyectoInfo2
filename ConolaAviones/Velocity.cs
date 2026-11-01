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


    public partial class Velocity : Form
    {
        double velocidad;

        string id;
        public Velocity()
        {
            InitializeComponent();
        }
        public double GetVelocidad()
        {
            return this.velocidad;
        }

        public string GetId()
        {
            return this.id;
        }

        private void UpDateBtn_Click(object sender, EventArgs e)
        {
            velocidad= Convert.ToDouble(VelocityChangeBox.Text);
            id = FlightPlanBox.Text;
            MessageBox.Show("Velocity updated successfully.");
            Close();

        }
    }

}
