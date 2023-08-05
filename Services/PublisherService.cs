using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;
using NHibernate;
using System.Net;

namespace GameManagerWebAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository _publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public List<Publisher> GetAllPublishers()
        {
            var publisherList = new List<Publisher>();

            publisherList = _publisherRepository.GetAllPublishers();

            return publisherList;
        }
        public Publisher GetById(int id)
        {
            var publisher = new Publisher();

            publisher = _publisherRepository.Get(id);

            return publisher;
        }
        public HttpResponseMessage SaveOrUpdate(Publisher publisher)
        {
            using (NHibernate.ISession session = NhibernateConfig.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(publisher);
                    tx.Commit();
                }
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        public HttpResponseMessage Delete(int id)
        {
            var publisher = new Publisher();
            publisher = _publisherRepository.Get(id);
            try
            {
                using (NHibernate.ISession session = NhibernateConfig.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        session.Delete(publisher);
                        tx.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
