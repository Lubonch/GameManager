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

        [HttpGet]
        [Route("~/GetAllConsoles/")]
        public IEnumerable<Domain.Console> GetAllConsoles()
        {
            return _consoleService.GetAllconsoles();
        }

        
        [HttpGet]
        [Route("~/GetConsoleById/{id}")]
        public Domain.Console GetConsoleById(int id)
        {
            return _consoleService.GetById(id);
        }
        [HttpPost]
        [Route("~/SaveOrUpdateConsole/")]
        public bool SaveOrUpdateConsole(Domain.Console console)
        {
            return _consoleService.SaveOrUpdate(console);
        }
    }
}
