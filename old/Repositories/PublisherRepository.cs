using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories.Contracts;

namespace GameManagerWebAPI.Repositories
{
    public class PublisherRepository : NHRepository<Publisher>, IPublisherRepository
    {
        public List<Publisher> GetAllPublishers()
        {
            return Session.Query<Publisher>().ToList();
        }
    }
}
