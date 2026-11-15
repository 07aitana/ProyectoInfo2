using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList

    {
        List<FlightPlan> flightplans = new List<FlightPlan>();
        Stack<Position> historial = new Stack<Position>();

        public int AddFlightPlan(FlightPlan p)
        {
            flightplans.Add (p);
            return 0;
        }


        public FlightPlan GetFlightPlan (int i)
        {
            if (i < 0 || i >= flightplans.Count)
            {
                return null;
            }
            else
            {
                return flightplans[i];
            }
    
        }

        public int GetNumber()
        {
            return flightplans.Count;
        }

        public void Clear()
        {
            flightplans.Clear();
        }

        public void Mover (double tiempo)
        { 
            if (TodosHanLlegado())
            {
                return;
            }

            // Guardamos una copia de la posición de cada avion para utlitzarlo en Stacks
            for (int k = 0; k < flightplans.Count; k++)
            {
                double x = flightplans[k].GetCurrentPosition().GetX();
                double y = flightplans[k].GetCurrentPosition ().GetY();
                historial.Push(new Position(x, y));
            }
            
            int i = 0;
            while (i< flightplans.Count)
            {
                if (!flightplans[i].HaLlegado())
                {
                    flightplans[i].Mover(tiempo);
                }
                i++;
            }

        }

        public void EscribeConsola()
        {
            int i = 0;
            while (i < flightplans.Count)
            {
                flightplans[i].EscribeConsola();
                i++;
            }
        }

        public void LoadFlightPlans(string nombreFichero)
        {
            flightplans.Clear();
            historial.Clear();

            StreamReader f = new StreamReader(nombreFichero);
            string linea = f.ReadLine();

            while(linea != null)
            {
                if (!string.IsNullOrWhiteSpace(linea)) //Establece que la linea no es nula y no contiene solo espacios en blanco
                {
                    string[] partes = linea.Split();

                    FlightPlan p = new FlightPlan(
                        partes[0], partes[1],
                        Convert.ToDouble(partes[2]),
                        Convert.ToDouble(partes[3]),
                        Convert.ToDouble(partes[4]),
                        Convert.ToDouble(partes[5]),
                        Convert.ToDouble(partes[6]));

                    flightplans.Add(p);
                }
                linea = f.ReadLine();
            }
            f.Close();

        }

        public bool HabraConflictos(double safetyDistance)
        {
            for (int i = 0; i < flightplans.Count; i++)
            {
                for (int j = i + 1; j < flightplans.Count; j++)
                {
                    if (flightplans[i].HabraConflicto(flightplans[j], safetyDistance))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    
        public bool TodosHanLlegado()
        {
            for (int i = 0; i < flightplans.Count; i++)
            {
                if (!flightplans[i].HaLlegado())
                {
                    return false;
                }
            }

            return true;
        }

        // Reinicia todos los aviones
        public void Restart()
        {
            for(int i = 0; i < flightplans.Count; i++)
            {
                flightplans[i].Restart();
            }
            historial.Clear();
        }

        // Devuelve los avions a las posiciones que estaban
        public bool Deshacer()
        {
            if (historial.Count  == 0)
            {  
                return false; 
            }

            // Como stack saca al reves, lo recorremos del final al principio
            for (int i = flightplans.Count -1; i >= 0; i--)
            {
                flightplans[i].SetCurrentPosition(historial.Pop());
            }
            return true;
        }

        // Guarda la lista de vuelos en un fichero de texto
        public void SaveFlightPlans(string nombreFichero)
        {
            StreamWriter w = new StreamWriter(nombreFichero);

            for (int i = 0; i < flightplans.Count; ++i)
            {
                FlightPlan p = flightplans[i];

                w.WriteLine("{0} {1} {2} {3} {4} {5} {6}",
                p.GetId(),
                p.GetCompany(),
                p.GetCurrentPosition().GetX(),
                p.GetCurrentPosition().GetY(),
                p.GetFinalPosition().GetX(),
                p.GetFinalPosition().GetY(),
                p.GetVelocidad());
            }
            w.Close();
        }

        public bool ResolverConflictos(double safetyDistance)
        {
            int intentos = 0;

            while (HabraConflictos(safetyDistance) && intentos < 20)
            {
                bool cambio = false;

                for (int i = 0; i < flightplans.Count; i++)
                {
                    for (int j = i + 1; j < flightplans.Count; j++)
                    {
                        if (flightplans[i].HabraConflicto(flightplans[j], safetyDistance))
                        {
                            flightplans[j].SetVelocidad(
                                flightplans[j].GetVelocidad() * 0.9
                            );

                            cambio = true;
                        }
                    }
                }

                if (!cambio)
                {
                    break;
                }

                intentos++;
            }

            return !HabraConflictos(safetyDistance);
    
        }

        public bool HayConflictoActual(double safetyDistance)
        {
            for (int i = 0; i < flightplans.Count; i++)
            {
                for (int j = i + 1; j < flightplans.Count; j++)
                {
                    if (flightplans[i].Conflicto(flightplans[j], safetyDistance))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}