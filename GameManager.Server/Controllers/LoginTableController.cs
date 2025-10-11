using GameManager.Server.Models;
using GameManager.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginTableController : ControllerBase
{
    private readonly ILoginTableService _loginTableService;

    public LoginTableController(ILoginTableService loginTableService)
    {
        _loginTableService = loginTableService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLoginTables()
    {
        var loginTables = await _loginTableService.GetAllLoginTablesAsync();
        return Ok(loginTables);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoginTableById(int id)
    {
        var loginTable = await _loginTableService.GetByIdAsync(id);
        if (loginTable == null)
        {
            return NotFound();
        }
        return Ok(loginTable);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrUpdateLoginTable(LoginTable loginTable)
    {
        await _loginTableService.SaveOrUpdateAsync(loginTable);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoginTable(int id)
    {
        await _loginTableService.DeleteAsync(id);
        return Ok();
    }
}