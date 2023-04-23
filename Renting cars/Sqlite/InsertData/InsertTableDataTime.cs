using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.InsertData
{
    class InsertTableDataTime
    {
        CreateFile createFile = new CreateFile();
        Write write = new Write();
        Read read = new Read();
       public int day, id;
        DateTime varriable;
        public void InsertDataTime()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();

                DateTime dateTime = DateTime.Now;
                write.WriteData("In our company, we're giving extra 1 hour with car!");
                write.WriteData($"current time: {dateTime}");
                write.WriteData("So, for how many days do you want to rent our car?");
                try
                {
                    day = int.Parse(read.ReadData());
                    SetDays(day);
                }
                catch (Exception ex)
                {
                    write.WriteData($"{ex.Message}");
                    InsertDataTime();
                }
                var TimeOfRenting = dateTime.Add(new TimeSpan(GetDays(), 1, 0, 0));

                SetTimeOfRenting(TimeOfRenting);

                write.WriteData($"return time: {GetTimeOfRenting()}");
                string sql = "INSERT INTO RentingDataTime('data') VALUES(@data)";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@data", $"{GetTimeOfRenting()}");
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
        public DateTime GetTimeOfRenting()
        {
            return varriable;
        }
        public void SetTimeOfRenting(DateTime _varriable)
        {
            varriable = _varriable;
        }
        public int GetDays()
        {
            return day;
        }
        public void SetDays(int _day)
        {
            day = _day;
        }
    }
}
