using CheckInSystem.Objects;
using CheckInSystem.Objects.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        void DisableUser(string id);
        void ActivateUser(string id);
        bool ChangeUserPassword(UserHelper user);
        bool ChangeUserRFID(User user);
        bool ChangeUserRole(User user);
    }
}
