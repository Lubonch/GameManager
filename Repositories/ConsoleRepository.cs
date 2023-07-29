using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories.Contracts;

namespace GameManagerWebAPI.Repositories
{
    public class ConsoleRepository : IConsoleRepository
    {
        public ConsoleRepository() 
        { 
        }

        public List<Domain.Console> GetAllconsoles()
        {
            throw new NotImplementedException();
        }
    }
}
