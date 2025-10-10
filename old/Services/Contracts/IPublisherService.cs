using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Services.Contracts
{
    public interface IPublisherService
    {
        public List<Publisher> GetAllPublishers();
        public Publisher GetById(int id);
        public HttpResponseMessage SaveOrUpdate(Publisher publisher);
        public HttpResponseMessage Delete(int id);
    }
}
