using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Services.Contracts
{
    public interface IGenreService
    {
        public List<Genre> GetAllGenres();
        public Genre GetById(int id);
        public bool SaveOrUpdate(Genre genre);
        public bool Delete(int id);
    }
}
