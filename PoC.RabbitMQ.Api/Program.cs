using MassTransit;
using PoC.RabbitMQ.Api.Consumers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<TestingConsumer>();
    x.UsingRabbitMq((ctx, config) =>
    {
        config.ReceiveEndpoint(e =>
        {
            e.ConfigureConsumer<TestingConsumer>(ctx);
        });
    });
});
builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
