using CheckInSystem.Data;
using CheckInSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CheckInSystem.Controllers
{
    [Route("[controller]/[action]")]
    public class RFIDController : ControllerBase
    {
        #region POST Methods
        [HttpPost]
        [ActionName("scan")]
        public ActionResult<string> ScanRFIDCard(string rfid)
        {
            IRFIDRepository rFIDRepository = new RFIDRepository();
            {
                return Ok(rFIDRepository.CreateDateTimeOnRFIDCardScanned(rfid));
            }
        } 
        #endregion
    }
}