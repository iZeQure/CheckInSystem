using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Objects
{
    public class User : BaseEntity
    {
        #region Attributes
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string password;
        private string rfidCard;
        private bool isDisabled;

        private List<DateTime> checkTime;
        private Role role;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get { return firstName; } set { firstName = value; } }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get { return lastName; } set { lastName = value; } }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get { return password; } set { password = value; } }
        /// <summary>
        /// Gets or sets the rfid card.
        /// </summary>
        /// <value>
        /// The rfid card.
        /// </value>
        public string RFIDCard { get { return rfidCard; } set { rfidCard = value; } }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is disabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisabled { get { return isDisabled; } set { isDisabled = value; } }


        /// <summary>
        /// Gets or sets the check time.
        /// </summary>
        /// <value>
        /// The check time.
        /// </value>
        public List<DateTime> CheckTime { get { return checkTime; } set { checkTime = value; } }
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public Role Role { get { return role; } set { role = value; } }
        #endregion
    }
}
