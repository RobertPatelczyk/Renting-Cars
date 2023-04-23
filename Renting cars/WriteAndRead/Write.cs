using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.WriteAndRead
{
    class Write : IWrite
    {
        public void WriteData(string data)
        {
            Console.WriteLine(data);
        }
    }
}
