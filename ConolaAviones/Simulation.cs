using System;
using System.Drawing;
using System.Windows.Forms;
using FlightLib;

namespace AirTrafficSimForms
{
    public partial class SimulationForm : Form

    {
        FlightPlanList flightplans;

        double CycleTime;
        double SafetyDistance;

        double minX;
        double maxX;
        double minY;
        double maxY;

        

        bool conflictoComprobado = false; // para preguntar solo la primera vez que se pulsa Start
        bool alarmaMostrada = false; // para que el aviso salga solo una vez

        public SimulationForm()
        {
            InitializeComponent();
        }

        public void SetInformation(FlightPlanList flightplans, double cycleTime, double safetyDistance)
        {
            this.flightplans = flightplans;
            this.CycleTime = cycleTime;
            this.SafetyDistance = safetyDistance;

            CalcularLimites();
            
        }
        private void CalcularLimites()
        {
            minX = double.MaxValue;
            maxX = double.MinValue;
            minY = double.MaxValue;
            maxY = double.MinValue;

            for (int i = 0; i < flightplans.GetNumber(); i++)
            {
                FlightPlan vuelo = flightplans.GetFlightPlan(i);

                double xInicial = vuelo.GetCurrentPosition().GetX();
                double yInicial = vuelo.GetCurrentPosition().GetY();

                double xFinal = vuelo.GetFinalPosition().GetX();
                double yFinal = vuelo.GetFinalPosition().GetY();

                minX = Math.Min(minX, Math.Min(xInicial, xFinal));
                maxX = Math.Max(maxX, Math.Max(xInicial, xFinal));

                minY = Math.Min(minY, Math.Min(yInicial, yFinal));
                maxY = Math.Max(maxY, Math.Max(yInicial, yFinal));
            }

            double radioSeguridad = SafetyDistance / 2;

            minX = minX - radioSeguridad;
            maxX = maxX + radioSeguridad;

            minY = minY - radioSeguridad;
            maxY = maxY + radioSeguridad;

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
            if (flightplans == null || flightplans.GetNumber() == 0)
            {
                return;
            }

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
            double margen = 40;

            double ancho = panelAirspace.Width - 2 * margen;
            double alto = panelAirspace.Height - 2 * margen;

            // De coordenadas reales a píxeles
            double escalaX = ancho / (maxX - minX);
            double escalaY = alto / (maxY - minY);
            double escala = Math.Min(escalaX, escalaY);

            // Radio de los círculos de seguridad
            int radio = Convert.ToInt32(SafetyDistance / 2 * escala);

            // Recorrer todos los aviones
            for (int i = 0; i < flightplans.GetNumber(); i++)
            {
                FlightPlan vuelo = flightplans.GetFlightPlan(i);

                // Obtener posición actual
                double x = vuelo.GetCurrentPosition().GetX();
                double y = vuelo.GetCurrentPosition().GetY();

                // Convertir posición actual a píxeles
                int px = Convert.ToInt32(margen + (x - minX) * escala);
                int py = Convert.ToInt32(margen + (maxY - y) * escala);

                // Obtener posición final
                double xFinal = vuelo.GetFinalPosition().GetX();
                double yFinal = vuelo.GetFinalPosition().GetY();

                // Convertir posición final a píxeles
                int pxFinal = Convert.ToInt32(margen + (xFinal - minX) * escala);
                int pyFinal = Convert.ToInt32(margen + (maxY - yFinal) * escala);

                // Dibujar trayectoria
                using (Pen penTrayectoria = new Pen(Color.Blue, 2))
                {
                    g.DrawLine(penTrayectoria, px, py, pxFinal, pyFinal);
                }

                // Comprobar si el avión está en conflicto
                Color colorSeguridad = Color.Green;

                for (int j = 0; j < flightplans.GetNumber(); j++)
                {
                    if (i != j)
                    {
                        FlightPlan otroVuelo = flightplans.GetFlightPlan(j);

                        if (vuelo.Conflicto(otroVuelo, SafetyDistance))
                        {
                            colorSeguridad = Color.Red;
                        }
                    }
                }

                // Dibujar círculo de seguridad
                using (Pen penSafety = new Pen(colorSeguridad, 2))
                {
                    g.DrawEllipse(
                        penSafety,
                        px - radio,
                        py - radio,
                        radio * 2,
                        radio * 2
                    );
                }

                // Dibujar avión
                g.FillEllipse(
                    Brushes.Blue,
                    px - 7,
                    py - 7,
                    14,
                    14
                );

                // Dibujar identificador del avión
                g.DrawString(
                    vuelo.GetId(),
                    this.Font,
                    Brushes.Blue,
                    px + 10,
                    py - 10
                );
            }
        }
        private void btnmove_Click(object sender, EventArgs e)
        {
            flightplans.Mover(CycleTime);

            panelAirspace.Invalidate();

            ComprobarAlarma();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!conflictoComprobado)
            {
                conflictoComprobado = true;

                if (flightplans.HabraConflictos(SafetyDistance))
                {
                    DialogResult respuesta = MessageBox.Show(
                        "The flights will be in conflict. Do you want to solve it?",
                        "Conflict detected",
                        MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        ResolverConflicto();
                    }
                }
            }

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flightplans.Mover(CycleTime);

