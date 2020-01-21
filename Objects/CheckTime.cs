using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Objects
{
    public class CheckTime
    {
        #region Attributes
        private DateTime cardReadTime;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the card read time.
        /// </summary>
        /// <value>
        /// The card read time.
        /// </value>
        public DateTime CardReadTime { get { return cardReadTime; } set { cardReadTime = value; } }
        #endregion
    }
}
