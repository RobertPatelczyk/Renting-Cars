using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.Create_Tables
{
    class CreateTableOfTime
    {
      CreateFile createFile = new CreateFile();
        Write write = new Write(); 
        public void CreateTableDataTime()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                string sql = "CREATE TABLE IF NOT EXISTS RentingDataTime(id INTEGER PRIMARY KEY AUTOINCREMENT, data datetime default current_timestamp)";
                myConnection.Open();
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
