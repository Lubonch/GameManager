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
        await _peopleService.SaveOrUpdateAsync(people);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePeople(int id)
    {
        await _peopleService.DeleteAsync(id);
        return Ok();
    }
}