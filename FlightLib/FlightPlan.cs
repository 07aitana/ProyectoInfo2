using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        string id;
        string company;
        Position currentPosition;
        Position finalPosition;
        Position initialPosition;
        double velocity;

        // Creates a flight with its id, company and speed in km/h.
        // startX and startY give the start. destinationX and destinationY give the end.
        public FlightPlan(string id, string company, double startX, double startY, double destinationX, double destinationY, double speed)
        {
            this.id = id;
            this.company = company;
            this.currentPosition = new Position(startX, startY);
            this.finalPosition = new Position(destinationX, destinationY);
            this.initialPosition = new Position(startX, startY);
            this.velocity = speed;
        }

        // Returns the flight ID.
        public string GetId()
        {
            return this.id;
        }

        // Changes the flight ID to id.
        public void SetId(string id)
        {
            this.id = id;
        }

        // Returns where the flight is now.
        public Position GetCurrentPosition()
        {
            return this.currentPosition;
        }

        // Sets where the flight is now to currentPosition.
        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition;
        }

        // Returns where the flight is heading.
        public Position GetDestination()
        {
            return this.finalPosition;
        }

        // Sets the flight's destination to finalPosition.
        public void SetDestination(Position finalPosition)
        {
            this.finalPosition = finalPosition;
        }

        // Returns the flight speed in km/h.
        public double GetSpeed()
        {
            return this.velocity;
        }

        // Returns where the flight started.
        public Position GetInitialPosition()
        {
            return this.initialPosition;
        }

        // Changes the flight speed to speed in km/h.
        public void SetSpeed(double speed)
        {
            this.velocity = speed;
        }

        // Returns the name of the airline.
        public string GetAirline()
        {
            return this.company;
        }

        // Moves the flight for elapsedMinutes, stopping at its destination.
        public void Advance(double elapsedMinutes)
        {
            double distancia = elapsedMinutes * this.velocity / 60;
            if (HasArrived())
            {
                return;
            }
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX())
                + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            Position nextPosition = new Position(x, y);

            if (currentPosition.DistanceTo(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
        }

        // Returns true if the flight is at its destination.
        public bool HasArrived()
        {
            bool result = false;
            if (currentPosition.GetX() == finalPosition.GetX() && currentPosition.GetY() == finalPosition.GetY())
            {
                result = true;
            }
            return result;
        }

        // Returns true if flight b is closer than safetyDistance (km) right now.
        public bool IsInConflictWith(FlightPlan b, double safetyDistance)
        {
            bool conflicto = false;

            if (this.DistanceTo(b) < safetyDistance)
            {
                conflicto = true;
            }
            return conflicto;
        }

        // Returns true if flight b will come closer than safetyDistance (km) at current speeds.
        public bool WillConflictWith(FlightPlan b, double safetyDistance)
        {
            double x1 = currentPosition.GetX();
            double y1 = currentPosition.GetY();
            double x2 = b.currentPosition.GetX();
            double y2 = b.currentPosition.GetY();

            double d1 = currentPosition.DistanceTo(finalPosition);
            double d2 = b.currentPosition.DistanceTo(b.finalPosition);

            // Velocity components in kilometers per minute.
            double vx1 = 0;
            double vy1 = 0;
            double vx2 = 0;
            double vy2 = 0;

            if (d1 > 0 && velocity > 0)
            {
                vx1 = velocity / 60 * (finalPosition.GetX() - x1) / d1;
                vy1 = velocity / 60 * (finalPosition.GetY() - y1) / d1;
            }

            if (d2 > 0 && b.velocity > 0)
            {
                vx2 = b.velocity / 60 * (b.finalPosition.GetX() - x2) / d2;
                vy2 = b.velocity / 60 * (b.finalPosition.GetY() - y2) / d2;
            }

            double t1 = 0;
            double t2 = 0;

            if (d1 > 0 && velocity > 0)
                t1 = d1 / (velocity / 60);

            if (d2 > 0 && b.velocity > 0)
                t2 = d2 / (b.velocity / 60);

            double dx = x1 - x2;
            double dy = y1 - y2;
            double dvx = vx1 - vx2;
            double dvy = vy1 - vy2;

            // Find when the two planes are closest.
            double relativeSpeedSquared = dvx * dvx + dvy * dvy;
            double tMin = 0;

            if (relativeSpeedSquared > 0)
                tMin = -(dx * dvx + dy * dvy) / relativeSpeedSquared;

            // Only look at the time before the first plane lands.
            double firstArrivalTime = Math.Min(t1, t2);

            if (tMin < 0)
                tMin = 0;

            if (tMin > firstArrivalTime)
                tMin = firstArrivalTime;

            double minimumDistance = Math.Sqrt(
                (dx + dvx * tMin) * (dx + dvx * tMin) +
                (dy + dvy * tMin) * (dy + dvy * tMin));

            if (minimumDistance < safetyDistance)
                return true;

            // After one plane lands, check how close the other comes to it.
            if (t1 < t2)
            {
                double xParado = finalPosition.GetX();
                double yParado = finalPosition.GetY();

                double xMovil = x2 + vx2 * t1;
                double yMovil = y2 + vy2 * t1;

                double rx = xParado - xMovil;
                double ry = yParado - yMovil;

                double v2 = vx2 * vx2 + vy2 * vy2;
                double t = 0;

                if (v2 > 0)
                    t = (rx * vx2 + ry * vy2) / v2;

                if (t < 0)
                    t = 0;

                if (t > t2 - t1)
                    t = t2 - t1;

                double distancia = Math.Sqrt(
                    (rx - vx2 * t) * (rx - vx2 * t) +
                    (ry - vy2 * t) * (ry - vy2 * t));

                if (distancia < safetyDistance)
                    return true;
            }
            else if (t2 < t1)
            {
                double xParado = b.finalPosition.GetX();
                double yParado = b.finalPosition.GetY();

                double xMovil = x1 + vx1 * t2;
                double yMovil = y1 + vy1 * t2;

                double rx = xMovil - xParado;
                double ry = yMovil - yParado;

                double v1 = vx1 * vx1 + vy1 * vy1;
                double t = 0;

                if (v1 > 0)
                    t = -(rx * vx1 + ry * vy1) / v1;

                if (t < 0)
                    t = 0;

                if (t > t1 - t2)
                    t = t1 - t2;

                double distancia = Math.Sqrt(
                    (rx + vx1 * t) * (rx + vx1 * t) +
                    (ry + vy1 * t) * (ry + vy1 * t));

                if (distancia < safetyDistance)
                    return true;
            }

            if (finalPosition.DistanceTo(b.finalPosition) < safetyDistance)
                return true;

            return false;
        }

        // Prints the flight details.
        public void PrintToConsole()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Compañía aérea: {0}", company);

            Console.WriteLine("Velocidad: {0:F2}", velocity);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.HasArrived())
                Console.WriteLine("El vuelo ha llegado a su destino");
            Console.WriteLine("******************************");
        }

        // Moves the flight back to its starting point.
        public void Reset()
        {
            this.currentPosition = new Position(this.initialPosition.GetX(), this.initialPosition.GetY());
        }

        // Returns the distance in km from this flight to plan using their current positions.
        public double DistanceTo(FlightPlan plan)
        {
            return this.currentPosition.DistanceTo(plan.currentPosition);
        }
    }
}