            panelAirspace.Invalidate();

            ComprobarAlarma();

            if (flightplans.TodosHanLlegado())
            {
                timer1.Stop();
                MessageBox.Show("The simulation has finished");
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            FlightDataGridForm f6 = new FlightDataGridForm();

            f6.SetFlightPlans(flightplans);

            f6.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void panelAirspace_MouseClick(object sender, MouseEventArgs e)
        {
            double margen = 40;

            double ancho = panelAirspace.Width - 2 * margen;
            double alto = panelAirspace.Height - 2 * margen;

            double escalaX = ancho / (maxX - minX);
            double escalaY = alto / (maxY - minY);
            double escala = Math.Min(escalaX, escalaY);

            for (int i = 0; i < flightplans.GetNumber(); i++)
            {
                FlightPlan vuelo = flightplans.GetFlightPlan(i);

                double x = vuelo.GetCurrentPosition().GetX();
                double y = vuelo.GetCurrentPosition().GetY();

                int px = Convert.ToInt32(margen + (x - minX) * escala);
                int py = Convert.ToInt32(margen + (maxY - y) * escala);

                double distancia = Math.Sqrt(
                    Math.Pow(e.X - px, 2) +
                    Math.Pow(e.Y - py, 2)
                );

                if (distancia < 15)
                {
                    AircraftInformationForm F5 = new AircraftInformationForm(vuelo);
                    F5.Show();
                    return;
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (flightplans.HabraConflictos(SafetyDistance))
            {
                MessageBox.Show("The flights WILL be in conflict.");
            }
            else
            {
                MessageBox.Show("The flights will NOT be in conflict.");
            }
        }

        
        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ChangeVelocityBtn_Click(object sender, EventArgs e)
        {
            Velocity velocityForm = new Velocity();

            velocityForm.SetFlightPlans(flightplans);
            velocityForm.ShowDialog();

            for (int i = 0; i < flightplans.GetNumber(); i++)
            {
                flightplans.GetFlightPlan(i).Restart();
            }

            conflictoComprobado = false;
            alarmaMostrada = false;

            panelAirspace.Invalidate();
        }


        // Baja la velocidad del vuelo 2 un 10% cada vez hasta que no haya conflicto.
        // Lo intentamos como mucho 20 veces, por si no se puede resolver.
        private void ResolverConflicto()
        {
            if(flightplans.ResolverConflictos(SafetyDistance))
            {
                MessageBox.Show("Conflicts solved successfully.");
            }
            else
            {
                MessageBox.Show("The conflicts could not be solved.");
            }
        }
        // Avisa al usuario (una sola vez) cuando los vuelos están demasiado cerca
        private void ComprobarAlarma()
        {
            if (flightplans.HayConflictoActual(SafetyDistance) && !alarmaMostrada)
            {
                alarmaMostrada = true;

                MessageBox.Show(
                    "WARNING: the flights are closer than the safety distance!"
                );
            }
        }
    }
}