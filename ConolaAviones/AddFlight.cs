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
        FlightPlanList flightplans;
        public AddFlightForm()
        {
            InitializeComponent();
        }

        public void SetFlightPlans(FlightPlanList flightplans)
        {
            this.flightplans = flightplans;
        }


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

                // El ID y la compañía no pueden estar vacíos ni tener espacios
                // (si tuvieran espacios, el fichero guardado no se podría volver a cargar)
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
                // Comprobar que el vuelo no existe
                for (int i = 0; i < flightplans.GetNumber(); i++)
                {
                    if (flightplans.GetFlightPlan(i).GetId() == id)
                    {
                        MessageBox.Show("A flight with this ID already exists.");
                        return;
                    }
                }

                FlightPlan newFlight = new FlightPlan(id, company, x1, y1, x2, y2, speed);
                flightplans.AddFlightPlan(newFlight);
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

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
