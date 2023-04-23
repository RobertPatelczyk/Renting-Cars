using Renting_cars.Admin_panel;
using Renting_cars.Sqlite;
using Renting_cars.Sqlite.Create_Tables;
using Renting_cars.Sqlite.InsertData;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Logging
{
    class LoginIntoService
    {
        CreateFile createFile = new CreateFile();
        ContainersOfPersonalData containersOfPersonalData = new ContainersOfPersonalData();
        Write write = new Write();
        Read read = new Read();
            int AdminPanelOnInt = 0;
            int UserPanelOnInt = 0;
        
        public void Login()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                write.WriteData("login: ");
                containersOfPersonalData.login = read.ReadData();
                SetLogin(containersOfPersonalData.login);
                write.WriteData("password: ");
                containersOfPersonalData.password = read.ReadData();
                string sql = $"SELECT login, password FROM PersonalData WHERE login = '{GetLogin()}' AND password ='{containersOfPersonalData.password}'";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    try
                    {
                        myCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        write.WriteData($"{ex.Message}");
                        CreateDatabaseOfData createDatabaseOfData = new CreateDatabaseOfData();
                        createDatabaseOfData.CreateData();
                        write.WriteData("Please register your data first.");
                    }
                    using (SQLiteDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Correct Data. Welcome in our service.");
                            Console.ResetColor();

                            if (GetLogin() == "admin" && containersOfPersonalData.password == "admin")
                            {
                                setIntAdmin(1);
                            }
                            else
                            {
                                setIntUser(1);
                            }
                        }
                        else if (!reader.HasRows)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            write.WriteData("Wrong data. Try again.");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }
        public void setIntUser(int _UserPanelOnInt)
        {
            UserPanelOnInt = _UserPanelOnInt;
        }
        public int getIntUser()
        {
            return UserPanelOnInt;
        }
        public void setIntAdmin(int _AdminPanelOnInt)
        {
            AdminPanelOnInt = _AdminPanelOnInt;
        }
        public int getIntAdmin()
        {
            return AdminPanelOnInt;
        }
        public void SetLogin(string _login)
        {
            containersOfPersonalData.login = _login;
        }
        public string GetLogin()
        {
            return containersOfPersonalData.login;
        }
    }
}
