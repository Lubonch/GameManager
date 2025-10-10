using GameManagerWebAPI.Configs.Contracts;
using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Contracts
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public List<Genre> GetAllGenres();
    }
}
