using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.Drop_Tables
{
    class DropTableOfPersonalData
    {
        CreateFile createFile = new CreateFile();
        Write write = new Write();
        public void DropPersonalData()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                string sql = "DROP TABLE IF EXISTS PersonalData";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
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