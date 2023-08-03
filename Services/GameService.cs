using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;
using NHibernate;

namespace GameManagerWebAPI.Services
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository) 
        {
            _gameRepository = gameRepository;
        }
        public List<Game> GetAllGames()
        {
            var gameList = new List<Game>();

            gameList = _gameRepository.GetAllGames();

            return gameList;
        }

        public Game GetById(int id)
        {
            var game = new Game();

            game = _gameRepository.Get(id);

            return game;
        }
        public bool SaveOrUpdate(Game game)
        {
            using (NHibernate.ISession session = NhibernateConfig.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(game);
                    tx.Commit();
                }
            }
            return true;
        }
        public bool Delete(int id)
        {
            var game = new Game();
            game = _gameRepository.Get(id);
            try
            {
                using (NHibernate.ISession session = NhibernateConfig.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        session.Delete(game);
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
