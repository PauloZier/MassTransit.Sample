using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x => 
{
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config => 
    {
        config.Host(new Uri(builder.Configuration["RabbitMQSettings:Host"]), hostConfig => 
        {
            hostConfig.Username(builder.Configuration["RabbitMQSettings:Username"]);
            hostConfig.Password(builder.Configuration["RabbitMQSettings:Password"]);
        });
    }));
});

builder.Services.AddMassTransitHostedService();

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
