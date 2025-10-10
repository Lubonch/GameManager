using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Configs.Contracts;
using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Contracts
{
    public interface IConsoleRepository : IRepository<Domain.Console>
    {
        public List<Domain.Console> GetAllconsoles();
    }
}
