using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConolaAviones
{
    public partial class Form3 : Form
    {

        double SafetyDistance;
        double CycleTime;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

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
                SafetyDistance = Convert.ToDouble(txtSafetyDistance.Text);
                CycleTime = Convert.ToDouble(txtCycleTime.Text);

                if (SafetyDistance <= 0 || CycleTime <= 0)
                {
                    MessageBox.Show("Values must be greater than zero.");
                    return;
                }

                MessageBox.Show("Parameters loaded correctly.");

                txtSafetyDistance.Clear();
                txtCycleTime.Clear();
                this.Close();
            }
            catch
            {
                MessageBox.Show("The numerical data are not correct.");
            }
        }

        public double GetSafetyDistance()
        {
            return SafetyDistance;
        }

        public double GetCycleTime()
        {
            return CycleTime;
        }

    }
}
