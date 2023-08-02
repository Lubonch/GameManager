using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories.Contracts;

namespace GameManagerWebAPI.Repositories
{
    public class GameRepository : NHRepository<Game>, IGameRepository
    {
        public List<Game> GetAllGames()
        {
            return Session.Query<Game>().ToList();
        }
    }
}
