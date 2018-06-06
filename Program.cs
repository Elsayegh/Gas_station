using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation
{

    class Program
    {
        //adding the vehicles that has been served and the vehicles that are waiting in the queue, each to a list
        public static List<Vehicle> vehiclesWaiting;
        public static List<Vehicle> vehiclesServed;
        //adding the transactions into a list
        public static List<Transaction> transactions;

        // vehicles types
        public static string[] vehicleTypes = { "Car", "Van", "HGV" };
        // fuel types
        public static string[] fuelTypes = { "Unleaded", "Diesel", "LPG" };
        // counter of the served cars
        public static int servedVehicles = 0;
        //counter for the cars that left without serving
        public static int unservedVehicles = 0;

        static void Main(string[] args)
        {
            // Initialize timer with the current time.
            DateTime timer = DateTime.Now;
            DateTime lifeSpan = DateTime.Now;
            Random rnd = new Random();
            // creating a new vehciles between 1500 and 2200 Mlseconds
            double randomVehicleMs = rnd.Next(1500, 2200);
            //double randomPumpingTime = (rnd.NextDouble() * (17000 - 19000) + 19000);

            //int counter = 0;

            vehiclesWaiting = new List<Vehicle>();
            vehiclesServed = new List<Vehicle>();
            transactions = new List<Transaction>();

            // Initiating pumps: 9 pumps
            pump[] pumps = pump.initiatePumps(9);
            int lifeInMinutes = 1;
            Employee[] employees = Employee.initEmployees(9);
            

            // Main loop
            while (DateTime.Now.Subtract(lifeSpan).TotalMinutes <= lifeInMinutes)
            {
                if (vehiclesWaiting.Count > 1)
                { // checking if there are any cars in the waiting queue
                    // Console.WriteLine("Cars waiting in queue" + vehiclesWaiting.Count);
                    for (int i = 0; i < vehiclesWaiting.Count; i++)
                    { // looping over all cars in the queue

                        Vehicle currentVehicle = vehiclesWaiting[i];
                        if (DateTime.Now.Subtract(currentVehicle.timeEntered).TotalMilliseconds >= currentVehicle.maxWaitingTime)
                        { // if the car waiting time is exceeded
                            vehiclesWaiting.Remove(currentVehicle);//remove car from the queue
                            unservedVehicles++; // increment unserverd cars by one
                        }
                    }

                }

                if (DateTime.Now.Subtract(timer).TotalMilliseconds >= randomVehicleMs)
                {

                    timer = DateTime.Now; // current time
                    int carsCount = vehiclesWaiting.Count; //number of cars in the queue
                    if (carsCount >= 5)
                    { // if the cars waiting are more than 5 cars, the car would leave
                        Console.WriteLine("Queue Full");
                    }
                    else if (carsCount < 5)
                    {
                        int vehicleTypeIndex = rnd.Next(0, 3); // random index for the car type
                        vehiclesWaiting.Add(new Vehicle(vehicleTypes[vehicleTypeIndex])); // add a new vehcile to the waiting queue

                        //Console.WriteLine(DateTime.Now + " New car created: " + vehiclesWaiting[0].carName);
                        //Console.WriteLine("Random timer is: " + randomVehicleMs);

                    }
                    // Update the random number for the next car
                    randomVehicleMs = rnd.Next(1500, 2200);


                }

                //  looping over all pumps
                for (int i = 0; i < pumps.Length; i++)
                {

                    if (pumps[i].pumpFree == true)
                    { // if a pump is free

                        if (vehiclesWaiting.Count > 1 && pumps[i].pumpFree == true)
                        { // if there exists a vheicle in the queue and the pump is free
                          // Console.WriteLine("Pump free car assigned" + pumps[i].pumpNo);
                            Vehicle currentVehicle = vehiclesWaiting[0];
                            // setting start time of the car for the pump as now
                            pumps[i].carStart = DateTime.Now;
                            // the car number in the pump
                            pumps[i].carNo = currentVehicle.carName;
                            // the vehicle currently in the pump
                            pumps[i].v = currentVehicle;

                            // change the car status to busy pump 
                            pumps[i].pumpFree = false;
                            // vehicle as served
                            currentVehicle.served = true;
                            //Console.WriteLine("Pump No: " + pumps[i].pumpNo + "\ncar" + currentVehicle.carName);
                            // add the vehcile to the served list
                            vehiclesServed.Add(currentVehicle);
                            // increment the number of served vehicles by one
                            servedVehicles++;
                            // remove the vehicle from the queue
                            vehiclesWaiting.Remove(currentVehicle);
                            // clear the console
                            Console.Clear();
                            // draw the gui after clearning the console
                            Interface.DrawPumps(pumps, vehiclesServed, vehiclesWaiting);
                        }
                    }

                    // check the current pump if its not free
                    else if (pumps[i].pumpFree == false)
                    {
                        // if a car took more than the pumping duration of the car
                        if (DateTime.Now.Subtract(pumps[i].carStart).TotalSeconds >= pumps[i].v.pumpingDuration)
                        {
                            // current vehicle as the vehicle in the pump at i
                            Vehicle currentVehicle = pumps[i].v;
                            // Console.WriteLine("The car going to be removed is: " + currentVehicle.carName);

                            //creating a new transaction
                            Transaction t = new Transaction(currentVehicle.liters, currentVehicle.fuelType, pumps[i].pumpNo, currentVehicle.type);
                            // appending the transaction to the transactions list
                            transactions.Add(t);
                            // the car is served so remove it from the served vehicles list
                            vehiclesServed.Remove(currentVehicle);

                            // set the pump to free
                            pumps[i].pumpFree = true;
                            // clear the console
                            Console.Clear();
                            // draw the gui after clearning the console
                            Interface.DrawPumps(pumps, vehiclesServed, vehiclesWaiting);
                        }
                    }

                }
                
            }
            Console.Clear();
            // number of served cars
            Console.WriteLine("\nTotal Numbers of cars served: " + servedVehicles);
            // cars left without serving
            Console.WriteLine("Total Numbers of cars Left without Being served: " + unservedVehicles);
            for (int i = 0; i < employees.Length; i++) //Calculating the pay for each employee
            {
                employees[i].setEmployeePay(Transaction.commision, lifeInMinutes);
                Console.WriteLine(employees[i].getEmployeePay());
            }
            Console.WriteLine(Transaction.generateReport());


            Console.ReadLine();


        }


    }
}
