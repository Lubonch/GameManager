using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Configs.Contracts;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;
using NHibernate;
using System.Net;
using System.Net.Http;

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
            var consoleList = _consoleRepository.GetAllconsoles();

            return consoleList;
        }
        public Domain.Console GetById(int id)
        {
            var consoleList = _consoleRepository.Get(id);

            return consoleList;
        }
        public HttpResponseMessage SaveOrUpdate(Domain.Console console)
        {
            using (NHibernate.ISession session = NhibernateConfig.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction()) 
                {
                    session.SaveOrUpdate(console);
                    tx.Commit();
                }                    
            }
             return new HttpResponseMessage(HttpStatusCode.OK);
        }
        public bool Delete(int id)
        {
            var consoleList = _consoleRepository.Get(id);
            try
            {
                using (NHibernate.ISession session = NhibernateConfig.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        session.Delete(consoleList);
                        tx.Commit();
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
            return true;
        }
    }
}
