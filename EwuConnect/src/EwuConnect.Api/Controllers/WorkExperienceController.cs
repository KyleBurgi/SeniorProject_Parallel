﻿using System;
using System.Collections.Generic;
using System.Linq;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : Controller
    {
        private readonly IWorkExperienceService WorkExperienceService;
        public WorkExperienceController(IWorkExperienceService workExperienceService)
        {
            WorkExperienceService = workExperienceService ?? throw new ArgumentNullException(nameof(workExperienceService));
        }
        /*
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
        */
        /*
        [HttpGet("{workExperienceId")]
        public ActionResult<DTO.WorkExperience> GetSingleWorkExperience(int workExperienceId)
        { 
            if (workExperienceId < 0)
            {
                return NotFound();
            }

            WorkExperience foundWork = WorkExperienceService.GetWorkExperience(workExperienceId);

            return new DTO.WorkExperience(foundWork);
        }
        */
        /*
        [HttpPost]
        public ActionResult PostWorkExperience(WorkExperience workExperience)
        {
            if(workExperience == null)
            {
                return BadRequest();
            }
            WorkExperienceService.AddWorkExperience(workExperience);

            return Ok();

        }
        */
    }
}