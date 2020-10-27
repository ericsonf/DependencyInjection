using System.Collections.Generic;
using DependencyInjection.Interfaces;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DependencyInjectionController : ControllerBase
    {
        private readonly RandomService _randomService;
        private readonly IEnumerable<IMessage> _message;
        private readonly ILogger<DependencyInjectionController> _logger;

        public DependencyInjectionController(RandomService randomService, IEnumerable<IMessage> message,
            ILogger<DependencyInjectionController> logger)
        {
            _randomService = randomService;
            _message = message;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var randomNumer = _randomService.GetNumber();

            var logMessage = $"Get Number from Controller { randomNumer }";

            _logger.LogInformation(logMessage);

            var messages = new List<string>
            {
                HttpContext.Items["RandomMiddleware"].ToString(),
                logMessage
            };

            return Ok(messages);
        }

        [HttpGet]
        [Route("{message}")]
        public string Get(string message)
        {
            string content = string.Empty;
            foreach (var item in _message)
            {
                content += $"{item.Show()}\n";
            }

            return $"{content}{message}";
        }
    }
}
