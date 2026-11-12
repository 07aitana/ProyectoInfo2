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
    public partial class FlightDataForm: Form
    {
        FlightPlanList flightplans = new FlightPlanList();
        

        public FlightDataForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreFichero = FileNameBox.Text;

                flightplans.LoadFlightPlans(nombreFichero);

                MessageBox.Show("Flights loaded successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the file. Please check the file name.");
            }

        }
        public FlightPlanList GetFlightPlanList()
        {
            return flightplans;
        }
        
    }

}