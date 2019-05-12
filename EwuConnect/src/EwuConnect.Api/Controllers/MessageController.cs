using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EwuConnect.Domain.Services.Interfaces;
using EwuConnect.Api.ViewModels;
using EwuConnect.Domain.Models.Chat;


namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private IMessageService MessageService { get; }
        private IMapper Mapper { get; }
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            MessageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
            Mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<MessageViewModel>> CreateMessage(MessageInputViewModel viewModel)
        {
            var createdMessage = await MessageService.AddMessage(Mapper.Map<Message>(viewModel));

            return CreatedAtAction(nameof(GetMessage),
                new { id = createdMessage.Id }, 
                Mapper.Map<MessageViewModel>(createdMessage));
        }

        [HttpGet]
        public async Task<ActionResult<MessageViewModel>> GetMessage(int id)
        {
            var message = await MessageService.GetMessage(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<MessageViewModel>(message));
        }

        [HttpGet("conversation/{conversatoinId}")]
        public async Task<ActionResult<List<Message>>> GetConversation(int conversationId)
        {
            if (conversationId <= 0)
            {
                return NotFound();
            }
            List<Message> conversation = await MessageService.GetConversation(conversationId);

            return Ok(conversation.Select(x => Mapper.Map<MessageViewModel>(x)).ToList());
        }
    }
}
