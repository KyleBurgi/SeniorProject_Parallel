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
using EwuConnect.Domain.Models.Chat;

namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : Controller
    {
        private IConversationService ConversationService { get; }
        private IMapper Mapper { get; }
        public ConversationController(IConversationService conversationService, IMapper mapper)
        {
            ConversationService = conversationService ?? throw new ArgumentNullException(nameof(conversationService));
            Mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ConversationViewModel>> CreateConversation(ConversationInputViewModel viewModel)
        {
            var createdConversation = await ConversationService.AddConversation(Mapper.Map<Conversation>(viewModel));

            return CreatedAtAction(nameof(GetConversation),
                new { id = createdConversation.Id },
                Mapper.Map<ConversationViewModel>(createdConversation));
        }
        [HttpGet]
        public async Task<ActionResult<ConversationViewModel>> GetConversation(int id)
        {
            var conversation = await ConversationService.GetConversation(id);

            if (conversation == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ConversationViewModel>(conversation));
        }


    }
}
