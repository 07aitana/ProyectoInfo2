using FlightLib;
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
    public partial class Form4 : Form
    {
        FlightPlanList lista;
        public Form4(FlightPlanList lista)
        {
            InitializeComponent();
            this.lista=lista;
        }

        private void panelAirspace_Paint(object sender, PaintEventArgs e)
        {
            FlightPlan vuelo1 = lista.GetFlightPlan(0);
            FlightPlan vuelo2 = lista.GetFlightPlan(1);

            double x1 = vuelo1.GetCurrentPosition().GetX();
            double y1 = vuelo1.GetCurrentPosition().GetY();

            double x2 = vuelo2.GetCurrentPosition().GetX();
            double y2 = vuelo2.GetCurrentPosition().GetY();

            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.Black, 2);

            g.DrawRectangle(pen, 10, 10, panelAirspace.Width - 20, panelAirspace.Height - 20);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
