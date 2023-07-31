using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Configs;

namespace GameManagerWebAPI.Repositories
{
    public class ConsoleRepository : IConsoleRepository
    {

        public ConsoleRepository()
        {

        }

        public List<Domain.Console> GetAllconsoles(NHibernate.ISession session)
        {
            return session.Query<Domain.Console>().ToList();
        }
    }
}