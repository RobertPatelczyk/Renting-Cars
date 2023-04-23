using Renting_cars.Sqlite.Create_Tables;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.Delete_Tables
{
    class DeletePersonalData
    {
        Write write = new Write();
        CreateFile createFile = new CreateFile();
        Read read = new Read();
        ContainersOfPersonalData containersOfPersonalData = new ContainersOfPersonalData();
        public void DeletePersonal()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();

                write.WriteData("Insert login by which you want to delete user.");
                try
                {
                    containersOfPersonalData.login = read.ReadData();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    write.WriteData($"{ex.Message}");
                    Console.ResetColor();
                    DeletePersonal();
                }
                string sql = $"DELETE FROM RentingCars WHERE login LIKE '%{containersOfPersonalData.login}%'";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    try
                    {
                        myCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        write.WriteData($"{ex.Message}");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    write.WriteData("Your type has been deleted.");
                    Console.ResetColor();
                }
            }
        }
    }
}
