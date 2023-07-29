using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Contracts
{
    public interface IPublisherRepository
    {
        public List<Publisher> GetAllPublishers();
    }
}
