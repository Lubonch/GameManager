using GameManagerWebAPI.Domain;
using GameManagerWebAPI.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameManagerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : Controller
    {
        private readonly ILogger<PublisherController> _logger;
        private IPublisherService _publisherService;

        public PublisherController(ILogger<PublisherController> logger, IPublisherService publisherService)
        {
            _logger = logger;
            _publisherService = publisherService;
        }

        [HttpGet]
        [Route("~/GetAllPublishers/")]
        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherService.GetAllPublishers();
        }


        [HttpGet]
        [Route("~/GetPublisherById/{id}")]
        public Publisher GetPublisherById(int id)
        {
            return _publisherService.GetById(id);
        }
        [HttpPost]
        [Route("~/SaveOrUpdatePublisher/")]
        public bool SaveOrUpdatePublisher(Publisher console)
        {
            return _publisherService.SaveOrUpdate(console);
        }
        [HttpPost]
        [Route("~/DeletePublisherById/{id}")]
        public bool DeletePublisherById(int id)
        {
            return _publisherService.Delete(id);
        }
    }
}
