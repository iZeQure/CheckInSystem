using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckInSystem.Data;
using CheckInSystem.Objects;
using CheckInSystem.Objects.Helpers;
using CheckInSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckInSystem.Controllers
{
    [Route("[controller]/[action]")]
    public class RoleController : ControllerBase
    {
        [HttpPost]
        [ActionName("create")]
        public ActionResult<Role> CreateRole(Role role)
        {
            IRoleRepository roleRepository = new RoleRepository();
            {
                if (role != null)
                {
                    roleRepository.Add(role);
                    return Ok($"Created Role : {role.Name}");
                }
                else return NoContent();
            }
        }

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
                    return Ok($"Updated Role Description for {role.Name} to {role.Description}");
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

        [HttpDelete]
        [ActionName("delete")]
        public ActionResult<Role> DeleteRole(Role role)
        {
            IRoleRepository roleRepository = new RoleRepository();
            {
                if (role.Name != null)
                {
                    roleRepository.Delete(role);
                    return Ok($"Deleted Role : {role.Name}");
                }
                else return NoContent();
            }
        }
    }
}