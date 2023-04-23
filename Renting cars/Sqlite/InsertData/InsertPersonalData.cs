using Renting_cars.Logging;
using Renting_cars.Sqlite.Create_Tables;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Sqlite.InsertData
{
    class InsertPersonalData
    {
        CreateFile createFile = new CreateFile();
        Read read = new Read();
        Write write = new Write();
        ContainersOfPersonalData containersOfPersonalData = new ContainersOfPersonalData();
        public void InsertData()
        {
            Register register = new Register();
            try
            {
                using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
                {
                    myConnection.Open();
                    write.WriteData("Insert login: ");
                    containersOfPersonalData.login = read.ReadData();
                    if (containersOfPersonalData.login.Length < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        write.WriteData("Your login has to be longer than 3 chars.");
                        Console.ResetColor();
                        InsertData();
                    }

                    register.RepeatYourPassword();
                    setPassword(register.getData());

                    string sql = "INSERT INTO PersonalData('login', 'password') VALUES(@login, @password)";
                    using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@login", $"{containersOfPersonalData.login}");
                        myCommand.Parameters.AddWithValue("@password", $"{getPassword()}");
                        myCommand.ExecuteNonQuery();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    write.WriteData("Your account has been created. Now You can login to our service.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        string password;
        public string getPassword()
        {
            return password;
        }
        public void setPassword(string _password)
        {
            password = _password;
        }
    }
}
