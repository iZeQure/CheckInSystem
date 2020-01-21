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
        /// <summary>
        /// Gets UserName
        /// </summary>
        /// <value>
        /// The value of the specified ID for the base.
        /// </value>
        public string UserName { get { return userName; } }
        #endregion
    }
}
