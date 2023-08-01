using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Configs.Contracts;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;
using NHibernate;

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
        public bool SaveOrUpdate(Domain.Console console)
        {
            var consoleList = new Domain.Console();
            using (NHibernate.ISession session = NhibernateConfig.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction()) 
                {
                    session.SaveOrUpdate(console);
                    tx.Commit();
                }                    
            }
             return true;
        }
    }
}
