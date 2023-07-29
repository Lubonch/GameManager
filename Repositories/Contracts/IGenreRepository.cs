using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Contracts
{
    public interface IGenreRepository
    {
        public List<Genre> GetAllGenres();
    }
}
