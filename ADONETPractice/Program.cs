using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataLayer.Models;
using Northwind.DataLayer.Repositories;

namespace ADONETPractice
{
    class Program
    {
        static void Main()
        {
            ShowAllEmployees();
            ShowAllEmployeeTerritories();

            Console.ReadLine();
        }

        private static void ShowAllEmployees()
        {
            EmployeeRepository repo = new EmployeeRepository();

            Console.WriteLine("All Employees");
            Console.WriteLine("-------------");
            Console.WriteLine();

            foreach (Employee e in repo.GetAllEmployees())
            {
                Console.WriteLine("{0, -17}, Employee ID: {1}", e.LastName + ", " + e.FirstName, e.EmployeeId);
                Console.WriteLine();
            }
        }

        private static void ShowAllEmployeeTerritories()
        {
            EmployeeRepository repo = new EmployeeRepository();

            Console.WriteLine("All Employees and Territories");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            foreach (Employee e in repo.GetEmployeeTerritories())
            {
                Console.WriteLine("{0, -17}, Employee ID: {1}, Territory: {2}", e.LastName + ", " + e.FirstName, e.EmpTerr.EmployeeId, e.EmpTerr.TerritoryId );
                Console.WriteLine();
            }
        }
    }
}
