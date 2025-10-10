using GameManagerWebAPI.Configs.Contracts;
using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Contracts
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        public List<Publisher> GetAllPublishers();
    }
}
