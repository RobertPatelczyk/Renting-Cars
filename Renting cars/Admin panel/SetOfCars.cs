using Renting_cars.Sqlite;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Admin_panel
{
    class SetOfCars
    {
        CreateFile createFile = new CreateFile();
        Write write = new Write();
        public void CollectionOfCars()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                string sql =
     "INSERT OR REPLACE INTO RentingCars " +
     "(Id_number, Car_cost, Car_busines, Carmodel, Number_vin, Car_available) VALUES (1, 100, 'Audi', 'A3', 'ABCDEFGHJ', 'yes'), " +
     "(2, 70, 'Fiat', 'Punto', 'QWERTYUIOP', 'yes'), (3, 50, 'Opel', 'Corsa', 'ASDFGHJKLP', 'yes'), (4, 250, 'Audi', 'A5', 'ZXCVBNMLKJ', 'yes')";
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    write.WriteData("Your cars has been updated");
                    Console.ResetColor();
                }
            }
        }
    }
}
