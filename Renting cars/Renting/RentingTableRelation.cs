using Renting_cars.Logging;
using Renting_cars.Sqlite;
using Renting_cars.Sqlite.InsertData;
using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Renting
{
    class RentingTableRelation
    {
        CreateFile createFile = new CreateFile();
        public void CreateTableOfRelation()
        {
            using (SQLiteConnection myConnection = new SQLiteConnection(createFile.myConnection))
            {
                myConnection.Open();
                string sql = "CREATE TABLE if not exists 'RelationGroup' ( " +
                   " 'id' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                   " 'Id_number_Of_Car' INT, " +
                   " 'return_data'  string, " +
                   " 'login' VARCHAR(15), " +
                   "FOREIGN KEY('Id_number_Of_Car') REFERENCES RentingCars('Id_number'), " +
                   "FOREIGN KEY('return_data') REFERENCES RentingDataTime('id'), " +
                   "FOREIGN KEY('login') REFERENCES PersonalData('login'))"; 


                using (SQLiteCommand myCommand = new SQLiteCommand(sql, myConnection))
                {
                    myCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
