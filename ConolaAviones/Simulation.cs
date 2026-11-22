using System;
using System.Drawing;
using System.Windows.Forms;
using FlightLib;

namespace AirTrafficSimForms
{
    public partial class SimulationForm : Form
    {
        FlightPlanList flightPlans;
        double CycleTime;
        double SafetyDistance;
        double minX;
        double maxX;
        double minY;
        double maxY;
        bool predictedConflictsChecked = false;
        bool separationAlertShown = false;

        // Sets up the simulation form.
        public SimulationForm()
        {
            InitializeComponent();
        }

        // Sets the flightPlans to run, the cycleTime in minutes and the safetyDistance in km.
        // Works out how much space the drawing needs.
        public void ConfigureSimulation(FlightPlanList flightPlans, double cycleTime, double safetyDistance)
        {
            this.flightPlans = flightPlans;
            this.CycleTime = cycleTime;
            this.SafetyDistance = safetyDistance;

            CalculateDrawingBounds();
        }

        // Finds how much space is needed to draw all the routes and safety circles.
        private void CalculateDrawingBounds()
        {
            minX = double.MaxValue;
            maxX = double.MinValue;
            minY = double.MaxValue;
            maxY = double.MinValue;

            for (int i = 0; i < flightPlans.GetFlightCount(); i++)
            {
                FlightPlan flight = flightPlans.GetFlightPlan(i);

                double xInicial = flight.GetInitialPosition().GetX();
                double yInicial = flight.GetInitialPosition().GetY();

                double xFinal = flight.GetDestination().GetX();
                double yFinal = flight.GetDestination().GetY();

                minX = Math.Min(minX, Math.Min(xInicial, xFinal));
                maxX = Math.Max(maxX, Math.Max(xInicial, xFinal));

                minY = Math.Min(minY, Math.Min(yInicial, yFinal));
                maxY = Math.Max(maxY, Math.Max(yInicial, yFinal));
            }

            double SecurutyRadio = SafetyDistance / 2;

            minX = minX - SecurutyRadio;
            maxX = maxX + SecurutyRadio;

            minY = minY - SecurutyRadio;
            maxY = maxY + SecurutyRadio;

            if (maxX == minX)
            {
                maxX = minX + 1;
            }

            if (maxY == minY)
            {
                maxY = minY + 1;
            }
        }

