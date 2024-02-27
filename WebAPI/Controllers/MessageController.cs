using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }


        [HttpPost]

        public Task<bool> SendMessage([FromBody] MessageData message)
        {
            _logger.LogInformation(message.Message);
            return Task.FromResult(true);
        }
    }
}