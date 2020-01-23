using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Objects
{
    public class BaseEntity
    {
        #region Attributes        
        private string userName;
        #endregion

        #region Properties        
        public string UserName { get { return userName; } set { userName = value; } }
        #endregion
    }
}
