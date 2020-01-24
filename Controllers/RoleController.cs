using System.Collections.Generic;
using CheckInSystem.Data;
using CheckInSystem.Objects;
using CheckInSystem.Objects.Helpers;
using CheckInSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CheckInSystem.Controllers
{
    [Route("[controller]/[action]")]
    public class RoleController : ControllerBase
    {
        #region POST Methods
        //POST: role/create
        [HttpPost]
        [ActionName("create")]
        public ActionResult<Role> CreateRole(Role role)
        {
            IRoleRepository roleRepository = new RoleRepository();
            {
                if (role != null)
                {
                    roleRepository.Add(role);
                    return Ok(role.Name);
                }
                else return NoContent();
            }
        }
        #endregion

        #region GET Methods
        [HttpGet]
        [ActionName("all")]
        public ActionResult<List<Role>> GetAllRoles()
        {
            IRoleRepository roleRepository = new RoleRepository();
            {
                if (roleRepository.GetRoles() != null) return roleRepository.GetRoles();
                else return NotFound();
            }
        }

        [HttpGet]
        [ActionName("id")]
        public ActionResult<Role> GetRoleById(string name)
        {
            IRoleRepository roleRepository = new RoleRepository();
            {
                if (roleRepository.GetRoleBydId(name) != null) return roleRepository.GetRoleBydId(name);
                else return NotFound();
            }
        }
        #endregion

        #region PUT Methods
        [HttpPut]
        [ActionName("update")]
        public ActionResult<RoleHelper> UpdateRole(RoleHelper role)
        {
            IRoleRepository roleRepository = new RoleRepository();
            {
                if (role != null)
                {
                    roleRepository.Update(role);
                    return Ok($"Updated Role : {role.Name} to {role.NewRoleName} | {role.Description} to {role.NewRoleDescription}");
                }
                else return NoContent();
            }
        }

        [HttpPut]
        [ActionName("update/description")]
        public ActionResult<Role> UpdateRoleDescription(Role role)
        {
            IRoleRepository roleRepository = new RoleRepository();
            {
                if (role != null)
                {
                    roleRepository.UpdateRoleDescription(role);
                    return Ok(role.Description);
                }
                else return NoContent();
            }
        }

        [HttpPut]
        [ActionName("update/name")]
        public ActionResult<RoleHelper> UpdateRoleName(RoleHelper role)
        {
            IRoleRepository roleRepository = new RoleRepository();
            {
                if (role != null)
                {
                    roleRepository.UpdateRoleName(role);
                    return Ok($"Updated Role Name for {role.Name} to {role.NewRoleName}");
                }
                else return NoContent();
            }
        }
        #endregion

        #region DELETE Methods
        [HttpDelete]
        [ActionName("delete")]
        public ActionResult<Role> DeleteRole(string roleId)
        {
            IRoleRepository roleRepository = new RoleRepository();
            {
                if (roleId != null)
                {
                    roleRepository.Delete(roleId);
                    return Ok(roleId);
                }
                else return NoContent();
            }
        } 
        #endregion
    }
}