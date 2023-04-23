using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.Drop_Tables
{
    class DropTableOfRentingCars
    {
        Write write = new Write();
        CreateFile createFile = new CreateFile();
        public void Drop()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                string sql = "DROP TABLE IF EXISTS RentingCars";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    myCommand.ExecuteNonQuery();
                    using (SQLiteDataReader reader = myCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            write.WriteData("Your table has been dropped.");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }
    }
}
