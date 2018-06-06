using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation
{
    class Interface
    {
       
        public static void DrawPumps(pump[] p, List<Vehicle> vehicles, List<Vehicle> vehiclesQueue)
        {

            Console.WriteLine("Vehicles Bieng served:");
            Vehicle v;
            
            for (int i = 0; i < vehicles.Count; i++)
            {

                v = vehicles[i];
                Console.Write("#{0} Fuel Type: {1} | ", v.carName, v.fuelType);
            }
            Console.WriteLine("\n Pumps Status:");

            for (int i = 0; i < 9; i++)
            {
        
                Console.Write("#{0} ", i + 1);
                if (p[i].pumpFree == true) { Console.Write("FREE"); }
                else { Console.Write("CarNo: #{0}" , p[i].v.carName); }
                Console.Write(" | ");
                if (i % 3 == 2) { Console.WriteLine(""); }

            }
            Console.WriteLine("Vehicles queueing:");
            
            for (int i = 0; i < vehiclesQueue.Count; i++)
            {
                
                v = vehiclesQueue[i];
                Console.Write("# Car Number: {0} Fuel Type: {1}  | ", v.carName, v.fuelType, v.pumpingDuration);
            }

        }
    }
}
