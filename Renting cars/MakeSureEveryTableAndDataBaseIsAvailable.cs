using Renting_cars.Renting;
using Renting_cars.Sqlite;
using Renting_cars.Sqlite.Create_Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars
{
    class MakeSureEveryTableAndDataBaseIsAvailable
    {
        CreateFile createFile = new CreateFile();
        CreateDatabaseOfData createDatabaseOfData = new CreateDatabaseOfData();
        CreateTableRentingCars createTableRentingCars = new CreateTableRentingCars();
        CreateTableOfTime createTableOfTime = new CreateTableOfTime();
        RentingTableRelation rentingTableRelation = new RentingTableRelation();
        public void CreateEveryNecessaryThing()
        {
            createDatabaseOfData.CreateData();
            createTableRentingCars.Create();
            createTableOfTime.CreateTableDataTime();
            rentingTableRelation.CreateTableOfRelation();
        }
    }
}
