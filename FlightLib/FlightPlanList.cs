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


            StreamReader f = new StreamReader(nombreFichero);
            string linea = f.ReadLine();

            while(linea != null)
            {
                string[] partes = linea.Split();
                FlightPlan p = new FlightPlan(partes[0], Convert.ToDouble(partes[1]), Convert.ToDouble(partes[2]), 
                    Convert.ToDouble(partes[3]), Convert.ToDouble(partes[4]), Convert.ToDouble(partes[5]));
                flightplans.Add(p);
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