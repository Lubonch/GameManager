using GameManager.Server.Models;
using GameManager.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IPeopleService _peopleService;

    public PeopleController(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPeoples()
    {
        var peoples = await _peopleService.GetAllPeoplesAsync();
        return Ok(peoples);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPeopleById(int id)
    {
        var people = await _peopleService.GetByIdAsync(id);
        if (people == null)
        {
            return NotFound();
        }
        return Ok(people);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrUpdatePeople(People people)
    {
        var currentUserId = int.Parse(Request.Headers["Current-User-Id"].ToString() ?? "0");
        people.CreatedAt = DateTime.Now;
        people.UpdatedAt = DateTime.Now;
        people.CreatedById = currentUserId;
        people.UpdatedById = currentUserId;
        await _peopleService.SaveOrUpdateAsync(people);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePeople(int id, People people)
    {
        if (id != people.Id)
        {
            return BadRequest();
        }

        var currentUserId = int.Parse(Request.Headers["Current-User-Id"].ToString() ?? "0");
        var existingPeople = await _peopleService.GetByIdAsync(id);
        if (existingPeople == null)
        {
            return NotFound();
        }

        existingPeople.Name = people.Name;
        existingPeople.Age = people.Age;
        existingPeople.UpdatedAt = DateTime.Now;
        existingPeople.UpdatedById = currentUserId;

        await _peopleService.SaveOrUpdateAsync(existingPeople);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePeople(int id)
    {
        await _peopleService.DeleteAsync(id);
        return Ok();
    }
}