using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Services.Contracts
{
    public interface IPublisherService
    {
        public List<Publisher> GetAllPublishers();
    }
}
