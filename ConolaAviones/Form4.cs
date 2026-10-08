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

        float px1, py1; //guardem a on estan els avions a fora per utiñlitzarlo a la funció click
        float px2, py2;

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

            px1 = margen +
                (float)((x1 - minX) / (maxX - minX) * ancho);

            py1 = margen +
                (float)((maxY - y1) / (maxY - minY) * alto);

            px2 = margen +
                (float)((x2 - minX) / (maxX - minX) * ancho);

            py2 = margen +
                (float)((maxY - y2) / (maxY - minY) * alto);


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

        private void panelAirspace_MouseClick(object sender, MouseEventArgs e)
        {
            //calcula la distancia entre on clikes i on esta l'avió
            double distancia1 = Math.Sqrt(Math.Pow(e.X - px1, 2) + Math.Pow(e.Y - py1, 2));
           
            //si esta aprop obre el form
            if (distancia1 < 15)
            {
                Form5 F5 = new Form5(vuelo1);
                F5.Show();
                return;
            }
            //el mateix pel segon avió
            double distancia2 = Math.Sqrt(Math.Pow(e.X - px2, 2) + Math.Pow(e.Y - py2, 2));
            if (distancia2 < 15)
            {
                Form5 F5 = new Form5(vuelo2);
                F5.Show();
            }
        }
    }
}