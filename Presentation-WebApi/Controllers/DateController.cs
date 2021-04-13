using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation_WebApi.Filters;
using Presentation_WebApi.Responses.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DateController : ControllerBase
    {
        private readonly ILogger<ContanctController> _logger;

        public DateController(ILogger<ContanctController> logger)
        {
            _logger = logger;
        }

        [HttpGet("date")]
        public async Task<IActionResult> GetDate()
        {
            return Ok(DateTime.Now.ToString("T"));
        }

        [ResponseCache(Duration = 10)]
        [HttpGet("cached-date")]
        public async Task<IActionResult> GetCachedDate()
        {
            return Ok(DateTime.Now.ToString("T"));
        }

        [LogActionFilter]
        [HttpGet("run-filter")]
        public async Task<IActionResult> RunFilter()
        {
            return Ok(DateTime.Now.ToString("T"));
        }
    }
}
