using Renting_cars.Sqlite.Create_Tables;
using Renting_cars.Sqlite.Delete_Tables;
using Renting_cars.Sqlite.Drop_Tables;
using Renting_cars.Sqlite.InsertData;
using Renting_cars.Sqlite.ShowRentingCars;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Admin_panel
{
    class ManagePersonalDataFromAdminPanel
    {
        Write write = new Write();
        Read read = new Read();
        int choice;
        public int PersonalDataAdminMenu()
        {
            do
            {
            ShowPossibleChoices();
             choice = int.Parse(read.ReadData());
                switch (choice)
                {
                    case 0:
                        SelectTable selectTable = new SelectTable();
                        selectTable.TableMenu();
                        break;
                    case 1:
                        CreateDatabaseOfData createDatabaseOfData = new CreateDatabaseOfData();
                        createDatabaseOfData.CreateData();
                        break;
                    case 2:
                        InsertPersonalData insertPersonalData = new InsertPersonalData();
                        insertPersonalData.InsertData();
                        break;
                    case 3:
                        SelectPersonalData selectPersonalData = new SelectPersonalData();
                        selectPersonalData.ShowPersonalData();
                        break;
                    case 4:
                        DropTableOfPersonalData dropTableOfPersonalData = new DropTableOfPersonalData();
                        dropTableOfPersonalData.DropPersonalData();
                        break;
                    case 5:
                        DeletePersonalData deletePersonalData = new DeletePersonalData();
                        deletePersonalData.DeletePersonal();
                        break;
                }
            } while (choice!=0);
            return choice;
        }
        public Dictionary<int, string> CreatePossibleChoices()
        {
            Dictionary<int, string> MenuForPersonalTable = new Dictionary<int, string>();
            MenuForPersonalTable.Add(0,"Back to menu");
            MenuForPersonalTable.Add(1,"Create table PersonalData");
            MenuForPersonalTable.Add(2,"Insert user to system");
            MenuForPersonalTable.Add(3,"Show all data in PersonalData");
            MenuForPersonalTable.Add(4,"Drop table");
            MenuForPersonalTable.Add(5,"Delete user");
            return MenuForPersonalTable;
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
