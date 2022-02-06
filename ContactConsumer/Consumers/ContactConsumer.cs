using System;
using System.Text.Json;
using MassTransit;
using Shared.Models;

namespace ContactConsumer.Consumers
{
    public class ContactConsumer : IConsumer<Contact>
    {
        private readonly ILogger<ContactConsumer> _logger;

        public ContactConsumer(ILogger<ContactConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Contact> context)
        {
            string json = JsonSerializer.Serialize(context.Message);

            _logger.LogInformation($"Mensagem recebida {Environment.NewLine}{json}");

            return Task.CompletedTask;
        }
    }
}
