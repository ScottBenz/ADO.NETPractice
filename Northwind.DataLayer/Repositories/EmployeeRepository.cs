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
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select e.FirstName, e.LastName, e.EmployeeID " +
                                  "From Employees as e ";

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
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

        private Employee PopulateEmployeeDataReader(SqlDataReader dr)
        {
            Employee employee = new Employee();
            EmployeeTerritories et = new EmployeeTerritories();

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
