using Renting_cars.Loops;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;

namespace Renting_cars.Admin_panel
{
    class SelectTable
    {
        Write write = new Write();
        Read read = new Read();
        public void TableMenu()
        {
            ShowTables();
            int choice = int.Parse(read.ReadData());
            switch (choice)
            {
                case 0:
                    LoopOfPesronalData loopOfPesronalData = new LoopOfPesronalData();
                    loopOfPesronalData.Login();
                    break;
                case 1:
                    ManagePersonalDataFromAdminPanel managePersonalDataFromAdminPanel = new ManagePersonalDataFromAdminPanel();
                    managePersonalDataFromAdminPanel.PersonalDataAdminMenu();
                    break;
                case 2:
                    OptionsForAdmin optionsForAdmin = new OptionsForAdmin();
                    optionsForAdmin.LoopForAdminOptions();
                    break;
            }
        }
        public Dictionary<int, string> CreateTables()
        {
            Dictionary<int, string> AdminChoice = new Dictionary<int, string>();
            AdminChoice.Add(0, "Back to login menu");
            AdminChoice.Add(1, "Personal client data");
            AdminChoice.Add(2, "Renting cars");
            return AdminChoice;
        }
        public void ShowTables()
        {
            foreach (var item in CreateTables())
            {
                write.WriteData($"{item.Key} - {item.Value}");
            }
        }
    }
}