        // Uses e.Graphics to draw the routes, planes and safety circles (sender is unused).
        private void panelAirspace_Paint(object sender, PaintEventArgs e)
        {
            if (flightPlans == null || flightPlans.GetFlightCount() == 0)
            {
                return;
            }

            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(
                pen,
                10,
                10,
                panelAirspace.Width - 20,
                panelAirspace.Height - 20
            );

            double margin = 40;

            double width = panelAirspace.Width - 2 * margin;
            double height = panelAirspace.Height - 2 * margin;

            double scaleX = width / (maxX - minX);
            double scaleY = height / (maxY - minY);
            double scale = Math.Min(scaleX, scaleY);

            // Each circle has half the safety distance as its radius.
            int radius = Convert.ToInt32(SafetyDistance / 2 * scale);

            for (int i = 0; i < flightPlans.GetFlightCount(); i++)
            {
                FlightPlan flight = flightPlans.GetFlightPlan(i);

                double xInicial = flight.GetInitialPosition().GetX();
                double yInicial = flight.GetInitialPosition().GetY();

                double x = flight.GetCurrentPosition().GetX();
                double y = flight.GetCurrentPosition().GetY();

                // Flip Y because screen coordinates increase from top to bottom.
                int pxInicial = Convert.ToInt32(margin + (xInicial - minX) * scale);
                int pyInicial = Convert.ToInt32(margin + (maxY - yInicial) * scale);

                int px = Convert.ToInt32(margin + (x - minX) * scale);
                int py = Convert.ToInt32(margin + (maxY - y) * scale);

                double xFinal = flight.GetDestination().GetX();
                double yFinal = flight.GetDestination().GetY();

                int pxFinal = Convert.ToInt32(margin + (xFinal - minX) * scale);
                int pyFinal = Convert.ToInt32(margin + (maxY - yFinal) * scale);

                Pen traveledPathPen = new Pen(Color.Black, 2);
                g.DrawLine(traveledPathPen, pxInicial, pyInicial, px, py);
                Pen remainingPathPen = new Pen(Color.Blue, 2);
                g.DrawLine(remainingPathPen, px, py, pxFinal, pyFinal);

                Color separationColor = Color.Green;

                for (int j = 0; j < flightPlans.GetFlightCount(); j++)
                {
                    if (i != j)
                    {
                        FlightPlan otherFlight = flightPlans.GetFlightPlan(j);

                        if (flight.IsInConflictWith(otherFlight, SafetyDistance))
                        {
                            separationColor = Color.Red;
                        }
                    }
                }

                Pen penSafety = new Pen(separationColor, 2);
                g.DrawEllipse(
                    penSafety,
                    px - radius,
                    py - radius,
                    radius * 2,
                    radius * 2
                );

                if (flight.HasArrived())
                {
                    g.FillEllipse(
                        Brushes.Green,
                        px - 7,
                        py - 7,
                        14,
                        14
                    );

                    g.DrawString(" "+
                        flight.GetId() + " (ARRIVED)",
                        this.Font,
                        Brushes.Green,
                        px + 10,
                        py - 10
                    );
                }
                else
                {
                    g.FillEllipse(
                        Brushes.Blue,
                        px - 7,
                        py - 7,
                        14,
                        14
                    );

                    g.DrawString(" "+
                        flight.GetId(),
                        this.Font,
                        Brushes.Blue,
                        px + 10,
                        py - 10
                    );
                }
            }
        }

        // Moves the flights one step and warns if they get too close (sender and e are unused).
        private void btnmove_Click(object sender, EventArgs e)
        {
            CheckForPredictedConflicts();

            flightPlans.Advance(CycleTime);

            panelAirspace.Invalidate();

            CheckSeparationAlert();
        }

        // Checks for future conflicts and starts the timer (sender and e are unused).
        private void btnStart_Click(object sender, EventArgs e)
        {
            CheckForPredictedConflicts();

            timer1.Interval = 1000;
            timer1.Start();
        }

        // Checks once for future conflicts and offers to change speeds if needed.
        private void CheckForPredictedConflicts()
        {
            if (!predictedConflictsChecked)
            {
                predictedConflictsChecked = true;

                if (flightPlans.HasPredictedConflicts(SafetyDistance))
                {
                    DialogResult answer = MessageBox.Show(
                        "The flights will be in conflict. Do you want to solve it?",
                        "Conflict detected",
                        MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes)
                    {
                        OfferConflictResolution();
                    }
                }
            }
        }

        // Stops the timer to pause the simulation (sender and e are unused).
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        // Moves the flights one step and stops the timer when all have arrived (sender and e are unused).
        private void timer1_Tick(object sender, EventArgs e)
        {
            flightPlans.Advance(CycleTime);

            panelAirspace.Invalidate();

            CheckSeparationAlert();

            if (flightPlans.AllFlightsHaveArrived())
            {
                timer1.Stop();
                MessageBox.Show("The simulation has finished");
            }
        }

        // Opens the flight table (sender and e are unused).
        private void btnData_Click(object sender, EventArgs e)
        {
            FlightDataGridForm flightDataForm = new FlightDataGridForm();

            flightDataForm.SetFlightPlans(flightPlans);

            flightDataForm.Show();
        }

