using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        string id; // identificador
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final

        Position initialPosition;
        double velocidad;

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.initialPosition = new Position(cpx, cpy);
            this.velocidad = velocidad;
        }
        public string GetId()
        {
            return this.id;
        }
        public void SetId(string id)
        {
            this.id = id;
        }
        public Position GetCurrentPosition()
        {
            return this.currentPosition;
        }
        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition= currentPosition;
        }
        public Position GetFinalPosition()
        {
            return this.finalPosition;
        }
        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;
        }
        public double GetVelocidad()
        {
            return this.velocidad;
        }
        
        public void SetVelocidad(double velocidad)
        // setter del atributo velocidad
        { this.velocidad = velocidad; }
        
        // Metodos

        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;
            if (HaLlegado())
            {
                return;
            }
            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX())
                + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            //Modificacion del método para que el avión no se pase de su destino.
            Position nextPosition = new Position(x, y);

            if(currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
        }
        //Método que nos dice si el vuelo ha llegado a su destino o no, comparando la posición actual con la posición final
        public bool HaLlegado()
        {
            bool resultado = false;
            if (currentPosition == finalPosition)
            {
                resultado = true;
            }
            return resultado;
        }

        // retorna true si el vuelo actual y el vuelo b están en conflicto, es decir, si la distancia entre ellos es menor que la distancia de seguridad
        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            
            if(this.Distance(b) < distanciaSeguridad)
            {
                conflicto = true;           
            }
            return conflicto;
        }

        public bool HabraConflicto(FlightPlan b, double distanciaSeguridad)
        {
            // Posiciones actuales
            double x1 = currentPosition.GetX();
            double y1 = currentPosition.GetY();
            double x2 = b.currentPosition.GetX();
            double y2 = b.currentPosition.GetY();

            // Distancias hasta los destinos
            double d1 = currentPosition.Distancia(finalPosition);
            double d2 = b.currentPosition.Distancia(b.finalPosition);

            // Componentes de velocidad (km/min)
            double vx1 = 0;
            double vy1 = 0;
            double vx2 = 0;
            double vy2 = 0;

            if (d1 > 0 && velocidad > 0)
            {
                vx1 = velocidad / 60 * (finalPosition.GetX() - x1) / d1;
                vy1 = velocidad / 60 * (finalPosition.GetY() - y1) / d1;
            }

            if (d2 > 0 && b.velocidad > 0)
            {
                vx2 = b.velocidad / 60 * (b.finalPosition.GetX() - x2) / d2;
                vy2 = b.velocidad / 60 * (b.finalPosition.GetY() - y2) / d2;
            }

            // Tiempo que tarda cada avión en llegar (minutos)
            double t1 = 0;
            double t2 = 0;

            if (d1 > 0 && velocidad > 0)
                t1 = d1 / (velocidad / 60);

            if (d2 > 0 && b.velocidad > 0)
                t2 = d2 / (b.velocidad / 60);

            // Diferencias de posición y velocidad
            double dx = x1 - x2;
            double dy = y1 - y2;
            double dvx = vx1 - vx2;
            double dvy = vy1 - vy2;

            // Instante de mínima distancia por derivación
            double denominador = dvx * dvx + dvy * dvy;
            double tMin = 0;

            if (denominador > 0)
                tMin = -(dx * dvx + dy * dvy) / denominador;

            // Limitar al intervalo en el que ambos se mueven
            double tFin = Math.Min(t1, t2);

            if (tMin < 0)
                tMin = 0;

            if (tMin > tFin)
                tMin = tFin;

            double distanciaMin = Math.Sqrt(
                (dx + dvx * tMin) * (dx + dvx * tMin) +
                (dy + dvy * tMin) * (dy + dvy * tMin));

            if (distanciaMin < distanciaSeguridad)
                return true;

            // Si el primer avión llega antes, queda parado
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

                if (distancia < distanciaSeguridad)
                    return true;
            }
            else if (t2 < t1)
            {
                // Si el segundo avión llega antes
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

                if (distancia < distanciaSeguridad)
                    return true;
            }

            // Comprobar las posiciones finales
            if (finalPosition.Distancia(b.finalPosition) < distanciaSeguridad)
                return true;

            return false;
        }

        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            // Escribe lso datos reales tanto de la posición como de la velocidad con dos decimales
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.HaLlegado())
                Console.WriteLine("El vuelo ha llegado a su destino");
            Console.WriteLine("******************************");
        }
        public void Restart()
        {
            this.currentPosition = new Position(this.initialPosition.GetX(),this.initialPosition.GetY());
            
        }
        public double Distance(FlightPlan plan)
        {
            return this.currentPosition.Distancia(plan.currentPosition);
        }
    }
    
}
