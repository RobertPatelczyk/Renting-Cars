using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.Delete_Tables
{
    class DeleteTables
    {
        CreateFile createFile = new CreateFile();
        ContainerOfData containerOfData = new ContainerOfData();
        Write write = new Write();
        Read read = new Read();
        public void Delete()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                write.WriteData("Insert id number by which you want to delete.");
                try
                {
                    containerOfData.Id_Number = int.Parse(read.ReadData());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    write.WriteData($"{ex.Message}");
                    Console.ResetColor();
                    Delete();
                }
                string sql = $"DELETE FROM RentingCars WHERE Id_number = {containerOfData.Id_Number}";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    try
                    {
                        myCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        write.WriteData(ex.Message);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    write.WriteData("Your type has been deleted.");
                    Console.ResetColor();
                }
            }
        }
    }
}
