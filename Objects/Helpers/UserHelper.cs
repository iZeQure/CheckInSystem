namespace CheckInSystem.Objects.Helpers
{
    public class UserHelper : User
    {
        #region Atttributes
        private string newPassword;
        #endregion

        #region Properties
        public string NewPassword { get { return newPassword; } set { newPassword = value; } }
        #endregion
    }
}
