using System;
using System.Collections.Generic;
using System.Linq;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService EducationService;

        public EducationController(IEducationService educationService)
        {
            EducationService = educationService ?? throw new ArgumentNullException(nameof(educationService));
        }

        // GET api/values/5
        [HttpGet("{userId}")]
        public ActionResult<List<DTO.Education>> GetEducationForUser(int userId)
        {
            if (userId < 0)
            {
                return NotFound();
            }
            List<Education> databaseUsers = EducationService.GetEducationForUser(userId);
            return databaseUsers.Select(x => new DTO.Education(x)).ToList();
        }

    }
}
