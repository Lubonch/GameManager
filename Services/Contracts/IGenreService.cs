using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Services.Contracts
{
    public interface IGenreService
    {
        public List<Genre> GetAllGenres();
    }
}
