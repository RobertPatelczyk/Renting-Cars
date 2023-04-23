using Renting_cars.WriteAndRead;
using System;
using System.Data.SQLite;

namespace Renting_cars.Sqlite.ShowRentingCars
{
    class SelectFromRentingCars
    {
        Write write = new Write();
        CreateFile createFile = new CreateFile();
        public void SelectData()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                string sql = "Select * From RentingCars WHERE Car_available = 'yes'";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    try
                    {
                        using (SQLiteDataReader reader = myCommand.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                write.WriteData("Sorry, but we have not anything to show you.");
                                Console.ResetColor();
                            }
                            else if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    write.WriteData($"Id_number: " +
 $"{reader["Id_number"]}, Car_cost {reader["Car_cost"]}, Car_busines {reader["Car_busines"]}, Carmodel {reader["Carmodel"]}, Number_vin {reader["Number_vin"]}, Car_available {reader["Car_available"]}");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        write.WriteData(ex.Message);
                    }
                }
            }
        }
    }
}
