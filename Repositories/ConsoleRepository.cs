using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Configs;

namespace GameManagerWebAPI.Repositories
{
    public class ConsoleRepository : NHRepository<Domain.Console>, IConsoleRepository
    {

        public ConsoleRepository()
        {

        }

        public List<Domain.Console> GetAllconsoles()
        {
            return Session.Query<Domain.Console>().ToList();
        }
    }
}