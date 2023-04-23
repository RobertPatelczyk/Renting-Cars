using Renting_cars.Sqlite;
using Renting_cars.Sqlite.InsertData;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Renting
{
    class IsCarAvailable
    {
        CostOfRenting costOfRenting = new CostOfRenting();
        CreateFile createFile = new CreateFile();
        InsertTableDataTime insertTableDataTime = new InsertTableDataTime();
        LoopForRentingCars loopForRentingCars = new LoopForRentingCars();
        Write write = new Write();
        Read read = new Read();

        int choice;
        bool carIsAvailable = false;
        bool timeRentingCar = false;
        public void CheckCar()
        {
            write.WriteData("Select by Id number!");
            try
            {
                choice = int.Parse(read.ReadData());
            }
            catch (Exception ex)
            {
                write.WriteData($"{ex.Message}");
                CheckCar();
            }
            SetChoice(choice);
            string sql = $"SELECT Car_available, CASE WHEN Car_available = 'no' THEN 'Car is not available!' " +
                $"WHEN Car_available = 'yes' THEN 'Have fun with your car!:)' ELSE 'XXXXXX' " +
                $"END FROM RentingCars WHERE id_number = {getChoice()}";

            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    using (SQLiteDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var isCarAvailable = reader["Car_available"];
                                if (isCarAvailable.ToString() == "no")
                                {
                                    write.WriteData("Sorry, but this car is not available to rent.");
                                    write.WriteData("But you can take another car!");
                                }
                                else if (isCarAvailable.ToString() == "yes")
                                {
                                    SetTimeRentingCar();
                                    SetCarIsAvailable();
                                }
                            }
                        }
                        else if (!reader.HasRows)
                        {
                            write.WriteData("Sorry, but You've to choose car from list!");
                            CheckCar();
                        }
                    }
                }
            }
        }
        public bool GetTimeRentingCar()
        {
            return timeRentingCar;
        }
        public void SetTimeRentingCar()
        {
            timeRentingCar = true;
        }
        public bool GetcarIsAvailable()
        {
            return carIsAvailable;
        }
        public void SetCarIsAvailable()
        {
            carIsAvailable = true;
        }
        public void RentedCar(string car)
        {
            write.WriteData($"Have fun with your {car}");
        }
        public void SetChoice(int _choice)
        {
            choice = _choice;
        }
        public int getChoice()
        {
            return choice;
        }
    }
}