using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Renting_cars.WriteAndRead;

namespace Renting_cars.Sqlite
{
    class CreateFile
    {
        public SQLiteConnection myConnection;
        public CreateFile()
        {
            Write write = new Write();
            myConnection = new SQLiteConnection("Data Source = RentingCars.sqlite3");
            if (!File.Exists("./RentingCars.sqlite3"))
            {
                SQLiteConnection.CreateFile("RentingCars.sqlite3");
                write.WriteData("Data file has been created.");
            }
        }
        //replaced by using's

        //public void OpenConnection()
        //{
        //    if (myConnection.State != System.Data.ConnectionState.Open)
        //    {
        //        myConnection.Open();
        //    }
        //}
        //public void CloseConnection()
        //{
        //    if (myConnection.State != System.Data.ConnectionState.Closed)
        //    {
        //        myConnection.Close();
        //    }
        //}
    }
}
