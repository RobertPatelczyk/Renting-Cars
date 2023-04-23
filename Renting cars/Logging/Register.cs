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
    class Register
    {
        string password2;
        
        CreateFile createFile = new CreateFile();
        Read read = new Read();
        Write write = new Write();
        ContainersOfPersonalData containersOfPersonalData = new ContainersOfPersonalData();
        public void RepeatYourPassword()
        {
            write.WriteData("Write password: ");
             containersOfPersonalData.password = read.ReadData();
            if(containersOfPersonalData.password.Length<3)
            {
                InsertPersonalData insertPersonalData = new InsertPersonalData();
                Console.ForegroundColor = ConsoleColor.Red;
                write.WriteData("Your password has to be longer than 3 chars.");
                Console.ResetColor();
                insertPersonalData.InsertData();
            }
            write.WriteData("Repeat password: ");
            password2 = read.ReadData();
            if (containersOfPersonalData.password == password2)
            {
                setData(password2);
            }

            else if (containersOfPersonalData.password != password2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                write.WriteData("Wrong data. Try again.");
                Console.ResetColor();
                RepeatYourPassword();
            }
        }
        public void setData(string password)
        {
            password2 = password;
        }
        public string getData()
        {
            return password2;
        }
    }
}
