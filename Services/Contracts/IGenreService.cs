using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Services.Contracts
{
    public interface IGenreService
    {
        public List<Genre> GetAllGenres();
        public Genre GetById(int id);
        public HttpResponseMessage SaveOrUpdate(Genre genre);
        public HttpResponseMessage Delete(int id);
    }
}
