using Renting_cars.Admin_panel;
using Renting_cars.Logging;
using Renting_cars.Loops;
using Renting_cars.Renting;
using Renting_cars.Sqlite;
using Renting_cars.Sqlite.InsertData;
using Renting_cars.Sqlite.ShowRentingCars;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars
{
    class JoinMostImportantClasses
    {
        LoopForRentingCars loopForRentingCars = new LoopForRentingCars();
        RentingCars rentingCars = new RentingCars();
        SelectFromRentingCars selectFromRentingCars = new SelectFromRentingCars();
        CostOfRenting costOfRenting = new CostOfRenting();
        InsertTableDataTime insertTableDataTime = new InsertTableDataTime();
        IsCarAvailable isCarAvailable = new IsCarAvailable();
        LoginIntoService loginIntoService = new LoginIntoService();
        LoopOfPesronalData startProgram = new LoopOfPesronalData();
        Write write = new Write();
        MakeSureEveryTableAndDataBaseIsAvailable makeSureEveryTableAndDataBaseIsAvailable = new MakeSureEveryTableAndDataBaseIsAvailable();
        string myLogin;
        public void StartProgram()
        {
            makeSureEveryTableAndDataBaseIsAvailable.CreateEveryNecessaryThing();
            do
            {
                startProgram.Login();
                switch (startProgram.GetChoice())
                {
                    case 0:
                        write.WriteData("Your program has ended.");
                        break;
                    case 1:
                        InsertPersonalData insertPersonalData = new InsertPersonalData();
                        insertPersonalData.InsertData();
                        break;
                    case 2:
                        LogIntoSeriveMethod();
                        break;
                }
            } while (startProgram.GetChoice() != 0);

        }
        public void LogIntoSeriveMethod()
        {
            loginIntoService.Login();
            if (loginIntoService.getIntAdmin() == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                write.WriteData("Welcome in admin panel");
                Console.ResetColor();
                SelectTable selectTable = new SelectTable();
                selectTable.TableMenu();
            }
            else if (loginIntoService.getIntUser() == 1)
            {
                loginIntoService.GetLogin();
                SecondLoopRenting();
            }
        }
        string loginData;
        public void SecondLoopRenting()
        {
            loopForRentingCars.RentingCar();
            LoopRentingMethod();
        }
        public void LoopRentingMethod()
        {
                switch (loopForRentingCars.GetChoice())
                {
                    case 0:
                    StartProgram();
                        break;
                    case 1:
                        selectFromRentingCars.SelectData();
                    SecondLoopRenting();
                    break;
                    case 2:
                        selectFromRentingCars.SelectData();
                    CheckAvailableCar();
                        break;
            }
        }
        public void CheckAvailableCar()
        {
            string test = myLogin;
            isCarAvailable.CheckCar();
            if (isCarAvailable.GetTimeRentingCar() == true)
            {
                InsertTableDataTimeMethod();
            }
            if (isCarAvailable.GetcarIsAvailable() == true)
            {
                RentingCarsMethod();
            }

            if (isCarAvailable.GetcarIsAvailable() == true && isCarAvailable.GetTimeRentingCar() == true)
            {
                if (isCarAvailable.getChoice() == 1)
                {
                    costOfRenting.HowMuchClientDoesHaveToPay(100, insertTableDataTime.GetDays());
                    isCarAvailable.RentedCar("Audi A3");
                }
                else if (isCarAvailable.getChoice() == 2)
                {
                    costOfRenting.HowMuchClientDoesHaveToPay(70, insertTableDataTime.GetDays());
                    isCarAvailable.RentedCar("Fiat punto");
                }
                else if (isCarAvailable.getChoice() == 3)
                {
                    costOfRenting.HowMuchClientDoesHaveToPay(50, insertTableDataTime.GetDays());
                    isCarAvailable.RentedCar("Opel Corsa");
                }
                else if (isCarAvailable.getChoice() == 4)
                {
                    costOfRenting.HowMuchClientDoesHaveToPay(250, insertTableDataTime.GetDays());
                    isCarAvailable.RentedCar("Audi A5");
                }
                InsertRelation();
                SecondLoopRenting();
            }
        }

        public void RentingCarsMethod()
        {
            rentingCars.Renting(isCarAvailable.getChoice());
        }

        public void InsertTableDataTimeMethod()
        {
            insertTableDataTime.InsertDataTime();
        }

        public void InsertRelation()
        {
            CreateFile createFile = new CreateFile();
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                string sql = $"INSERT INTO RelationGroup('Id_number_Of_Car', 'return_data', 'login') VALUES(@Id_number_Of_Car, @return_data, @login)";
                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@Id_number_Of_Car", $"{isCarAvailable.getChoice()}");
                    myCommand.Parameters.AddWithValue("@return_data", $"{insertTableDataTime.GetTimeOfRenting()}");
                    myCommand.Parameters.AddWithValue("@login", $"{loginIntoService.GetLogin()}");
                    myCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
