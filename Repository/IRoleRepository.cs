using CheckInSystem.Objects;
using CheckInSystem.Objects.Helpers;
using System.Collections.Generic;

namespace CheckInSystem.Repository
{
    interface IRoleRepository
    {
        void Add(Role role);
        void Delete(Role role);
        List<Role> GetRoles();
        Role GetRoleBydId(string roleName);
        void Update(RoleHelper role);
        void UpdateRoleDescription(Role role);
        void UpdateRoleName(RoleHelper role);
    }
}
