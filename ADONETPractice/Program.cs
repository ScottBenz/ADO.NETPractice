using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataLayer.Models;
using ADONETPractice.Workflow;
using Northwind.DataLayer.Repositories;

namespace ADONETPractice
{
    class Program
    {
        static void Main()
        {
            var menu = new MainMenu();
            menu.Execute();
        }
    }
}



