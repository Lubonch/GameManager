using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;
using NHibernate;

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
        public bool SaveOrUpdate(Genre genre)
        {
           using (NHibernate.ISession session = NhibernateConfig.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(genre);
                    tx.Commit();
                }
            }
            return true;
        }
        public bool Delete(int id)
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
                return false;
            }

            return true;
        }
    }
}
