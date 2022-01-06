using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PoC.RabbitMQ.Api.Messages;

namespace PoC.RabbitMQ.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestingController : ControllerBase
    {
        private readonly ILogger<TestingController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public TestingController(ILogger<TestingController> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TestingMessage testingMessage)
        {
            await _publishEndpoint.Publish(testingMessage);
            return Ok();
        }
    }
}