using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Services;
using GameManagerWebAPI.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameManagerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private IGameService _gameService;

        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpGet]
        [Route("~/GetAllGames/")]
        public IEnumerable<Game> GetAllGames()
        {
            return _gameService.GetAllGames();
        }
    }
}
