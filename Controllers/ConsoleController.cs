using GameManagerWebAPI.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameManagerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsoleController : Controller
    {    
        private readonly ILogger<ConsoleController> _logger;
        private IConsoleService _consoleService;

        public ConsoleController(ILogger<ConsoleController> logger, IConsoleService consoleService )
        {
            _logger = logger;
            _consoleService = consoleService;
        }

        [HttpGet(Name = "GetAllConsoles")]
        public IEnumerable<Domain.Console> GetAllConsoles()
        {
            return _consoleService.GetAllconsoles();
        }
    }
}
