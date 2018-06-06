using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation
{

    class pump
    {
        // the pumps class variables
        public bool pumpFree = true;
        public Vehicle v;
        public static int pumps = 0;
        public int pumpNo;
        public DateTime carStart;
        // public bool blocked = false;
        public int carNo;

        // the constructor 
        public pump()
        {
            // increasing number of pumps by 1
            pumps += 1;
            // the current pump number
            pumpNo = pumps;
        }
        public static pump[] initiatePumps(int numOfPumps)
        { // Initializing pumps, the parameter is the number of pumps
            pump[] pumps = new pump[numOfPumps];
            for (int i = 0; i < numOfPumps; i++)
            { // iterating over the number of pumps that are required
                pumps[i] = new pump();
            }
            return pumps;
        }
    }
}
