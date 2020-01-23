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
    public class UserController : ControllerBase
    {
        #region POST Methods
        [HttpPost]
        [ActionName("create")]
        public ActionResult<User> CreateUser(User user)
        {
            IRepository<User> repository = new UserRepository();
            {
                return Ok(repository.Add(user));
            }
        }
        #endregion

        #region GET Methods
        [HttpGet]
        [ActionName("all")]
        public ActionResult<List<User>> GetAllUsers()
        {
            IRepository<User> repository = new UserRepository();
            {
                List<User> getAllResult = repository.GetAll();

                if (getAllResult.Count() == 0) return NotFound();
                else return getAllResult;
            }
        }

        [HttpGet]
        [ActionName("id")]
        public ActionResult<User> GetUserDetailsById(string userId)
        {
            IRepository<User> repository = new UserRepository();
            {
                User userByIdResult = repository.GetById(userId);

                if (userByIdResult.Id == null) return NotFound();
                else return Ok(userByIdResult);
            }


        }
        #endregion

        #region PUT Methods
        [HttpPut]
        [ActionName("update")]
        public ActionResult<User> UpdateUser(User user)
        {
            IRepository<User> repository = new UserRepository();

            repository.Update(user);

            return Ok();
        }

        [HttpPut]
        [ActionName("disable")]
        public ActionResult<User> DisableUser(string id)
        {
            IUserRepository repository = new UserRepository();

            repository.DisableUser(id);

            return Ok();
        }

        [HttpPut]
        [ActionName("activate")]
        public ActionResult<User> ActivateUser(string id)
        {
            IUserRepository repository = new UserRepository();
            {
                repository.ActivateUser(id);
                return Ok();
            }
        }

        [HttpPut]
        [ActionName("password/change")]
        public ActionResult<UserHelper> ChangeUserPassword(UserHelper user)
        {
            IUserRepository repository = new UserRepository();
            {
                return Ok(repository.ChangeUserPassword(user));
            }
        }
        #endregion
    }
}