using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameManagerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : Controller
    {
        private readonly ILogger<GenreController> _logger;
        private IGenreService _genreService;

        public GenreController(ILogger<GenreController> logger, IGenreService consoleService)
        {
            _logger = logger;
            _genreService = consoleService;
        }

        [HttpGet]
        [Route("~/GetAllGenres/")]
        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreService.GetAllGenres();
        }


        [HttpGet]
        [Route("~/GetGenreById/{id}")]
        public Genre GetGenreById(int id)
        {
            return _genreService.GetById(id);
        }
        [HttpPost]
        [Route("~/SaveOrUpdateGenre/")]
        public HttpResponseMessage SaveOrUpdateGenre(Genre genre)
        {
            return _genreService.SaveOrUpdate(genre);
        }
        [HttpPost]
        [Route("~/DeleteGenreById/{id}")]
        public HttpResponseMessage DeleteGenreById(int id)
        {
            return _genreService.Delete(id);
        }
    }
}
