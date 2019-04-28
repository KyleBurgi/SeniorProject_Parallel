using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EwuConnect.Api.ViewModels;
using EwuConnect.Domain.Models.Forum;
using EwuConnect.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : Controller
    {
        private IResponseService ResponseService { get; }
        private IMapper Mapper { get; }

        public ResponseController(IResponseService responseService)
        {
            ResponseService = responseService ?? throw new ArgumentNullException(nameof(responseService));
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Response>> CreateResponse(ResponseInputViewModel viewModel)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            Response createdResponse = await ResponseService.AddResponse(Mapper.Map<Response>(viewModel));

            return CreatedAtAction(nameof(Get_ResponseId),
                new { id = createdResponse.Id },
                Mapper.Map<UserViewModel>(createdResponse));
        }


        [HttpPut("{responseId}")]
        public async Task<ActionResult<Response>> UpdateResponse(int responseId, Response response)
        {
            if (responseId < 0)
            {
                return BadRequest();
            }

            Response foundResponse = await ResponseService.GetResponse_Id(responseId);

            if (foundResponse == null)
            {
                return NotFound();
            }

            foundResponse.Content = response.Content;
            await ResponseService.UpdateResponse(foundResponse);

            return NoContent();
        }



        // GET api/<controller>/1
        [HttpGet("{postId}")]
        public async Task<ActionResult<List<Response>>> Get_PostId(int postId)
        {
            if (postId < 0)
            {
                return BadRequest();
            }
            List<Response> foundResponses = await ResponseService.GetResponse_PostId(postId);

            if (foundResponses == null)
            {
                return NotFound();
            }
            return foundResponses;
        }

        [HttpGet("{responseId}")]
        public async Task<ActionResult<Response>> Get_ResponseId(int responseId)
        {
            if (responseId < 0)
            {
                return BadRequest();
            }
            Response foundResponse = await  ResponseService.GetResponse_Id(responseId);

            if (foundResponse == null)
            {
                return NotFound();
            }
            return foundResponse;
        }
        [HttpGet]
        public async Task<ActionResult<List<Response>>> GetAllResponses()
        {
            List<Response> foundResponses = await ResponseService.GetBatchResponse();

            if (foundResponses == null)
            {
                return NotFound();
            }
            return foundResponses;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{responseId}")]
        public async Task<ActionResult> DeleteResponse(int responseId)
        {
            bool responseWasDeleted = await ResponseService.DeleteResponse(responseId);
            return responseWasDeleted ? (ActionResult)Ok() : (ActionResult)NotFound();
        }

    }
}