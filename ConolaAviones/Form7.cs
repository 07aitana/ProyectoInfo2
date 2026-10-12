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
    public partial class Form7 : Form
    {
        public Form7(double distancia)
        {
            InitializeComponent();
            distanciaLbl.Text = "Distance: " + distancia.ToString("F2") + " km";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
