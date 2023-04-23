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
    class ShowWhoGotWhatAndForHowLong
    {
        Write write = new Write();
        CreateFile createFile = new CreateFile();
        public void ShowAllData()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                string sql = "SELECT * FROM RelationGroup";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    using (SQLiteDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                 write.WriteData($"id: {reader["id"]}, Id of car: {reader["Id_number_Of_Car"]}, Return data: {reader["return_data"] }, Who: {reader["login"]}");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            write.WriteData("Sorry, but we have not anything to show you.");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }
    }
}
