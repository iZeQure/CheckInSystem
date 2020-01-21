using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Objects
{
    public class Role
    {
        #region Attributes
        private string name;
        private string description;
        private string userName;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get { return name; } set { name = value; } }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get { return description; } set { description = value; } }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get { return userName; } set { userName = value; } }
        #endregion
    }
}
