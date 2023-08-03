using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Services.Contracts
{
    public interface IGameService
    {
        public List<Game> GetAllGames();
        public Game GetById(int id);
        public bool SaveOrUpdate(Game game);
        public bool Delete(int id);


    }
}
