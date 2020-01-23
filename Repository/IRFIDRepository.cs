using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Repository
{
    interface IRFIDRepository
    {
        bool CreateDateTimeOnRFIDCardScanned(string rfidCard);
    }
}
