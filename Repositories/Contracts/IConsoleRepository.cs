using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Contracts
{
    public interface IConsoleRepository
    {
        public List<Domain.Console> GetAllconsoles(NHibernate.ISession session);
    }
}
