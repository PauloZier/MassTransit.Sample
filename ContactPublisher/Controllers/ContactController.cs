using System;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace ContactPubliser.Controllers
{
    [ApiController]
    [Route("v1/contact")]
    public class ContactController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public ContactController(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (contact is null)
                return BadRequest();

            Uri uri = new($"{_configuration["RabbitMQSettings:Host"]}/contactQueue");
            ISendEndpoint sendEndpoint = await _bus.GetSendEndpoint(uri);
            await sendEndpoint.Send(contact);
            return Ok();
        }
    }
}
