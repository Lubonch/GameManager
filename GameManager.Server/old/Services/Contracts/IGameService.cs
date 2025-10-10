using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Services.Contracts
{
    public interface IGameService
    {
        public List<Game> GetAllGames();
        public Game GetById(int id);
        public HttpResponseMessage SaveOrUpdate(Game game);
        public HttpResponseMessage Delete(int id);


    }
}
