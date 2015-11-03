using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Northwind.DataLayer.Config;
using Northwind.DataLayer.Models;

namespace Northwind.DataLayer.Repositories
{
    public class EmployeeRepository
    {
        //Creating a new List of employees method.
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            //Our using statement is establishing a link our connection string in Settings.cs
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                // This is the SQL command from the namespace System.Data.SQLClient.
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select e.FirstName, e.LastName, e.EmployeeID " +
                                  "From Employees as e ";

                cmd.Connection = cn;
                cn.Open(); // must have "Open();" connection to query.

                //Call ExecuteReader to have the command create a 
                //data reader, this executes the SQL Statement.
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    //Read() returns false when there is no more data.
                    while (dr.Read())
                    {
                        employees.Add(PopulateEmployeeDataReader(dr));
                    }
                }
            }

            return employees;
        } 

        public List<Employee> GetEmployeeTerritories()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select e.EmployeeID, e.FirstName, e.LastName, " +
                                  "EmployeeTerritories.TerritoryID, EmployeeTerritories.EmployeeID " +
                                  "From Employees as e " +
                                  "RIGHT JOIN EmployeeTerritories " +
                                  "ON e.EmployeeID = EmployeeTerritories.EmployeeID";

                cmd.Connection = cn;
                cn.Open();

                // ExecuteReader runs the SQL statement and returns a DataReader with all the result rows in it.
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        employees.Add(PopulateFromDataReader(dr));
                    }
                }
            }

            return employees;
        }

        //This is our method that's creating our Employee definition from DataReader.
        private Employee PopulateEmployeeDataReader(SqlDataReader dr)
        {
            Employee employee = new Employee();
            
            employee.EmployeeId = (int) dr["EmployeeID"];
            employee.LastName = dr["LastName"].ToString();
            employee.FirstName = dr["FirstName"].ToString();

            return employee;
        }

        private Employee PopulateFromDataReader(SqlDataReader dr)
        {
            Employee employee = new Employee();
            EmployeeTerritories et = new EmployeeTerritories();

            employee.EmployeeId = (int)dr["EmployeeID"];
            employee.LastName = dr["LastName"].ToString();
            employee.FirstName = dr["FirstName"].ToString();

            employee.EmpTerr = et;
            employee.EmpTerr.TerritoryId = int.Parse(dr["TerritoryID"].ToString());
            employee.EmpTerr.EmployeeId = int.Parse(dr["EmployeeID"].ToString());

            return employee;
        }
    }
}
