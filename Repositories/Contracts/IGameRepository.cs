using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Contracts
{
    public interface IGameRepository
    {
        public List<Game> GetAllGames();
    }
}
