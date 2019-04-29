using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;
using AutoMapper;
using EwuConnect.Api.ViewModels;

namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILoginService LoginService { get; }
        private IMapper Mapper { get; }

        public LoginController(ILoginService loginService, IMapper mapper)
        {
            LoginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            Mapper = mapper;
        }

        //TODO: FIX THIS CODE
        //TODO: ASYNC

        [HttpGet("login/{email}")]
        public async Task<ActionResult<int>> GetLogin(string email)
        {
            int id = await LoginService.CheckLogin(email);
            if (id < 0)
                return NotFound();
            return Ok(id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateLogin(LoginInputViewModel viewModel)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            Login createdLogin = await LoginService.AddLogin(Mapper.Map<Login>(viewModel));

            return Ok(createdLogin != null);
        }
        // DELETE api/<controller>/5
        [HttpDelete("login/{loginId}")]
        public async Task<ActionResult> Delete(int loginId)
        {
            bool loginWasDeleted = await LoginService.DeleteLogin(loginId);
            return loginWasDeleted ? (ActionResult)Ok() : (ActionResult)NotFound();
        }
    }
}
