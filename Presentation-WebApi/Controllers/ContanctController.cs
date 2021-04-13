using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation_WebApi.Responses.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContanctController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ContanctController> _logger;
        private readonly ContactService _contactService;

        public ContanctController(ILogger<ContanctController> logger, ContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpGet("contacts")]
        public async Task<IActionResult> Get()
        {
            return Ok(_contactService.GetAll());
        }

        [HttpGet("contacts/{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(_contactService.Get(id));
        }

        [HttpPost("contacts")]
        public async Task<IActionResult> Add([FromBody] Contact contact)
        {
            return Ok(_contactService.Add(contact));
        }

        [HttpDelete("contacts/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(_contactService.Delete(id));
        }
    }
}
