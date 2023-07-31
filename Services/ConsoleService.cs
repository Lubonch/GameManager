using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;

namespace GameManagerWebAPI.Services
{
    public class ConsoleService : IConsoleService
    {
        private IConsoleRepository _consoleRepository;
        public ConsoleService(IConsoleRepository consoleRepository) 
        { 
            _consoleRepository = consoleRepository;
        }
        public List<Domain.Console> GetAllconsoles()
        {
            var consoleList = new List<Domain.Console>();
            using (var session = NhibernateConfig.OpenSession())
            {
                consoleList = _consoleRepository.GetAllconsoles(session);
            }
            return consoleList;
        }
        public Domain.Console GetById(int id)
        {
            var consoleList = new Domain.Console();
            using (var session = NhibernateConfig.OpenSession())
            {
                consoleList = session.Get<Domain.Console>(id);
            }
            return consoleList;
        }
    }
}
