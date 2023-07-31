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
            
            consoleList = _consoleRepository.GetAllconsoles();
            
            return consoleList;
        }
        public Domain.Console GetById(int id)
        {
            var consoleList = new Domain.Console();

            consoleList = _consoleRepository.Get(id);
            
            return consoleList;
        }
    }
}
