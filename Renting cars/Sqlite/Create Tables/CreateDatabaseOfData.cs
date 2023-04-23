using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.Create_Tables
{
    class CreateDatabaseOfData
    {
        Write write = new Write();
        public void CreateData()
        {
            CreateFile createFile = new CreateFile();
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();

                string sql = "Create table if not exists PersonalData(login varchar(15) not null primary key unique, password varchar(15) not null, " +
                    "FOREIGN KEY (login) REFERENCES RentingCars (Id_number), " +
                    "FOREIGN KEY (login) REFERENCES RentingDataTime (data))";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    try
                    {
                    myCommand.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        write.WriteData($"{ex.Message}");
                    }
                }
            }
        }
    }
}
