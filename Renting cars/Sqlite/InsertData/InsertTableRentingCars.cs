using Renting_cars.Admin_panel;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.InsertData
{
    class InsertTableRentingCars
    {
        CreateFile createFile = new CreateFile();
        Read read = new Read();
        Write write = new Write();
        ContainerOfData containerOfData = new ContainerOfData();
        public void Insert()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                try
                {
                    write.WriteData("Id_number ");
                    containerOfData.Id_Number = int.Parse(read.ReadData());
                    write.WriteData("Car_cost ");
                    containerOfData.Car_cost = int.Parse(read.ReadData());
                    write.WriteData("Number_vin ");
                    containerOfData.Number_vin = read.ReadData();
                    write.WriteData("Car_busines");
                    containerOfData.Car_busines = read.ReadData();
                    write.WriteData("Carmodel");
                    containerOfData.Carmodel = read.ReadData();
                }
                catch (Exception ex)
                {
                    write.WriteData(ex.Message);
                    Insert();
                }
                string sql =
     "INSERT OR REPLACE INTO RentingCars('Id_number', 'Car_cost', 'Car_busines', 'Carmodel', 'Number_vin') VALUES(@Id_number, @Car_cost, @Car_busines, @Carmodel, @Number_vin)";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@Id_Number", $"{containerOfData.Id_Number}");
                    myCommand.Parameters.AddWithValue("@Car_cost", $"{containerOfData.Car_cost}");
                    myCommand.Parameters.AddWithValue("@Number_vin", $"{containerOfData.Number_vin}");
                    myCommand.Parameters.AddWithValue("@Car_busines", $"{containerOfData.Car_busines}");
                    myCommand.Parameters.AddWithValue("@Carmodel", $"{containerOfData.Carmodel}");
                    try
                    {
                        myCommand.ExecuteNonQuery();
                        Console.ForegroundColor = ConsoleColor.Green;
                        write.WriteData("Row added");
                        Console.ResetColor();
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
