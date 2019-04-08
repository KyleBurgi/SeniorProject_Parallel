using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;
using EwuConnect.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : Controller
    {
        private readonly IEducationService EducationService;
        private IMapper Mapper { get; }

        public EducationController(IEducationService educationService, IMapper mapper)
        {
            EducationService = educationService ?? throw new ArgumentNullException(nameof(educationService));
            Mapper = mapper;
        }

        /*
        [HttpGet("user/{userId}")]
        public ActionResult<ICollection<EducationViewModel>> GetAllEducation(int userId)
        {
            if (userId < 0)
            {
                return NotFound();
            }
            List<Education> databaseUsers = EducationService.GetEducationForUser(userId);
            return Ok(Mapper.Map<EducationViewModel>(databaseUsers));
        }
        */


        [HttpGet]
        public ActionResult<EducationViewModel> GetEducation(int id)
        {
            if (id == 1)
            {
                return new EducationViewModel { 
                                CollegeName = "Eastern Washington University", 
                                FieldOfStudy = "Computer Science", 
                                LevelOfDegree = "Bachelors", 
                                YearGraduated = 2019, 
                                Id = 1 };
            }

            Education education = EducationService.GetEducation(id);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<EducationViewModel>(education));
        }


        [HttpPost]
        public ActionResult<EducationViewModel> CreateEducation(EducationInputViewModel viewModel)
        {
            Education createdEducation = EducationService.AddEducation(Mapper.Map<Education>(viewModel));

            return CreatedAtAction(nameof(GetEducation),
                new { id = createdEducation.Id },
                Mapper.Map<EducationViewModel>(createdEducation));
        }
        // GET api/EducationController/user/5
        [HttpGet("user/{userId}")]
        public string TestGet(int userId)
        {
            return "blah";
        }
    }
}
