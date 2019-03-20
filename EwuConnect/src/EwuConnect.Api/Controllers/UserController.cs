using System;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService { get; }

        public UserController(IUserService userService)
        {
            UserService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        //TODO: FIX THIS CODE

        /*
        // POST api/<controller>
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            UserService.AddUser(user);

            return Ok();
        }
        */

        /*
        [HttpPut("{userId}")]
        public ActionResult<User> Put(int userId, User user)
        {
            if(userId < 0)
            {
                return BadRequest();
            }

            User foundUser = UserService.GetUser(userId);

            if(foundUser == null)
            {
                return NotFound();
            }

            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName; 
            UserService.UpdateUser(foundUser);

            return user;
        }
        */

        /*
        // GET api/<controller>/1
        [HttpGet("{userId}")]
        public ActionResult<User> Get(int userId)
        {
            if (userId < 0)
            {
                return BadRequest();
            }
            User foundUser = UserService.GetUser(userId);

            if (foundUser == null)
            {
                return NotFound();
            }
            return foundUser;
        }
        */

        // DELETE api/<controller>/5
        [HttpDelete("{userId}")]
        public ActionResult Delete(int userId)
        {
            bool userWasDeleted = UserService.DeleteUser(userId);
            return userWasDeleted ? (ActionResult)Ok() : (ActionResult)NotFound();
        }

    }
}
