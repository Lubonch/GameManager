using GameManager.Server.Models;
using GameManager.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGenres()
    {
        var genres = await _genreService.GetAllGenresAsync();
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGenreById(int id)
    {
        var genre = await _genreService.GetByIdAsync(id);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrUpdateGenre(Genre genre)
    {
        var currentUserId = int.Parse(Request.Headers["Current-User-Id"].ToString() ?? "0");
        genre.CreatedAt = DateTime.Now;
        genre.UpdatedAt = DateTime.Now;
        genre.CreatedById = currentUserId;
        genre.UpdatedById = currentUserId;
        await _genreService.SaveOrUpdateAsync(genre);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGenre(int id, Genre genre)
    {
        if (id != genre.Id)
        {
            return BadRequest();
        }

        var currentUserId = int.Parse(Request.Headers["Current-User-Id"].ToString() ?? "0");
        var existingGenre = await _genreService.GetByIdAsync(id);
        if (existingGenre == null)
        {
            return NotFound();
        }

        existingGenre.Name = genre.Name;
        existingGenre.UpdatedAt = DateTime.Now;
        existingGenre.UpdatedById = currentUserId;

        await _genreService.SaveOrUpdateAsync(existingGenre);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        await _genreService.DeleteAsync(id);
        return Ok();
    }
}