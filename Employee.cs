using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation
{
    class Employee
    {
        // class variables 
        static int employeeCount = 0;
        private int employeeNo;
        private double pay;
        private static double hourlyRate = 2.49;

        // constructor
        public Employee()
        {
            employeeNo = employeeCount;
            employeeCount++;
        }

        //calculate the pay per hour for employees
        public void setEmployeePay(double commision, int hoursWorked)
        {
            this.pay = commision + (hoursWorked * hourlyRate);
        }

        // to show the employee and the payment he is recieving 
        public string getEmployeePay()
        {
            return "Employee No: "+this.employeeNo.ToString() + " Total Pay: " +this.pay.ToString();
        }

        // to create the emplyees 
        public static Employee[] initEmployees(int numOfEmployees)
        { // Initializing pumps, the parameter is the number of pumps
            Employee[] employees = new Employee[numOfEmployees];
            for (int i = 0; i < numOfEmployees; i++)
            { // iterating over the number of pumps that are required
                employees[i] = new Employee();
            }
            return employees;
        }
    }
}
