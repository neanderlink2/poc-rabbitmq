namespace PoC.RabbitMQ.Api.Messages
{
    public record TestingMessage
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
