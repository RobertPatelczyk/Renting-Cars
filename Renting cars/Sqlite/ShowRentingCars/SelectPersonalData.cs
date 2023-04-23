using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.ShowRentingCars
{
    class SelectPersonalData
    {
        Write write = new Write();
        CreateFile createFile = new CreateFile();
        public void ShowPersonalData()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                string sql = "SELECT * FROM PersonalData";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    using (SQLiteDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                write.WriteData($"login: {reader["login"]}, password: {reader["password"]}");
                            }
                        }
                        else if (!reader.HasRows)
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
