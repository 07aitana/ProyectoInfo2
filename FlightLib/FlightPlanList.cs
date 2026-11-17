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

        // Añade un vuelo a la lista.
        // Borramos el historial de Undo porque los pasos guardados ya no tienen el mismo número de aviones.
        public int AddFlightPlan(FlightPlan p)
        {
            flightplans.Add(p);
            historial.Clear();
            return 0;
        }


        public FlightPlan GetFlightPlan(int i)
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

        public void Mover(double tiempo)
        {
            if (TodosHanLlegado())
            {
                return;
            }

            // Guardamos una copia de la posición de cada avion para utlitzarlo en Stacks
            for (int k = 0; k < flightplans.Count; k++)
            {
                double x = flightplans[k].GetCurrentPosition().GetX();
                double y = flightplans[k].GetCurrentPosition().GetY();
                historial.Push(new Position(x, y));
            }

            int i = 0;
            while (i < flightplans.Count)
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

        // Carga los vuelos de un fichero de texto.
        // Formato de cada línea: ID Compañía Xinicial Yinicial Xfinal Yfinal Velocidad
        // Devuelve: 0 si todo va bien, -1 si el fichero no existe, -2 si no contiene vuelos,
        // -3 si alguna línea es incorrecta y -4 si hay dos vuelos con el mismo ID.
        // Si hay algún error, la lista de vuelos que había antes no se modifica.
        public int LoadFlightPlans(string nombreFichero)
        {
            if (!File.Exists(nombreFichero))
            {
                return -1;
            }

            // Leemos primero en una lista nueva; solo la usamos si todo el fichero es correcto
            List<FlightPlan> nuevos = new List<FlightPlan>();
            int resultado = 0;

            StreamReader f = new StreamReader(nombreFichero);
            string linea = f.ReadLine();

            while (linea != null && resultado == 0)
            {
                if (!string.IsNullOrWhiteSpace(linea)) //Establece que la linea no es nula y no contiene solo espacios en blanco
                {
                    string[] partes = linea.Split();

                    if (partes.Length != 7)
                    {
                        resultado = -3; // faltan o sobran datos en la línea
                    }
                    else
                    {
                        try
                        {
                            FlightPlan p = new FlightPlan(
                                partes[0], partes[1],
                                Convert.ToDouble(partes[2]),
                                Convert.ToDouble(partes[3]),
                                Convert.ToDouble(partes[4]),
                                Convert.ToDouble(partes[5]),
                                Convert.ToDouble(partes[6]));

                            if (p.GetVelocidad() <= 0)
                            {
                                resultado = -3; // velocidad no válida
                            }
                            else
                            {
                                // Buscamos si ya hay un vuelo con el mismo ID
                                bool repetido = false;
                                int i = 0;
                                while (i < nuevos.Count && !repetido)
                                {
                                    if (nuevos[i].GetId() == p.GetId())
                                    {
                                        repetido = true;
                                    }
                                    i++;
                                }

                                if (repetido)
                                {
                                    resultado = -4;
                                }
                                else
                                {
                                    nuevos.Add(p);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            resultado = -3; // hay texto donde debería haber un número
                        }
                    }
                }
                linea = f.ReadLine();
            }
            f.Close();

            if (resultado == 0 && nuevos.Count == 0)
            {
                resultado = -2;
            }

            if (resultado == 0)
            {
                flightplans = nuevos;
                historial.Clear();
            }

            return resultado;
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
            for (int i = 0; i < flightplans.Count; i++)
            {
                flightplans[i].Restart();
            }
            historial.Clear();
        }

        // Devuelve los avions a las posiciones que estaban
        public bool Deshacer()
        {
            if (historial.Count == 0)
            {
                return false;
            }

            // Como stack saca al reves, lo recorremos del final al principio
            for (int i = flightplans.Count - 1; i >= 0; i--)
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