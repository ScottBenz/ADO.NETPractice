using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataLayer.Models;
using ADONETPractice.Workflow;
using Northwind.DataLayer.Repositories;

namespace ADONETPractice.Workflow
{
    public class MainMenu
    {

        public void Execute()
        {
            string input = "";
            int inputNum = 0;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(" ADO .NET DEMO");
                Console.WriteLine(" -------------");
                Console.WriteLine(" 1. View All Employees");
                Console.WriteLine(" 2. View Employees Territories");
                Console.WriteLine(" 3. Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write(" Please Enter A Choice: ");

                input = Console.ReadLine();

                int.TryParse(input, out inputNum);

                if (inputNum >= 1 && inputNum <= 2)
                {
                    ProcessChoice(inputNum);
                }

                else if (inputNum == 3)
                {
                    Console.WriteLine("Closing program...");
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                }

            } while (inputNum != 3);
        }

        private void ProcessChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    ShowAllEmployees();
                    Console.WriteLine("Press Enter to go back to the main menu...");
                    Console.ReadLine();
                    break;
                case 2:
                    ShowAllEmployeeTerritories();
                    Console.WriteLine("Press Enter to go back to the main menu...");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
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
                Console.WriteLine("{0, -17}, Employee ID: {1}, Territory: {2}", e.LastName + ", " + e.FirstName, e.EmpTerr.EmployeeId, e.EmpTerr.TerritoryId);
                Console.WriteLine();
            }
        }
    }
}
