using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Services.Contracts
{
    public interface IPublisherService
    {
        public List<Publisher> GetAllPublishers();
        public Publisher GetById(int id);
        public bool SaveOrUpdate(Publisher publisher);
        public bool Delete(int id);
    }
}
