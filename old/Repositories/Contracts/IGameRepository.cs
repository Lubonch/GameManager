using GameManagerWebAPI.Configs.Contracts;
using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Contracts
{
    public interface IGameRepository : IRepository<Game>
    {
        public List<Game> GetAllGames();
    }
}