        // Uses the click position in e to open details for a nearby plane (sender is unused).
        private void panelAirspace_MouseClick(object sender, MouseEventArgs e)
        {
            double margin = 40;

            double width = panelAirspace.Width - 2 * margin;
            double height = panelAirspace.Height - 2 * margin;

            double scaleX = width / (maxX - minX);
            double scaleY = height / (maxY - minY);
            double scale = Math.Min(scaleX, scaleY);

            for (int i = 0; i < flightPlans.GetFlightCount(); i++)
            {
                FlightPlan flight = flightPlans.GetFlightPlan(i);

                double x = flight.GetCurrentPosition().GetX();
                double y = flight.GetCurrentPosition().GetY();

                int px = Convert.ToInt32(margin + (x - minX) * scale);
                int py = Convert.ToInt32(margin + (maxY - y) * scale);

                double distancia = Math.Sqrt(
                    Math.Pow(e.X - px, 2) +
                    Math.Pow(e.Y - py, 2)
                );

                if (distancia < 15)
                {
                    AircraftInformationForm aircraftInformationForm = new AircraftInformationForm();
                    aircraftInformationForm.SetFlightPlan(flight);
                    aircraftInformationForm.Show();
                    return;
                }
            }
        }

        // Shows whether any flights will get too close (sender and e are unused).
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (flightPlans.HasPredictedConflicts(SafetyDistance))
            {
                MessageBox.Show("The flights WILL be in conflict.");
            }
            else
            {
                MessageBox.Show("The flights will NOT be in conflict.");
            }
        }

        // Opens the speed editor and resets the conflict checks when it closes (sender and e are unused).
        private void ChangeVelocityBtn_Click(object sender, EventArgs e)
        {
            Velocity velocityForm = new Velocity();

            velocityForm.SetFlightPlans(flightPlans);
            velocityForm.ShowDialog();

            predictedConflictsChecked = false;
            separationAlertShown = false;

            panelAirspace.Invalidate();
        }

        // Tries new speeds on a copy and applies them if the user agrees.
        private void OfferConflictResolution()
        {
            FlightPlanList proposedFlights = flightPlans.Copy();

            if (proposedFlights.TryResolveConflicts(SafetyDistance))
            {
                string message = "Recommended speeds:\n\n";

                for (int a = 0; a < flightPlans.GetFlightCount(); a++)
                {
                    FlightPlan original = flightPlans.GetFlightPlan(a);
                    FlightPlan updatedFlight = proposedFlights.GetFlightPlan(a);

                    if (original.GetSpeed() != updatedFlight.GetSpeed())
                    {
                        message += "Flight: " + original.GetId() + "\n";
                        message += "Old speed: " + original.GetSpeed() + "\n";
                        message += "New speed: " + updatedFlight.GetSpeed() + "\n\n";
                    }
                }

                message += "Do you want to apply these changes?";

                DialogResult answer = MessageBox.Show(
                    message,
                    "Speed recommendations",
                    MessageBoxButtons.YesNo
                );

                if (answer == DialogResult.Yes)
                {
                    flightPlans.CopySpeedsFrom(proposedFlights);

                    if (!flightPlans.HasPredictedConflicts(SafetyDistance))
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

        // Pauses and warns once each time flights get too close.
        private void CheckSeparationAlert()
        {
            if (flightPlans.HasCurrentConflicts(SafetyDistance))
            {
                if (!separationAlertShown)
                {
                    separationAlertShown = true;

                    timer1.Stop();

                    MessageBox.Show(
                        "WARNING: the flights are closer than the safety distance!\nThe simulation has been paused. Press Start to continue."
                    );
                }
            }
            else
            {
                separationAlertShown = false;
            }
        }

        // Stops the timer and moves all flights back to their starting points (sender and e are unused).
        private void btnRestart_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            flightPlans.Reset();
            separationAlertShown = false;
            predictedConflictsChecked = false;
            panelAirspace.Invalidate();
        }

        // Stops the timer and puts the flights back one step if possible (sender and e are unused).
        private void btnUndo_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (flightPlans.UndoLastStep())
            {
                panelAirspace.Invalidate();
            }
            else
            {
                MessageBox.Show("There is no step to undo");
            }
        }

        // Stops the timer and lets the user save the flights to a text file (sender and e are unused).
        private void btnSave_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Save the flight plans";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    flightPlans.SaveFlights(saveFileDialog1.FileName);
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
