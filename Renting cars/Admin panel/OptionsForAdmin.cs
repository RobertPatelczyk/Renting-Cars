using Renting_cars.Sqlite;
using Renting_cars.Sqlite.Delete_Tables;
using Renting_cars.Sqlite.Drop_Tables;
using Renting_cars.Sqlite.InsertData;
using Renting_cars.Sqlite.ShowRentingCars;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;

namespace Renting_cars.Admin_panel
{
    class OptionsForAdmin
    {
        Read read = new Read();
        Write write = new Write();
        int choice;
        public void LoopForAdminOptions()
        {
            do
            {
                ShowPossibleChoices();
                try
                {
                    choice = int.Parse(read.ReadData());
                }
                catch (Exception ex)
                {
                    write.WriteData(ex.Message);
                    LoopForAdminOptions();
                }
                switch (choice)
                {
                    case 0:
                        SelectTable selectTable = new SelectTable();
                        selectTable.TableMenu();
                        break;
                    case 1:
                        CreateTableRentingCars createTableRentingCars = new CreateTableRentingCars();
                        createTableRentingCars.Create();
                        break;
                    case 2:
                        InsertTableRentingCars insertTableRentingCars = new InsertTableRentingCars();
                        insertTableRentingCars.Insert();
                        break;
                    case 3:
                        SelectFromRentingCars selectFromRentingCars = new SelectFromRentingCars();
                        selectFromRentingCars.SelectData();
                        break;
                    case 4:
                        DropTableOfRentingCars DropTableOfRentingCars = new DropTableOfRentingCars();
                        DropTableOfRentingCars.Drop();
                        break;
                    case 5:
                        DeleteTables deleteTables = new DeleteTables();
                        deleteTables.Delete();
                        break;
                    case 6:
                        SetOfCars setOfCars = new SetOfCars();
                        setOfCars.CollectionOfCars();
                        break;
                    case 7:
                        ShowWhoGotWhatAndForHowLong show = new ShowWhoGotWhatAndForHowLong();
                        show.ShowAllData();
                        break;

                }
            } while (choice != 0);
        }
        public Dictionary<int, string> CreatePossibleChoices()
        {
            Dictionary<int, string> ListOfChoices = new Dictionary<int, string>();
            ListOfChoices.Add(0, "Back to login menu");
            ListOfChoices.Add(1, "Create table of renting cars");
            ListOfChoices.Add(2, "Insert personal car into data");
            ListOfChoices.Add(3, "Show aviable cars");
            ListOfChoices.Add(4, "Drop table");
            ListOfChoices.Add(5, "Delete data by Id number");
            ListOfChoices.Add(6, "Add set of cars");
            ListOfChoices.Add(7, "Show which car is rented, and by who");
            return ListOfChoices;
        }
        public void ShowPossibleChoices()
        {
            foreach (var item in CreatePossibleChoices())
            {
                write.WriteData($"{item.Key} - {item.Value}");
            }
        }
    }
}
