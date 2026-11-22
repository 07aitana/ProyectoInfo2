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
    public partial class SettingsForm : Form
    {
        double SafetyDistance;
        double CycleTime;

        // Sets up the simulation settings form.
        public SettingsForm()
        {
            InitializeComponent();
        }

        // Saves the safety distance and cycle time if both are finite and above zero (sender and e are unused).
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtSafetyDistance.Text == "" ||
                txtCycleTime.Text == "")
            {
                MessageBox.Show("All fields must be completed.");
                return;
            }

            try
            {
                double safetyDistance = Convert.ToDouble(txtSafetyDistance.Text);
                double cycleTime = Convert.ToDouble(txtCycleTime.Text);

                if (double.IsNaN(safetyDistance) || double.IsInfinity(safetyDistance) ||
                    double.IsNaN(cycleTime) || double.IsInfinity(cycleTime) ||
                    safetyDistance <= 0 || cycleTime <= 0)
                {
                    MessageBox.Show("Values must be greater than zero.");
                    return;
                }

                SafetyDistance = safetyDistance;
                CycleTime = cycleTime;

                MessageBox.Show("Parameters loaded correctly.");

                txtSafetyDistance.Clear();
                txtCycleTime.Clear();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("The numerical data are not correct.");
            }
        }

        // Returns the safety distance in kilometers.
        public double GetSafetyDistance()
        {
            return SafetyDistance;
        }

        // Returns the length of one simulation step in minutes.
        public double GetCycleTime()
        {
            return CycleTime;
        }
    }
}
