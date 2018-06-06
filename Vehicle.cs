using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation
{
    class Vehicle
    {
        // Vehcile class variables
        public static int totalCars = 0;
        public string type;
        public string fuelType;
        public int liters;
        public bool served = false;
        public int carName;
        public DateTime timeEntered;
        public int maxWaitingTime;
        static Random rnd = new Random();
        public double pumpingDuration;
        private int exististingFuelAmout;
        private static string[] fuelTypes = { "Unleaded", "Diesel", "LPG" };

        public Vehicle(string type)
        {
            this.carName = totalCars;
            
            this.type = type;
            // Time when care entered
            this.timeEntered = DateTime.Now;
            // Random max waiting time in queue
            this.maxWaitingTime = rnd.Next(1000, 2000);
            //setting the random gas existing in the car and pumping duration
            setRandomGasFilling(type);
            setFuelType(type);
            // The duration the car will take for pumping
            //this.pumpingDuration = rnd.Next(17000, 19000);
            totalCars += 1;
            //Console.WriteLine(carName.ToString() + " / " + fuelType.ToString());
           // Console.WriteLine(this.type.ToString() + " / " + this.timeEntered.ToString());
           // Console.WriteLine(this.maxWaitingTime.ToString() + "/ " + this.exististingFuelAmout.ToString());
        }
        private void setFuelType(string carType)
        {
            // Switch case for fuel types
            int fuelTypeIndex; 
            switch (carType)
            {
                // In case car, can be any of the types in the array
                case "Car": 
                    fuelTypeIndex = rnd.Next(0, 3);
                    this.fuelType = fuelTypes[fuelTypeIndex];
                    break;
                case "Van":
                    // In caase van, only the types at index 1 or 2
                    fuelTypeIndex = rnd.Next(1, 2);
                    this.fuelType = fuelTypes[fuelTypeIndex];
                    break;
                case "HGV":
                    // in case hgv, only diesel at index 1
                    this.fuelType = fuelTypes[1]; 
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            
        }
        private void setRandomGasFilling(string carType)
        {
            /*Function to put random fuel amount in the car which is less than quarter
            calcualte the total time for dispensing fuel
            calcuating total number of fuel for each car that will be dispensed*/

           Random rnd = new Random();
            int fillRange = 0;
            switch (carType)
            {
                case "Car":
                    // to calculate quarter of a tank
                    fillRange = (25 * 40) / 100;
                    // random range between 0 and the filrange
                    exististingFuelAmout = rnd.Next(0, fillRange);
                    // the pumping duration in seconds 
                    pumpingDuration = (40 - exististingFuelAmout) / 1.5;
                    // the liters required for the car
                    this.liters = 40 - exististingFuelAmout; 
                    //Console.WriteLine("Liters to be despensed: CAR" + pumpingDuration);
                    break;
                case "Van":
                    fillRange = (25 * 80) / 100;
                    exististingFuelAmout = rnd.Next(0, fillRange);
                    pumpingDuration = (80 - exististingFuelAmout) / 1.5;
                    this.liters = 80 - exististingFuelAmout;
                   // Console.WriteLine("Liters to be despensed: VAN" + pumpingDuration);
                    break;
                case "HGV":
                    fillRange = (25 * 150) / 100;
                    exististingFuelAmout = rnd.Next(0, fillRange);
                    pumpingDuration = (150 - exististingFuelAmout) / 1.5;
                    this.liters = 150 - exististingFuelAmout;
                   // Console.WriteLine("Liters to be despensed: HGV" + pumpingDuration);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }
    }
}
