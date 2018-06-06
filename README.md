# Gas_station
Introduction:
This a program for unlimited ltd petrol station using C# for implementation through visual studio. this report is divided into five sections which are the user guide, the implementation(design) that is showing the program details, classes and algorithm and then that coming is the testing, finally the referencing.

User Guide:

The lifespan is controlled by time, changing the variable LifeinMinutes to the required minutes of running the program. Figure 0 shows the main interface, the top part includes the vehicles that are using the pumps. The middle part after pump status, contains the number of the pump, and then the car number that using which pump. Finally. The vehicles queueing has the vehicles waiting in the queue to be served. 
At the end of the app lifecycle, the report is created, in addition to the number of vehicles that has been served and the number of vehicles that left without being served as shown in Figure 5 in the testing. The user can call the GenerateReport function from the class Transaction that will provide a summary of the transactions that occurred in the life time of the program. Finally, the employee number and his total Pay.

Design and Implementation:
This program contains 6 classes, all of the classes are designed to be extended and have the methods required.
Interface: this class is showing the console screen and the pumps. It has also two queues, first queue for the vehicles that are not served yet and second for the vehicles that has been served. It has only one function which is Drawpumps and it takes three arguments that are an array of pumps and two lists of vehicles type.

Pump: this class contains the pumps members and the attributes and the constructor that initialize the new object with a static number and also the pump number, and this number incremented with creation of new pump with a static number as it’s the pump number. This class also has only one function that takes the number of pumps and return array of pumps.

Vehicle: that class has number of functionalities that implemented in the class. First of all, in the constructor there is a random maximum waiting time generated and the time of when a new object vehicle created assigned to time timeEntered which means a new car has arrived to the petrol station in the application. Secondly, the setFuelType function that takes the vehicle type and assign the fuel type for it which (unleaded, diesel or LPG ) and a switch case implemented and random generators, for car the random generator index from 0 to 2, for van from index 1 to 2 and HGV is always diesel. And finally the setRandomGasFilling Method, the amount of fuel already existing in the care is calculated , the maximum quarter of a tank is calculated as (25x vehicleMaxTank)/100, followed by a random number generator between 0 and the maximum of a quarter of a tank, then the pumping duration as vehicleMaxTank-existingFuelAmount / 1.5 seconds, and amount of liters as just vehicleMaxTank- existingFuelAmount. Also, a switch case to identify which car type and the corrosponding maximum existing fuel in a vehicle.

Transaction: the main attributes of these class stores the VehicleType, FuelType, pump number and litres dispensed. Each time a new transaction created, the function calculateTotalFuelDispensed called, and there is a switch case to identify the fuel type and calculate the cost, it calculate the dispensed amount to the previous amount that is static variable and each fuel type calculated separately, the calculateTotalCost is called at the end of the lifetime of the program and in the generateReport method that adds the total of all the fuel types together and calculate the 1% commission. 

Empolyee: that class in to calculate the pay roll for the employees and it contains three functions which are the setEmployeePay function to calculate the pay per hour. And the second function is getEmployeePay and its to show the employee and the payment he should be receiving. Last function is a static function called initEmployees and this function is to initiate the employees in array.

Finally, the MainProgram: There are two main Lists created of type Vehicle: VehiclesWaiting which includes the vehicles that are in the queue and not served yet and VehiclesServed which includes the vehicles that are being served. The main loop is controlled by variable lifespan which is of type Datetime. The main algorithm is:
If the vehiclesWaiting is not empty
	Loop over the vehiclesWiting list
	If the maxwaitingtime is exceeded, then remove the car from the queue
	Else if vheicleswaiting bigger than 5 then queue is full
If vehiclesWaiting < 5 and the time now- time equal to random generator then
	Add new car to vehiclesWaiting
Loop over pumps:
	If pump is free then assign a vehicle from the vehicleswaiting and remove from the qeue and add to vehiclesserved queue.
	If pump is not free then check the pumping duration
		If the pumping duration is over and the vehicle is served then create transaction, free the pump and remove the car from the vehiclesserved list.

There is class lane but I couldn’t do it properly so it’s not used anymore in the program.


