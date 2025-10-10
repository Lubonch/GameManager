using GameManager.Server.Models;
using GameManager.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPublishers()
    {
        var publishers = await _publisherService.GetAllPublishersAsync();
        return Ok(publishers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPublisherById(int id)
    {
        var publisher = await _publisherService.GetByIdAsync(id);
        if (publisher == null)
        {
            return NotFound();
        }
        return Ok(publisher);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrUpdatePublisher(Publisher publisher)
    {
        await _publisherService.SaveOrUpdateAsync(publisher);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePublisher(int id)
    {
        await _publisherService.DeleteAsync(id);
        return Ok();
    }
}