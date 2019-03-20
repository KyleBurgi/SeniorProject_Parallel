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
    public class WorkExperienceController : ControllerBase
    {
        private readonly IWorkExperienceService WorkExperienceService;
        public WorkExperienceController(IWorkExperienceService workExperienceService)
        {
            WorkExperienceService = workExperienceService ?? throw new ArgumentNullException(nameof(workExperienceService));
        }

        // GET api/values/5
        [HttpGet("{userId}")]
        public ActionResult<List<DTO.WorkExperience>> GetWorkExperienceForUser(int userId)
        {
            if (userId < 0)
            {
                return NotFound();
            }
            List<WorkExperience> databaseUsers = WorkExperienceService.GetWorkExperienceForUser(userId);
            return databaseUsers.Select(x => new DTO.WorkExperience(x)).ToList();
        }
    }
}