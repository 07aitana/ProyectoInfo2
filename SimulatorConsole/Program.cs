using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib; 

namespace SimulatorConsole 
{
    public class Program
    {
        
        static void Main(string[] args) 
        {
            
            // Trata las excepciones de formato de entrada incorrecto
            try
            {
                FlightPlanList lista = new FlightPlanList();

                Console.WriteLine("Escribe el identificador");
                //   string nombre = Console.ReadLine();
                string identificador = Console.ReadLine();
                Console.WriteLine("Escribe la velocidad");
                double velocidad = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
                string linea = Console.ReadLine();
                string[] trozos = linea.Split(' ');
                double ix = Convert.ToDouble(trozos[0]);
                double iy = Convert.ToDouble(trozos[1]);

                Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                double fx = Convert.ToDouble(trozos[0]);
                double fy = Convert.ToDouble(trozos[1]);

                FlightPlan plan_a = new FlightPlan(identificador, ix, iy, fx, fy, velocidad);

                Console.WriteLine("Escribe el identificador");
                identificador = Console.ReadLine();
                Console.WriteLine("Escribe la velocidad");
                velocidad = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                ix = Convert.ToDouble(trozos[0]);
                iy = Convert.ToDouble(trozos[1]);

                Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                fx = Convert.ToDouble(trozos[0]);
                fy = Convert.ToDouble(trozos[1]);

                FlightPlan plan_b= new FlightPlan(identificador, ix, iy, fx, fy, velocidad);

                lista.AddFlightPlan(plan_a);
                lista.AddFlightPlan(plan_b);



                // bucle que mueve el avión 10 veces y escribe la posición en consola
                int i = 0;
                int ciclos = 10;
                int tiempoCiclo = 10;
                double distanciaSeguridad = 10;
                while (i < ciclos)
                {
                    lista.Mover(tiempoCiclo);
                    lista.EscribeConsola();
                    lista.Mover(tiempoCiclo);
                    lista.EscribeConsola();
                    if(lista.GetFlightPlan(0).Conflicto(lista.GetFlightPlan(1), distanciaSeguridad))
                    {
                        Console.WriteLine("Conflicto entre los aviones");
                    }
                    i++;
                }

                Console.ReadLine(); //espera a que el usuario pulse una tecla antes de cerrar la consola
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato en la entrada de los valores");
            }
        }
    }
}