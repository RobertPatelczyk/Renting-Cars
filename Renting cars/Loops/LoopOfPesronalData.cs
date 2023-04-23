using Renting_cars.Logging;
using Renting_cars.Sqlite.Create_Tables;
using Renting_cars.Sqlite.InsertData;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Loops
{
    class LoopOfPesronalData
    {
        int firstChoice;
        Write write = new Write();
        public void Login()
        {
                Show();
                try
                {
                    firstChoice = int.Parse(Console.ReadLine());
                    SetChoice(firstChoice);
                }
                catch(Exception ex)
                {
                    write.WriteData(ex.Message);
                    Login();
                }
        }
        public void SetChoice(int _choice)
        {
            firstChoice = _choice;
        }
        public int GetChoice()
        {
            return firstChoice;
        }
        public void Show() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            write.WriteData("0. End program");
            write.WriteData("1. Registration");
            write.WriteData("2. Login");
            Console.ResetColor();
        }
    }
}
