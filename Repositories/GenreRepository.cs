using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;

namespace GameManagerWebAPI.Repositories
{
    public class GenreRepository : NHRepository<Genre>, IGenreRepository
    {
        public List<Genre> GetAllGenres()
        {
            return Session.Query<Genre>().ToList();
        }
    }
}
