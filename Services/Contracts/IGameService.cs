namespace GameManagerWebAPI.Services.Contracts
{
    public interface IGameService
    {
        public List<Domain.Game> GetAllGames();
    }
}
