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
        public Position GetFinalPositionn()
        {
            return this.finalPosition;
        }
        public void SetFinalPositionnn(Position finalPosition)
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

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
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
            bool conflicto = true;
            
            if(this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
            
                conflicto = true;
            return conflicto;
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
            this.currentPosition = new Position(
                    this.initialPosition.GetX(),
                    this.initialPosition.GetY()
                    );



            
        }
        public double Distance(FlightPlan plan)
        {
            double resultado = Math.Sqrt((this.currentPosition.GetX() - plan.currentPosition.GetX()) * (this.currentPosition.GetX() - plan.currentPosition.GetX()) + (this.currentPosition.GetY() - plan.currentPosition.GetY()) * (this.currentPosition.GetY() - plan.currentPosition.GetY()));
            return resultado;
        }
    }
    
}
