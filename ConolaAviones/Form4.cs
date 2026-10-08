using System;
using System.Drawing;
using System.Windows.Forms;
using FlightLib;

namespace ConolaAviones
{
    public partial class Form4 : Form
    {
        FlightPlan vuelo1;
        FlightPlan vuelo2;
        double CycleTime;
        double minX;
        double maxX;
        double minY;
        double maxY;

        public Form4(FlightPlan vuelo1, FlightPlan vuelo2, double CycleTime)
        {
            InitializeComponent();

            this.vuelo1 = vuelo1;
            this.vuelo2 = vuelo2;
            this.CycleTime = CycleTime;

            // Posiciones iniciales
            double x1Inicial = vuelo1.GetCurrentPosition().GetX();
            double y1Inicial = vuelo1.GetCurrentPosition().GetY();

            double x2Inicial = vuelo2.GetCurrentPosition().GetX();
            double y2Inicial = vuelo2.GetCurrentPosition().GetY();

            // Posiciones finales
            double x1Final = vuelo1.GetFinalPosition().GetX();
            double y1Final = vuelo1.GetFinalPosition().GetY();

            double x2Final = vuelo2.GetFinalPosition().GetX();
            double y2Final = vuelo2.GetFinalPosition().GetY();

            // Límites del espacio aéreo
            minX = Math.Min(
                Math.Min(x1Inicial, x2Inicial),
                Math.Min(x1Final, x2Final)
            );

            maxX = Math.Max(
                Math.Max(x1Inicial, x2Inicial),
                Math.Max(x1Final, x2Final)
            );

            minY = Math.Min(
                Math.Min(y1Inicial, y2Inicial),
                Math.Min(y1Final, y2Final)
            );

            maxY = Math.Max(
                Math.Max(y1Inicial, y2Inicial),
                Math.Max(y1Final, y2Final)
            );

            // Evitar división entre 0
            if (maxX == minX)
            {
                maxX = minX + 1;
            }

            if (maxY == minY)
            {
                maxY = minY + 1;
            }
        }


        private void panelAirspace_Paint(object sender, PaintEventArgs e)
        {
            // Obtener posiciones actuales
            double x1 = vuelo1.GetCurrentPosition().GetX();
            double y1 = vuelo1.GetCurrentPosition().GetY();

            double x2 = vuelo2.GetCurrentPosition().GetX();
            double y2 = vuelo2.GetCurrentPosition().GetY();

            Graphics g = e.Graphics;

            // Dibujar borde del espacio aéreo
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawRectangle(
                    pen,
                    10,
                    10,
                    panelAirspace.Width - 20,
                    panelAirspace.Height - 20
                );
            }

            // Márgenes
            float margen = 40;

            float ancho = panelAirspace.Width - 2 * margen;
            float alto = panelAirspace.Height - 2 * margen;

            // Convertir coordenadas reales a píxeles

            float px1 = margen +
                (float)((x1 - minX) / (maxX - minX) * ancho);

            float py1 = margen +
                (float)((maxY - y1) / (maxY - minY) * alto);

            float px2 = margen +
                (float)((x2 - minX) / (maxX - minX) * ancho);

            float py2 = margen +
                (float)((maxY - y2) / (maxY - minY) * alto);

            // Posiciones iniciales de los aviones
            double x1Inicial = vuelo1.GetCurrentPosition().GetX();
            double y1Inicial = vuelo1.GetCurrentPosition().GetY();

            double x2Inicial = vuelo2.GetCurrentPosition().GetX();
            double y2Inicial = vuelo2.GetCurrentPosition().GetY();

            // Posiciones finales de los aviones
            double x1Final = vuelo1.GetFinalPosition().GetX();
            double y1Final = vuelo1.GetFinalPosition().GetY();

            double x2Final = vuelo2.GetFinalPosition().GetX();
            double y2Final = vuelo2.GetFinalPosition().GetY();

            // Convertir las posiciones iniciales a píxeles
            float px1Inicial = margen + (float)((x1Inicial - minX) / (maxX - minX) * ancho);
            float py1Inicial = margen + (float)((maxY - y1Inicial) / (maxY - minY) * alto);

            float px2Inicial = margen + (float)((x2Inicial - minX) / (maxX - minX) * ancho);
            float py2Inicial = margen + (float)((maxY - y2Inicial) / (maxY - minY) * alto);

            // Convertir las posiciones finales a píxeles
            float px1Final = margen + (float)((x1Final - minX) / (maxX - minX) * ancho);
            float py1Final = margen + (float)((maxY - y1Final) / (maxY - minY) * alto);

            float px2Final = margen + (float)((x2Final - minX) / (maxX - minX) * ancho);
            float py2Final = margen + (float)((maxY - y2Final) / (maxY - minY) * alto);

            // Dibujar las trayectorias
            using (Pen pen1 = new Pen(Color.Blue, 2))
            {
                g.DrawLine(pen1, px1Inicial, py1Inicial, px1Final, py1Final);
            }

            using (Pen pen2 = new Pen(Color.Red, 2))
            {
                g.DrawLine(pen2, px2Inicial, py2Inicial, px2Final, py2Final);
            }
            // Dibujar avión 1
            g.FillEllipse(
                Brushes.Blue,
                px1 - 7,
                py1 - 7,
                14,
                14
            );

            g.DrawString(
                vuelo1.GetId(),
                this.Font,
                Brushes.Blue,
                px1 + 10,
                py1 - 10
            );


            // Dibujar avión 2
            g.FillEllipse(
                Brushes.Red,
                px2 - 7,
                py2 - 7,
                14,
                14
            );

            g.DrawString(
                vuelo2.GetId(),
                this.Font,
                Brushes.Red,
                px2 + 10,
                py2 - 10
            );
        }


        private void btnmove_Click(object sender, EventArgs e)
        {
            // Mover los dos aviones un ciclo
            vuelo1.Mover(CycleTime);
            vuelo2.Mover(CycleTime);

            // Volver a dibujar el panel
            panelAirspace.Invalidate();
        }


        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}