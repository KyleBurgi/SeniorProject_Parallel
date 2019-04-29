using System;
using AutoMapper;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;
using EwuConnect.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<ICollection<UserViewModel>>> GetAllUsers()
        {
            var users = await UserService.FetchAllUsers();
            return Ok(users.Select(x => Mapper.Map<UserViewModel>(x)));
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<ICollection<UserViewModel>>> GetUser(int id)
        {
            var fetchedUser = await UserService.GetUser(id);
            if(fetchedUser == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<UserViewModel>(fetchedUser));
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> CreateUser(UserInputViewModel viewModel)
        { 
            if(User == null)
            {
                return BadRequest();
            }

            User createdUser = await UserService.AddUser(Mapper.Map<User>(viewModel));

            return CreatedAtAction(nameof(GetUser), 
                new { id = createdUser.Id }, 
                Mapper.Map<UserViewModel>(createdUser));
        }

        [HttpPut]
        public async Task<ActionResult<UserViewModel>> UpdateUser(UserUpdateViewModel updateViewModel)
        {
            if(updateViewModel == null)
            {
                return BadRequest();
            }

            User foundUser = await UserService.GetUser(updateViewModel.Id);

            if (foundUser == null)
            {
                return NotFound();
            }

            Mapper.Map(updateViewModel, foundUser);
            await UserService.UpdateUser(foundUser);
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("user/{userId}")]
        public async Task<ActionResult> Delete(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("A UserId must be specificed");
            }

            bool userWasDeleted = await UserService.DeleteUser(userId);
            return userWasDeleted ? (ActionResult)Ok() : (ActionResult)NotFound();
        }

    }
}
