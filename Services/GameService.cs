using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;

namespace GameManagerWebAPI.Services
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository) 
        {
            _gameRepository = gameRepository;
        }
        public List<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }
    }
}
