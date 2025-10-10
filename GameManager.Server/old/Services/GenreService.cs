using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;
using NHibernate;
using System.Net;

namespace GameManagerWebAPI.Services
{
    public class GenreService : IGenreService
    {
        private IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public List<Genre> GetAllGenres()
        {
            var consoleList = new List<Genre>();

            consoleList = _genreRepository.GetAllGenres();

            return consoleList;
        }
        public Genre GetById(int id)
        {
            var genre = new Genre();

            genre = _genreRepository.Get(id);

            return genre;
        }
        public HttpResponseMessage SaveOrUpdate(Genre genre)
        {
           using (NHibernate.ISession session = NhibernateConfig.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(genre);
                    tx.Commit();
                }
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        public HttpResponseMessage Delete(int id)
        {
            var genre = new Genre();
            genre = _genreRepository.Get(id);
            try
            {
                using (NHibernate.ISession session = NhibernateConfig.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        session.Delete(genre);
                        tx.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
