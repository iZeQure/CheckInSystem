using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckInSystem.Data;
using CheckInSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckInSystem.Controllers
{
    [Route("[controller]/[action]")]
    public class RFIDController : ControllerBase
    {
        [HttpPost]
        [ActionName("scan")]
        public ActionResult<string> ScanRFIDCard(string rfid)
        {
            IRFIDRepository rFIDRepository = new RFIDRepository();
            {
                return Ok(rFIDRepository.CreateDateTimeOnRFIDCardScanned(rfid));
            }
        }
    }
}