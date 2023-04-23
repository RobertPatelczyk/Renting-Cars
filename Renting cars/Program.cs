using Renting_cars.Admin_panel;
using Renting_cars.Logging;
using Renting_cars.Loops;
using Renting_cars.Renting;
using Renting_cars.Sqlite;
using Renting_cars.Sqlite.Create_Tables;
using Renting_cars.Sqlite.InsertData;
using System;

namespace Renting_cars
{
    class Program
    {
        static void Main(string[] args)
        {
            JoinMostImportantClasses joinMostImportantClasses = new JoinMostImportantClasses();
            joinMostImportantClasses.StartProgram();
        }
    }
}
