using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;

namespace AirTrafficSimConsole
{
    public class Program
    {
        // Reads two flight plans, moves them and prints their positions and any conflicts.
        // The command-line arguments in args are unused.
        static void Main(string[] args)
        {
            try
            {
                FlightPlanList lista = new FlightPlanList();

                Console.WriteLine("Escribe el identificador");
                string identificador = Console.ReadLine();
                Console.WriteLine("Escribe la velocidad");
                double speed = Convert.ToDouble(Console.ReadLine());

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

                FlightPlan plan_a = new FlightPlan(identificador, "Unknown", ix, iy, fx, fy, speed);

                Console.WriteLine("Escribe el identificador");
                identificador = Console.ReadLine();
                Console.WriteLine("Escribe la velocidad");
                speed = Convert.ToDouble(Console.ReadLine());

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

                FlightPlan plan_b= new FlightPlan(identificador, "Unknown", ix, iy, fx, fy, speed);

                lista.AddFlight(plan_a);
                lista.AddFlight(plan_b);

                int i = 0;
                int ciclos = 10;
                int tiempoCiclo = 10;
                double safetyDistance = 10;
                while (i < ciclos)
                {
                    lista.Advance(tiempoCiclo);
                    lista.PrintToConsole();
                    lista.Advance(tiempoCiclo);
                    lista.PrintToConsole();
                    if(lista.GetFlightPlan(0).IsInConflictWith(lista.GetFlightPlan(1), safetyDistance))
                    {
                        Console.WriteLine("Conflicto entre los aviones");
                    }
                    i++;
                }

                Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato en la entrada de los valores");
            }
        }
    }
}
