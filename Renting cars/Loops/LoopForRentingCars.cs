using Renting_cars.Logging;
using Renting_cars.Loops;
using Renting_cars.Renting;
using Renting_cars.Sqlite;
using Renting_cars.Sqlite.Delete_Tables;
using Renting_cars.Sqlite.Drop_Tables;
using Renting_cars.Sqlite.InsertData;
using Renting_cars.Sqlite.ShowRentingCars;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;

namespace Renting_cars.Sqlite
{
    class LoopForRentingCars
    {
        Write write = new Write();
        int choice;
        public void RentingCar()
        {
            do
            {
                ShowListOfChoices();
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    SetChoice(choice);
                }
                catch (Exception ex)
                {
                    write.WriteData($"{ex.Message}");
                    RentingCar();
                }
                if (GetChoice() < 0 || GetChoice() > 2)
                {
                    write.WriteData("Write Correct number!");
                    RentingCar();
                }
                else if (GetChoice() >= 0 || GetChoice() <= 2)
                {
                    //correct number
                    //pushing to next stage
                }
                else
                {
                    RentingCar();
                }
            } while (GetChoice() != 0 && GetChoice() != 1 && GetChoice() != 2);
        }
        public void ShowListOfChoices()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var item in CreateDictionaryList())
            {
                write.WriteData($"{item.Key} - {item.Value}");
            }
            Console.ResetColor();
        }
        public Dictionary<int, string> CreateDictionaryList()
        {
            Dictionary<int, string> ListOfChoices = new Dictionary<int, string>();
            ListOfChoices.Add(0, "Back to login menu");
            ListOfChoices.Add(1, "Show aviable cars");
            ListOfChoices.Add(2, "Select car");
            return ListOfChoices;
        }
        public void SetChoice(int _choice)
        {
            choice = _choice;
        }
        public int GetChoice()
        {
            return choice;
        }
    }
}
