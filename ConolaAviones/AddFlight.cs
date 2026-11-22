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
    public partial class AddFlightForm : Form
    {
        FlightPlanList flightPlans;

        // Sets up the form for adding a flight.
        public AddFlightForm()
        {
            InitializeComponent();
        }

        // Uses flightPlans as the list where new flights are added.
        public void SetFlightPlans(FlightPlanList flightPlans)
        {
            this.flightPlans = flightPlans;
        }

        // Checks the form and adds the flight if its ID is new (sender and e are unused).
        private void AddFlightBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = IDBox.Text;
                string company = CompanyBox.Text;
                double x1 = Convert.ToDouble(X1Box.Text);
                double y1 = Convert.ToDouble(Y1Box.Text);
                double x2 = Convert.ToDouble(X2Box.Text);
                double y2 = Convert.ToDouble(Y2Box.Text);
                double speed = Convert.ToDouble(SpeedBox.Text);

                // The flight file uses spaces to separate fields.
                if (id == "" || company == "" || id.Contains(" ") || company.Contains(" "))
                {
                    MessageBox.Show("The ID and the airline cannot be empty or contain spaces.");
                    return;
                }

                if (speed <= 0)
                {
                    MessageBox.Show("The speed must be greater than 0.");
                    return;
                }
                for (int i = 0; i < flightPlans.GetFlightCount(); i++)
                {
                    if (flightPlans.GetFlightPlan(i).GetId() == id)
                    {
                        MessageBox.Show("A flight with this ID already exists.");
                        return;
                    }
                }

                FlightPlan newFlight = new FlightPlan(id, company, x1, y1, x2, y2, speed);
                flightPlans.AddFlight(newFlight);
                MessageBox.Show("Flight added successfully");
                IDBox.Clear();
                CompanyBox.Clear();
                X1Box.Clear();
                Y1Box.Clear();
                X2Box.Clear();
                Y2Box.Clear();
                SpeedBox.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding the flight. Please check the input values.");
            }
        }

        // Fills the boxes with an example flight (sender and e are unused).
        private void AutoFilBtn_Click(object sender, EventArgs e)
        {
            IDBox.Text = "IB123";
            CompanyBox.Text = "Iberia";

            X1Box.Text = "10";
            Y1Box.Text = "20";

            X2Box.Text = "90";
            Y2Box.Text = "70";

            SpeedBox.Text = "600";
        }

        // Closes the form (sender and e are unused).
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
