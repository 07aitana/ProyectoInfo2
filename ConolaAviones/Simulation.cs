using System;
using System.Drawing;
using System.Windows.Forms;
using FlightLib;

namespace AirTrafficSimForms
{
    public partial class SimulationForm : Form

    {
        FlightPlan vuelo1;
        FlightPlan vuelo2;

        int px1, py1;
        int px2, py2;

        double CycleTime;
        double minX;
        double maxX;
        double minY;
        double maxY;

        double SafetyDistance;

        bool conflictoComprobado = false; // para preguntar solo la primera vez que se pulsa Start
        bool alarmaMostrada = false; // para que el aviso salga solo una vez

        double velocidad; // Variable para almacenar la velocidad obtenida del formulario Velocity
        
        string id; // Variable para almacenar el ID del avión cuya velocidad se va a cambiar
        public SimulationForm(FlightPlan vuelo1, FlightPlan vuelo2, double CycleTime, double SafetyDistance)
        {
            InitializeComponent();

            this.vuelo1 = vuelo1;
            this.vuelo2 = vuelo2;
            this.CycleTime = CycleTime;
            this.SafetyDistance = SafetyDistance;

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

            double radioSeguridad = SafetyDistance / 2;

            minX = minX - radioSeguridad;
            maxX = maxX + radioSeguridad;

            minY = minY - radioSeguridad;
            maxY = maxY + radioSeguridad;

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
    double margen = 40;

    double ancho = panelAirspace.Width - 2 * margen;
    double alto = panelAirspace.Height - 2 * margen;

    //de real a pixel
    double escalaX = ancho / (maxX - minX);
    double escalaY = alto / (maxY - minY);
    double escala = Math.Min(escalaX, escalaY);

    //calculo radio de las "elipses" al voltat del avio
    int radio = Convert.ToInt32(SafetyDistance / 2 * escala);



    // Convertir posiciones actuales a pixeles
    px1 = Convert.ToInt32(margen + (x1 - minX) * escala);
    py1 = Convert.ToInt32(margen + (maxY - y1) * escala);

    px2 = Convert.ToInt32(margen + (x2 - minX) * escala);
    py2 = Convert.ToInt32(margen + (maxY - y2) * escala);

    // Obtener posiciones finales
    double x1Final = vuelo1.GetFinalPosition().GetX();
    double y1Final = vuelo1.GetFinalPosition().GetY();

    double x2Final = vuelo2.GetFinalPosition().GetX();
    double y2Final = vuelo2.GetFinalPosition().GetY();

    // Convertir posiciones finales a píxeles
    int px1Final = Convert.ToInt32(margen + (x1Final - minX) * escala);
    int py1Final = Convert.ToInt32(margen + (maxY - y1Final) * escala);
    int px2Final = Convert.ToInt32(margen + (x2Final - minX) * escala);
    int py2Final = Convert.ToInt32(margen + (maxY - y2Final) * escala);

    // Dibujar trayectorias desde la posición actual hasta el destino
    using (Pen pen1 = new Pen(Color.Blue, 2))
    {
        g.DrawLine(pen1, px1, py1, px1Final, py1Final);
    }


    using (Pen pen2 = new Pen(Color.Red, 2))
    {
       g.DrawLine(pen2, px2, py2, px2Final, py2Final);
    }

            //dibuixar elipse
            // Si los aviones están en conflicto, los círculos se pintan en rojo
            Color colorSeguridad = Color.Green;
            if (vuelo1.Conflicto(vuelo2, SafetyDistance))
            {
                colorSeguridad = Color.Red;
            }

            using (Pen penSafety = new Pen(colorSeguridad, 2))
            {
                g.DrawEllipse(penSafety,
                    px1 - radio,
                    py1 - radio,
                    radio * 2,
                    radio * 2);

                g.DrawEllipse(penSafety,
                    px2 - radio,
                    py2 - radio,
                    radio * 2,
                    radio * 2);
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
    g.FillEllipse(Brushes.Red, px2 - 7, py2 - 7, 14, 14);

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
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Antes de empezar, comprobamos si habrá conflicto (solo la primera vez)
            if (!conflictoComprobado)
            {
                conflictoComprobado = true;

                if (vuelo1.HabraConflicto(vuelo2, SafetyDistance))
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
            // Mover los dos aviones un ciclo
            vuelo1.Mover(CycleTime);
            vuelo2.Mover(CycleTime);

            // Volver a dibujar el panel
            panelAirspace.Invalidate();
            ComprobarAlarma();

            if (vuelo1.HaLlegado() && vuelo2.HaLlegado())
            {
                timer1.Stop();
                MessageBox.Show("The simulation has finished");
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            FlightDataGridForm f6 = new FlightDataGridForm(vuelo1, vuelo2);
            f6.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void panelAirspace_MouseClick(object sender, MouseEventArgs e)
        {
            //calcula la distancia entre on clikes i on esta l'avió
            double distancia1 = Math.Sqrt(Math.Pow(e.X - px1, 2) + Math.Pow(e.Y - py1, 2)); //Mirar otra forma de hacer las potencias
           
            //si esta aprop obre el form
            if (distancia1 < 15)
            {
                AircraftInformationForm F5 = new AircraftInformationForm(vuelo1);
                F5.Show();
                return;
            }
            //el mateix pel segon avió
            
            double distancia2 = Math.Sqrt(Math.Pow(e.X - px2, 2) + Math.Pow(e.Y - py2, 2));
            
            if (distancia2 < 15)
            {
                AircraftInformationForm F5 = new AircraftInformationForm(vuelo2);
                F5.Show();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (vuelo1.HabraConflicto(vuelo2, SafetyDistance))
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
            velocityForm.SetFlightPlans(vuelo1, vuelo2);
            velocityForm.ShowDialog();
            vuelo1.Restart();
            vuelo2.Restart();

            panelAirspace.Invalidate();
        }


        // Baja la velocidad del vuelo 2 un 10% cada vez hasta que no haya conflicto.
        // Lo intentamos como mucho 20 veces, por si no se puede resolver.
        private void ResolverConflicto()
        {
            int intentos = 0;

            while (vuelo1.HabraConflicto(vuelo2, SafetyDistance) && intentos < 20)
            {
                vuelo2.SetVelocidad(vuelo2.GetVelocidad() * 0.9);
                intentos++;
            }

            if (vuelo1.HabraConflicto(vuelo2, SafetyDistance))
            {
                MessageBox.Show("The conflict could not be solved.");
            }
            else
            {
                MessageBox.Show("Conflict solved. New speed of " + vuelo2.GetId() + ": "
                    + vuelo2.GetVelocidad().ToString("F2") + " km/h");
            }
        }
        // Avisa al usuario (una sola vez) cuando los vuelos están demasiado cerca
        private void ComprobarAlarma()
        {
            if (vuelo1.Conflicto(vuelo2, SafetyDistance) && !alarmaMostrada)
            {
                alarmaMostrada = true;
                MessageBox.Show("WARNING: the flights are closer than the safety distance!");
            }
        }
    }
}