using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Objects.Helpers
{
    public class RoleHelper : Role
    {
        #region Attributes
        private string newRoleName;
        private string newRoleDescription;
        #endregion

        #region Properties
        public string NewRoleName { get { return newRoleName; } set { newRoleName = value; } }
        public string NewRoleDescription { get { return newRoleDescription; } set { newRoleDescription = value; } }
        #endregion
    }
}
