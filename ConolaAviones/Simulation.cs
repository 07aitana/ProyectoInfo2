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

        

        bool conflictoComprobado = false; // para comprobar los conflictos solo antes de empezar a simular
        bool alarmaMostrada = false; // para que el aviso salga solo una vez

        // constructor del formulario
        public SimulationForm()
        {
            InitializeComponent();
        }

        // recibe la lista de vuelos, el tiempo de ciclo y la distancia de seguridad
        public void SetInformacion(FlightPlanList flightplans, double cycleTime, double safetyDistance)
        {
            this.flightplans = flightplans;
            this.CycleTime = cycleTime;
            this.SafetyDistance = safetyDistance;

            CalcularLimites();
            
        }
        // calcula las coordenadas minimas y maximas de todos los vuelos para escalar el dibujo
        private void CalcularLimites()
        {
            minX = double.MaxValue;
            maxX = double.MinValue;
            minY = double.MaxValue;
            maxY = double.MinValue;

            for (int i = 0; i < flightplans.GetNumero(); i++)
            {
                FlightPlan vuelo = flightplans.GetVuelo(i);

                double xInicial = vuelo.GetPosicionInicial().GetX();
                double yInicial = vuelo.GetPosicionInicial().GetY();

                double xFinal = vuelo.GetPosicionFinal().GetX();
                double yFinal = vuelo.GetPosicionFinal().GetY();

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

        // dibuja el espacio aereo: trayectorias, circulos de seguridad y aviones
        private void panelAirspace_Paint(object sender, PaintEventArgs e)
        {
            if (flightplans == null || flightplans.GetNumero() == 0)
            {
                return;
            }

            Graphics g = e.Graphics;

            // Dibujar borde del espacio aéreo
            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(
                pen,
                10,
                10,
                panelAirspace.Width - 20,
                panelAirspace.Height - 20
            );

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
            for (int i = 0; i < flightplans.GetNumero(); i++)
            {
                FlightPlan vuelo = flightplans.GetVuelo(i);

                // Obtener posición inicial
                double xInicial = vuelo.GetPosicionInicial().GetX();
                double yInicial = vuelo.GetPosicionInicial().GetY();


                // Obtener posición actual
                double x = vuelo.GetPosicionActual().GetX();
                double y = vuelo.GetPosicionActual().GetY();

                // Convertir posición inicial a píxeles
                int pxInicial = Convert.ToInt32(margen + (xInicial - minX) * escala);
                int pyInicial = Convert.ToInt32(margen + (maxY - yInicial) * escala);

                // Convertir posición actual a píxeles
                int px = Convert.ToInt32(margen + (x - minX) * escala);
                int py = Convert.ToInt32(margen + (maxY - y) * escala);

                // Obtener posición final
                double xFinal = vuelo.GetPosicionFinal().GetX();
                double yFinal = vuelo.GetPosicionFinal().GetY();

                // Convertir posición final a píxeles
                int pxFinal = Convert.ToInt32(margen + (xFinal - minX) * escala);
                int pyFinal = Convert.ToInt32(margen + (maxY - yFinal) * escala);

                // Dibujar trayectoria
                Pen penRecorrida = new Pen(Color.Black, 2);
                g.DrawLine(penRecorrida, pxInicial, pyInicial, px, py);
                Pen penPendiente = new Pen(Color.Blue, 2);
                g.DrawLine(penPendiente, px, py, pxFinal, pyFinal);

                // Comprobar si el avión está en conflicto
                Color colorSeguridad = Color.Green;

                for (int j = 0; j < flightplans.GetNumero(); j++)
                {
                    if (i != j)
                    {
                        FlightPlan otroVuelo = flightplans.GetVuelo(j);

                        if (vuelo.Conflicto(otroVuelo, SafetyDistance))
                        {
                            colorSeguridad = Color.Red;
                        }
                    }
                }

                // Dibujar círculo de seguridad
                Pen penSafety = new Pen(colorSeguridad, 2);
                g.DrawEllipse(
                    penSafety,
                    px - radio,
                    py - radio,
                    radio * 2,
                    radio * 2
                );

                // Comprobar si el avión ha llegado
                if (vuelo.HaLlegado())
                {
                    // Dibujar avión en verde
                    g.FillEllipse(
                        Brushes.Green,
                        px - 7,
                        py - 7,
                        14,
                        14
                    );

                    g.DrawString(" "+
                        vuelo.GetId() + " (ARRIVED)",
                        this.Font,
                        Brushes.Green,
                        px + 10,
                        py - 10
                    );
                }
                else
                {
                    // Dibujar avión en azul
                    g.FillEllipse(
                        Brushes.Blue,
                        px - 7,
                        py - 7,
                        14,
                        14
                    );

                    g.DrawString(" "+
                        vuelo.GetId(),
                        this.Font,
                        Brushes.Blue,
                        px + 10,
                        py - 10
                    );
                }
            }
        }
        // mueve los aviones un ciclo y redibuja
        private void btnmove_Click(object sender, EventArgs e)
        {
            ComprobarConflictosAntes();

            flightplans.Mover(CycleTime);

            panelAirspace.Invalidate();

            ComprobarAlarma();
        }
        // empieza la simulacion automatica. la primera vez avisa si va a haber conflictos
        private void btnStart_Click(object sender, EventArgs e)
        {
            ComprobarConflictosAntes();

            timer1.Interval = 1000;
            timer1.Start();
        }

        // antes de empezar a simular (solo la primera vez) comprueba si habra conflicto
        private void ComprobarConflictosAntes()
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
        }

        // para la simulacion automatica
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        // cada tick mueve los aviones un ciclo; si todos han llegado para el timer
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

        // abre la tabla con los datos de todos los vuelos
        private void btnData_Click(object sender, EventArgs e)
        {
            FlightDataGridForm f6 = new FlightDataGridForm();

            f6.SetVuelos(flightplans);

            f6.Show();
        }

        // si se clica encima de un avion abre el formulario con su informacion
        private void panelAirspace_MouseClick(object sender, MouseEventArgs e)
        {
            double margen = 40;

            double ancho = panelAirspace.Width - 2 * margen;
            double alto = panelAirspace.Height - 2 * margen;

            double escalaX = ancho / (maxX - minX);
            double escalaY = alto / (maxY - minY);
            double escala = Math.Min(escalaX, escalaY);

            for (int i = 0; i < flightplans.GetNumero(); i++)
            {
                FlightPlan vuelo = flightplans.GetVuelo(i);

                double x = vuelo.GetPosicionActual().GetX();
                double y = vuelo.GetPosicionActual().GetY();

                int px = Convert.ToInt32(margen + (x - minX) * escala);
                int py = Convert.ToInt32(margen + (maxY - y) * escala);

                double distancia = Math.Sqrt(
                    Math.Pow(e.X - px, 2) +
                    Math.Pow(e.Y - py, 2)
                );

                if (distancia < 15)
                {
                    AircraftInformationForm F5 = new AircraftInformationForm();
                    F5.SetVuelo(vuelo);
                    F5.Show();
                    return;
                }
            }
        }

        // dice si los vuelos van a entrar en conflicto o no
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

        // abre el formulario para cambiar la velocidad de un vuelo y redibuja
        private void ChangeVelocityBtn_Click(object sender, EventArgs e)
        {
            Velocity velocityForm = new Velocity();

            velocityForm.SetVuelos(flightplans);
            velocityForm.ShowDialog();

            

            conflictoComprobado = false;
            alarmaMostrada = false;

            panelAirspace.Invalidate();
        }


        // Baja la velocidad del vuelo 2 un 10% cada vez hasta que no haya conflicto.
        private void ResolverConflicto()
        {
            FlightPlanList proposta = flightplans.Copiar();

            if (proposta.ResolverConflictos(SafetyDistance))
            {
                // Mensaje con los vuelos a los que les cambia la velocidad
                string mensaje = "Recommended speeds:\n\n";

                for (int a = 0; a < flightplans.GetNumero(); a++)
                {
                    FlightPlan original = flightplans.GetVuelo(a);
                    FlightPlan nova = proposta.GetVuelo(a);

                    if (original.GetVelocidad() != nova.GetVelocidad())
                    {
                        mensaje += "Flight: " + original.GetId() + "\n";
                        mensaje += "Old speed: " + original.GetVelocidad() + "\n";
                        mensaje += "New speed: " + nova.GetVelocidad() + "\n\n";
                    }
                }

                mensaje += "Do you want to apply these changes?";

                DialogResult respuesta = MessageBox.Show(
                    mensaje,
                    "Speed recommendations",
                    MessageBoxButtons.YesNo
                );

                if (respuesta == DialogResult.Yes)
                {
                    // Aplicamos las velocidades propuestas a los vuelos reales
                    flightplans.CopiarVelocidades(proposta);

                    if (!flightplans.HabraConflictos(SafetyDistance))
                    {
                        MessageBox.Show("Speed changes applied. Conflicts solved.");
                    }
                    else
                    {
                        MessageBox.Show("The conflicts still exist.");
                    }

                    panelAirspace.Invalidate();
                }
                else
                {
                    MessageBox.Show("Speed changes cancelled.");
                }
            }
            else
            {
                MessageBox.Show("The conflicts could not be solved.");
            }
        }

        // Avisa al usuario (una sola vez) cuando los vuelos están demasiado cerca
        private void ComprobarAlarma()
        {
            if (flightplans.HayConflictoActual(SafetyDistance)) //si hi ha conflicte alarma es mostra sino es torna a false
            {
                if (!alarmaMostrada)
                {
                    alarmaMostrada = true;

                    timer1.Stop();

                    MessageBox.Show(
                        "WARNING: the flights are closer than the safety distance!\nThe simulation has been paused. Press Start to continue."
                    );
                }
            }
            else
            {
                alarmaMostrada = false;
            }
        }

        // para la simulacion y devuelve todos los aviones a su posicion inicial
        private void btnRestart_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            flightplans.Reiniciar();
            alarmaMostrada = false;
            conflictoComprobado = false;
            panelAirspace.Invalidate();
        }

        // deshace el ultimo paso de la simulacion
        private void btnUndo_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (flightplans.Deshacer())
            {
                panelAirspace.Invalidate();
            }
            else
            {
                MessageBox.Show("There is no step to undo");
            }
        }

        // guarda la lista de vuelos con sus posiciones actuales en un fichero de texto
        private void btnSave_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Save the flight plans";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    flightplans.GuardarVuelos(saveFileDialog1.FileName);
                    MessageBox.Show("Flights saved successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error saving the file");
                }
            }
        }
    }
}