using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckInSystem.Data;
using CheckInSystem.Objects;
using CheckInSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckInSystem.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        [HttpPut]
        [ActionName("update")]
        public ActionResult<User> UpdateUser(User user)
        {
            IRepository<User> repository = new UserRepository();

            repository.Update(user);

            return Ok();
        }

        [HttpGet]
        [ActionName("all")]
        public ActionResult<List<User>> GetAllUsers()
        {
            IRepository<User> repository = new UserRepository();

            return repository.GetAll();
        }

        [HttpGet]
        [ActionName("id")]
        public ActionResult<User> GetUserDetailsById(string userId)
        {
            IRepository<User> repository = new UserRepository();

            return repository.GetById(userId);
        }
    }
}