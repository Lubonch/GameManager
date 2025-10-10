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
        [HttpGet]
        [Route("~/GetGameById/{id}")]
        public Game GetGameById(int id)
        {
            return _gameService.GetById(id);
        }
        [HttpPost]
        [Route("~/SaveOrUpdateGame/")]
        public HttpResponseMessage SaveOrUpdateGame(Game game)
        {
            return _gameService.SaveOrUpdate(game);
        }
        [HttpPost]
        [Route("~/DeleteGameById/{id}")]
        public HttpResponseMessage DeleteGameById(int id)
        {
            return _gameService.Delete(id);
        }
    }
}
