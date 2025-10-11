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
        var currentUserId = int.Parse(Request.Headers["Current-User-Id"].ToString() ?? "0");
        publisher.CreatedAt = DateTime.Now;
        publisher.UpdatedAt = DateTime.Now;
        publisher.CreatedById = currentUserId;
        publisher.UpdatedById = currentUserId;
        await _publisherService.SaveOrUpdateAsync(publisher);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePublisher(int id, Publisher publisher)
    {
        if (id != publisher.Id)
        {
            return BadRequest();
        }

        var currentUserId = int.Parse(Request.Headers["Current-User-Id"].ToString() ?? "0");
        var existingPublisher = await _publisherService.GetByIdAsync(id);
        if (existingPublisher == null)
        {
            return NotFound();
        }

        existingPublisher.Name = publisher.Name;
        existingPublisher.UpdatedAt = DateTime.Now;
        existingPublisher.UpdatedById = currentUserId;

        await _publisherService.SaveOrUpdateAsync(existingPublisher);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePublisher(int id)
    {
        await _publisherService.DeleteAsync(id);
        return Ok();
    }
}