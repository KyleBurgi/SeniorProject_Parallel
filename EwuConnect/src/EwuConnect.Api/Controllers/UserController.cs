using System;
using AutoMapper;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;
using EwuConnect.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService UserService { get; }
        private IMapper Mapper { get; }

        public UserController(IUserService userService, IMapper mapper)
        {
            UserService = userService ?? throw new ArgumentNullException(nameof(userService));
            Mapper = mapper;
        }

        //TODO: FIX THIS CODE
        //TODO: ASYNC

        [HttpGet]
        public ActionResult<ICollection<UserViewModel>> GetAllUsers()
        {
            var users = UserService.FetchAllUsers();
            return Ok(users.Select(x => Mapper.Map<UserViewModel>(x)));
        }

        [HttpGet("user/{id}")]
        public ActionResult<ICollection<UserViewModel>> GetUser(int id)
        {
            var fetchedUser = UserService.GetUser(id);
            if(fetchedUser == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<UserViewModel>(fetchedUser));
        }

        [HttpPost]
        public ActionResult<UserViewModel> CreateUser(UserInputViewModel viewModel)
        { 
            if(viewModel == null)
            {
                return BadRequest();
            }

            User createdUser = UserService.AddUser(Mapper.Map<User>(viewModel));

            return CreatedAtAction(nameof(GetUser), 
                new { id = createdUser.Id }, 
                Mapper.Map<UserViewModel>(createdUser));
        }

        // DELETE api/<controller>/5
        [HttpDelete("user/{userId}")]
        public ActionResult Delete(int userId)
        {
            bool userWasDeleted = UserService.DeleteUser(userId);
            return userWasDeleted ? (ActionResult)Ok() : (ActionResult)NotFound();
        }

    }
}
