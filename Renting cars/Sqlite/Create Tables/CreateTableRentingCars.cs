using Renting_cars.Renting;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite
{
    class CreateTableRentingCars
    {
        Write write = new Write();
        public void Create()
        {
            CreateFile createFile = new CreateFile();
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                string sql = "Create table if not exists RentingCars (Id_number AUTO_INCREMENT INT primary key not null, " +
     "Car_cost int, Car_busines varchar(30), Carmodel varchar(30), Number_vin varchar(10), Car_available varchar(3))";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    try
                    {
                        myCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        write.WriteData($"{ex.Message}");
                    }
                }
            }
        }
    }
}