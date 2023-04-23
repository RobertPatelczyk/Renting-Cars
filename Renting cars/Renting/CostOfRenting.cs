using Renting_cars.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting_cars.Renting
{
    class CostOfRenting
    {
        int result;
        Write write = new Write();
        public void HowMuchClientDoesHaveToPay(int costPerDay, int NumberOfDays)
        {
            result = costPerDay * NumberOfDays;
            SetResult(result);
            if(NumberOfDays<3)
            {
                write.WriteData($"That will be {GetResult()}");
            }
           else if(NumberOfDays>=3 && NumberOfDays <6)
            {
                write.WriteData($"That will be {GetResult() * 0.9}");
            }
            else if(NumberOfDays>=6 && NumberOfDays<10)
            {
                write.WriteData($"That will be {GetResult() * 0.8}");
            }
            else if(NumberOfDays>=10)
            {
                write.WriteData($"That will be {GetResult() * 0.7}");
            }
        }
        public void SetResult(int _result)
        {
            result = _result;
        }
        public int GetResult()
        {
            return result;
        }
    }
}
