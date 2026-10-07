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
        FlightPlan vuelo1;
        FlightPlan vuelo2;
        public Form4(FlightPlan vuelo1, FlightPlan vuelo2)
        {
            InitializeComponent();
            this.vuelo1 = vuelo1;
            this.vuelo2 = vuelo2;
        }

        private void panelAirspace_Paint(object sender, PaintEventArgs e)
        {
           

            double x1 = vuelo1.GetCurrentPosition().GetX();
            double y1 = vuelo1.GetCurrentPosition().GetY();

            double x2 = vuelo2.GetCurrentPosition().GetX();
            double y2 = vuelo2.GetCurrentPosition().GetY();

            Graphics g = e.Graphics;

            using(Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawRectangle(
                    pen,
                    10,
                    10,
                    panelAirspace.Width - 20,
                    panelAirspace.Height - 20);
            }
            //escala:
            double minX = Math.Min(x1, x2);
            double maxX = Math.Max(x1, x2);

            double minY = Math.Min(y1, y2);
            double maxY = Math.Max(y1, y2);
            
            if (maxX == minX)
            {
                maxX = minX + 1;
            }

            if (maxY == minY)
            {
                maxY = minY + 1;
            }
            //margenes
            float margen = 40;

            float ancho = panelAirspace.Width - 2 * margen;
            float alto = panelAirspace.Height - 2 * margen;
            
            //de coordenadas a pixels
            float px1 = margen +
                (float)((x1 - minX) / (maxX - minX) * ancho);

            float py1 = margen +
                (float)((maxY - y1) / (maxY - minY) * alto);

            float px2 = margen +
                (float)((x2 - minX) / (maxX - minX) * ancho);

            float py2 = margen +
                (float)((maxY - y2) / (maxY - minY) * alto);
           
            g.FillEllipse(
                Brushes.Blue,
                px1 - 7,
                py1 - 7,
                14,
                14);

            g.DrawString(
                vuelo1.GetId(),
                this.Font,
                Brushes.Blue,
                px1 + 10,
                py1 - 10);


            g.FillEllipse(
                Brushes.Red,
                px2 - 7,
                py2 - 7,
                14,
                14);

            g.DrawString(
                vuelo2.GetId(),
                this.Font,
                Brushes.Red,
                px2 + 10,
                py2 - 10);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
