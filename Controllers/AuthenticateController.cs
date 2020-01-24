using CheckInSystem.Data;
using CheckInSystem.Objects;
using CheckInSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CheckInSystem.Controllers
{
    [Route("auth/[action]")]
    public class AuthenticateController : ControllerBase
    {
        #region POST Methods
        [HttpPost]
        [ActionName("login")]
        public ActionResult<User> AuthenticateLogInCredentials(string userName, string password)
        {
            IAuthenticateRepository repository = new AuthenticateRepository();
            {
                if (userName != null && userName != "")
                {
                    if (password != null && password != "")
                    {
                        bool authLogInResult = repository.AuthenticateLogInCredentials(userName, password);

                        if (authLogInResult)
                            return Ok(authLogInResult);
                        else
                            return Problem(title: "Auth Failure", type: "Error", detail: "Couldn't Authenticate Login Credentials.");

                    }
                    return NotFound();
                }
                return NotFound();
            }
        }
        #endregion
    }
}