using Renting_cars.Sqlite;
using Renting_cars.Sqlite.ShowRentingCars;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Renting
{
    class RentingCars
    {
        Write write = new Write();
        CreateFile createFile = new CreateFile();
        public void Renting(int someChoice)
        {
            string sql = $"UPDATE RentingCars SET Car_available = 'no' WHERE Id_number = {someChoice}";
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
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
