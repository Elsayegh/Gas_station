using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation
{
    class Transaction
    {
        // declaring class memebers
        public static int transactionNumber = 0;
        public int litresDispensed;
        private static int unleadedDispensed = 0;
        private static int LPGDispensed = 0;
        private static int dieselDispensed=0;
        private static double unleadedCost = 0.0;
        private static double LPGCost = 0.0;
        private static double dieselCost = 0.0;
        private static double totalCost = 0.0;
        public static double commision = 0.0;
        private int pumpNumber;
        private string vehicleType;

        public static int totalLitersDispensed = 0;
        public Transaction(int litresDispensed, string fuelType, int pumpNumber, string vehicleType)
        { 
            // the transaction constructor
            this.pumpNumber = pumpNumber;
            this.vehicleType = vehicleType;
            this.litresDispensed = litresDispensed;
            totalLitersDispensed += litresDispensed;
            calculateTotalFuelDispensed(fuelType, litresDispensed);
            transactionNumber++;

        }
        private static string calculateTotalCost()
        { 
            // Claculating total cost including the commision 1% of the total transaction
            double combinedCost = unleadedCost + dieselCost + LPGCost;
            
            totalCost = (combinedCost/100) + combinedCost;
            commision = totalCost;
            return totalCost.ToString();
        }
        private static void calculateTotalFuelDispensed(string fuelType, int litersDispensed)
        {
            switch (fuelType)
            {
                // In cas car, can be any of the types in the array
                case "Unleaded": 
                    unleadedDispensed += litersDispensed;
                    unleadedCost = unleadedCost + (unleadedDispensed * 1.2);

                    break;
                case "Diesel":
                    dieselDispensed+= litersDispensed;
                    dieselCost = dieselCost+ (dieselDispensed * 0.9);
                    break;
                case "LPG":
                    LPGDispensed+= litersDispensed;
                    LPGCost = LPGCost + (LPGDispensed * 0.74);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
        public static string generateReport()
        {
            return "\nTotal of: " + "Unleaded: "
                + unleadedCost.ToString() + "\nDiesel: " + dieselCost.ToString() +
                "\nLPG: " + LPGCost.ToString() + "\nCombined total cost inlcuding commision: " + calculateTotalCost();
        }

    }

}
