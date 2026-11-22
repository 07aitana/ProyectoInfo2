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
        List<FlightPlan> flightPlans = new List<FlightPlan>();
        Stack<Position> positionHistory = new Stack<Position>();

        // Adds flight p, clears the undo history and returns 0.
        public int AddFlight(FlightPlan p)
        {
            flightPlans.Add(p);
            positionHistory.Clear();
            return 0;
        }

        // Returns the flight at index i, or null if the index is outside the list.
        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= flightPlans.Count)
            {
                return null;
            }
            else
            {
                return flightPlans[i];
            }
        }

        // Returns the flight with that id, or null if it is missing.
        public FlightPlan FindFlightById(string id)
        {
            int i = 0;
            while (i < flightPlans.Count)
            {
                if (flightPlans[i].GetId() == id)
                {
                    return flightPlans[i];
                }
                i++;
            }
            return null;
        }

        // Returns a new list of flights that start at the originals' current positions.
        public FlightPlanList Copy()
        {
            FlightPlanList copy = new FlightPlanList();

            for (int i = 0; i < flightPlans.Count; i++)
            {
                FlightPlan p = flightPlans[i];

                FlightPlan nuevo = new FlightPlan(
                    p.GetId(),
                    p.GetAirline(),
                    p.GetCurrentPosition().GetX(),
                    p.GetCurrentPosition().GetY(),
                    p.GetDestination().GetX(),
                    p.GetDestination().GetY(),
                    p.GetSpeed());

                copy.AddFlight(nuevo);
            }

            return copy;
        }

        // Copies speeds from the list otra. Both lists must have the same flight order.
        public void CopySpeedsFrom(FlightPlanList list)
        {
            for (int i = 0; i < flightPlans.Count; i++)
            {
                flightPlans[i].SetSpeed(list.GetFlightPlan(i).GetSpeed());
            }
        }

        // Returns the number of flights in the list.
        public int GetFlightCount()
        {
            return flightPlans.Count;
        }

        // Removes all flights from the list.
        public void ClearFlights()
        {
            flightPlans.Clear();
        }

        // Saves positions for undo, then moves the flights still in the air for elapsedMinutes.
        public void Advance(double elapsedMinutes)
        {
            if (AllFlightsHaveArrived())
            {
                return;
            }

            for (int k = 0; k < flightPlans.Count; k++)
            {
                double x = flightPlans[k].GetCurrentPosition().GetX();
                double y = flightPlans[k].GetCurrentPosition().GetY();
                positionHistory.Push(new Position(x, y));
            }

            int i = 0;
            while (i < flightPlans.Count)
            {
                if (!flightPlans[i].HasArrived())
                {
                    flightPlans[i].Advance(elapsedMinutes);
                }
                i++;
            }
        }

        // Prints each flight's details.
        public void PrintToConsole()
        {
            int i = 0;
            while (i < flightPlans.Count)
            {
                flightPlans[i].PrintToConsole();
                i++;
            }
        }

        // Loads flights from filePath and replaces the list only if the whole file is valid.
        // Returns 0 if loaded, -1 if missing, -2 if empty, -3 for invalid data or -4 for duplicate IDs.
        public int LoadFlights(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return -1;
            }

            List<FlightPlan> loadedFlights = new List<FlightPlan>();
            int result = 0;

            StreamReader f = new StreamReader(filePath);
            string linea = f.ReadLine();

            while (linea != null && result == 0)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    string[] fields = linea.Split();

                    if (fields.Length != 7)
                    {
                        result = -3;
                    }
                    else
                    {
                        try
                        {
                            FlightPlan p = new FlightPlan(
                                fields[0], fields[1],
                                Convert.ToDouble(fields[2]),
                                Convert.ToDouble(fields[3]),
                                Convert.ToDouble(fields[4]),
                                Convert.ToDouble(fields[5]),
                                Convert.ToDouble(fields[6]));

                            if (p.GetSpeed() <= 0)
                            {
                                result = -3;
                            }
                            else
                            {
                                bool duplicateId = false;
                                int i = 0;
                                while (i < loadedFlights.Count && !duplicateId)
                                {
                                    if (loadedFlights[i].GetId() == p.GetId())
                                    {
                                        duplicateId = true;
                                    }
                                    i++;
                                }

                                if (duplicateId)
                                {
                                    result = -4;
                                }
                                else
                                {
                                    loadedFlights.Add(p);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            result = -3;
                        }
                    }
                }
                linea = f.ReadLine();
            }
            f.Close();

            if (result == 0 && loadedFlights.Count == 0)
            {
                result = -2;
            }

            if (result == 0)
            {
                flightPlans = loadedFlights;
                positionHistory.Clear();
            }

            return result;
        }

        // Returns true if any two flights will come closer than safetyDistance (km).
        public bool HasPredictedConflicts(double safetyDistance)
        {
            for (int i = 0; i < flightPlans.Count; i++)
            {
                for (int j = i + 1; j < flightPlans.Count; j++)
                {
                    if (flightPlans[i].WillConflictWith(flightPlans[j], safetyDistance))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Returns true when all flights are at their destinations.
        public bool AllFlightsHaveArrived()
        {
            for (int i = 0; i < flightPlans.Count; i++)
            {
                if (!flightPlans[i].HasArrived())
                {
                    return false;
                }
            }

            return true;
        }

        // Moves all flights back to their starting points and clears the undo history.
        public void Reset()
        {
            for (int i = 0; i < flightPlans.Count; i++)
            {
                flightPlans[i].Reset();
            }
            positionHistory.Clear();
        }

        // Returns true if it puts the flights back where they were before the last step.
        public bool UndoLastStep()
        {
            if (positionHistory.Count == 0)
            {
                return false;
            }

            // Pop positions in reverse order to match the flights.
            for (int i = flightPlans.Count - 1; i >= 0; i--)
            {
                flightPlans[i].SetCurrentPosition(positionHistory.Pop());
            }
            return true;
        }

        // Saves the flights and their current positions to filePath.
        public void SaveFlights(string filePath)
        {
            StreamWriter w = new StreamWriter(filePath);

            for (int i = 0; i < flightPlans.Count; ++i)
            {
                FlightPlan p = flightPlans[i];

                w.WriteLine("{0} {1} {2} {3} {4} {5} {6}",
                p.GetId(),
                p.GetAirline(),
                p.GetCurrentPosition().GetX(),
                p.GetCurrentPosition().GetY(),
                p.GetDestination().GetX(),
                p.GetDestination().GetY(),
                p.GetSpeed());
            }
            w.Close();
        }

        // Slows flights down in up to 20 rounds to keep them at least safetyDistance km apart.
        // Returns true if no future conflicts remain.
        public bool TryResolveConflicts(double safetyDistance)
        {
            int attempts = 0;

            while (HasPredictedConflicts(safetyDistance) && attempts < 20)
            {
                bool speedChanged = false;

                for (int i = 0; i < flightPlans.Count; i++)
                {
                    for (int j = i + 1; j < flightPlans.Count; j++)
                    {
                        if (flightPlans[i].WillConflictWith(flightPlans[j], safetyDistance))
                        {
                            flightPlans[j].SetSpeed(
                                flightPlans[j].GetSpeed() * 0.9
                            );

                            speedChanged = true;
                        }
                    }
                }

                if (!speedChanged)
                {
                    break;
                }

                attempts++;
            }

            return !HasPredictedConflicts(safetyDistance);
        }

        // Returns true if any two flights are closer than safetyDistance (km) right now.
        public bool HasCurrentConflicts(double safetyDistance)
        {
            for (int i = 0; i < flightPlans.Count; i++)
            {
                for (int j = i + 1; j < flightPlans.Count; j++)
                {
                    if (flightPlans[i].IsInConflictWith(flightPlans[j], safetyDistance))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
