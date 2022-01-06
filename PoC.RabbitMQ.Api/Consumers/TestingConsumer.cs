using MassTransit;
using PoC.RabbitMQ.Api.Messages;

namespace PoC.RabbitMQ.Api.Consumers
{
    public class TestingConsumer : IConsumer<TestingMessage>
    {
        private readonly ILogger<TestingConsumer> _logger;

        public TestingConsumer(ILogger<TestingConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<TestingMessage> context)
        {
            _logger.Log(LogLevel.Information, "Chegou => {0}", context.Message.ToString());
        }
    }
}
