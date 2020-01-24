using System.Collections.Generic;
using System.Linq;
using CheckInSystem.Data;
using CheckInSystem.Objects;
using CheckInSystem.Objects.Helpers;
using CheckInSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CheckInSystem.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        #region POST Methods
        //POST: user/create
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
        //GET: user/all
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

        //GET: user/id?userId=
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
        //PUT: user/update
        [HttpPut]
        [ActionName("update")]
        public ActionResult<User> UpdateUser(User user)
        {
            IRepository<User> repository = new UserRepository();

            repository.Update(user);

            return Ok();
        }

        //PUT: user/disable?userId=
        [HttpPut]
        [ActionName("disable")]
        public ActionResult<User> DisableUser(string userId)
        {
            IUserRepository repository = new UserRepository();

            repository.DisableUser(userId);

            return Ok();
        }

        //PUT: user/activate?userId=
        [HttpPut]
        [ActionName("activate")]
        public ActionResult<User> ActivateUser(string userId)
        {
            IUserRepository repository = new UserRepository();
            {
                repository.ActivateUser(userId);
                return Ok();
            }
        }

        //PUT: user/change/password
        [HttpPut]
        [ActionName("change/password")]
        public ActionResult<UserHelper> ChangeUserPassword(UserHelper user)
        {
            IUserRepository repository = new UserRepository();
            {
                bool userChangePasswordResult = repository.ChangeUserPassword(user);

                if (userChangePasswordResult) return Ok(userChangePasswordResult);
                else return Problem($"User have no permission to change password for the specified user", statusCode: 700, title: "No Permission", type: "Role Permission Error");
            }
        }

        //PUT: user/change/rfid
        [HttpPut]
        [ActionName("change/rfid")]
        public ActionResult<User> ChangeUserRFID(User user)
        {
            IUserRepository repository = new UserRepository();
            {
                if (user.Id != null) return Ok(repository.ChangeUserRFID(user));
                else return NoContent();
            }
        }

        //PUT: user/change/role
        [HttpPut]
        [ActionName("change/role")]
        public ActionResult<User> ChangeUserRole(User user)
        {
            IUserRepository repository = new UserRepository();
            {
                if (user.Id != null) return Ok(repository.ChangeUserRole(user));
                else return NoContent();
            }
        }
        #endregion
    }
}