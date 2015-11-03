using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

// Adding a System.Configuration namespace and reference allows us to connect to the Northwind database.
namespace Northwind.DataLayer.Config
{
    public static class Settings
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    //Settings.cs is connecting to App.config using the conectionstring and name we assigned it. "NorthWind".
                    //Settings.cs says to "get" our connectionstring much in the same way that a model class has fields that are assigned "{get;}"
                    _connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
                }

                return _connectionString;
            }
        }
    }
}
