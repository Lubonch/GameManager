using GameManager.Server.DTOs;
using GameManager.Server.Models;
using Console = GameManager.Server.Models.Console;

namespace GameManager.Server.Services;

public class MappingService : IMappingService
{
    public GameDTO ToDTO(Game game)
    {
        return new GameDTO
        {
            Id = game.Id,
            Name = game.Name,
            Year = game.Year,
            PublisherId = game.PublisherId,
            PublisherName = game.Publisher?.Name ?? string.Empty,
            ConsoleId = game.ConsoleId,
            ConsoleName = game.Console?.Name ?? string.Empty,
            GenreId = game.GenreId,
            GenreName = game.Genre?.Name ?? string.Empty,
            Quantity = game.Quantity,
            Price = game.Price
        };
    }

    public Game ToModel(GameDTO gameDTO)
    {
        return new Game
        {
            Id = gameDTO.Id,
            Name = gameDTO.Name,
            Year = gameDTO.Year,
            PublisherId = gameDTO.PublisherId,
            ConsoleId = gameDTO.ConsoleId,
            GenreId = gameDTO.GenreId,
            Quantity = gameDTO.Quantity,
            Price = gameDTO.Price
        };
    }

    public ConsoleDTO ToDTO(Console console)
    {
        return new ConsoleDTO
        {
            Id = console.Id,
            Name = console.Name
        };
    }

    public Console ToModel(ConsoleDTO consoleDTO)
    {
        return new Console
        {
            Id = consoleDTO.Id,
            Name = consoleDTO.Name
        };
    }

    public GenreDTO ToDTO(Genre genre)
    {
        return new GenreDTO
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }

    public Genre ToModel(GenreDTO genreDTO)
    {
        return new Genre
        {
            Id = genreDTO.Id,
            Name = genreDTO.Name
        };
    }

    public PublisherDTO ToDTO(Publisher publisher)
    {
        return new PublisherDTO
        {
            Id = publisher.Id,
            Name = publisher.Name
        };
    }

    public Publisher ToModel(PublisherDTO publisherDTO)
    {
        return new Publisher
        {
            Id = publisherDTO.Id,
            Name = publisherDTO.Name
        };
    }

    public PeopleDTO ToDTO(People people)
    {
        return new PeopleDTO
        {
            Id = people.Id,
            Name = people.Name,
            Age = people.Age
        };
    }

    public People ToModel(PeopleDTO peopleDTO)
    {
        return new People
        {
            Id = peopleDTO.Id,
            Name = peopleDTO.Name,
            Age = peopleDTO.Age
        };
    }

    public LoginTableDTO ToDTO(LoginTable loginTable)
    {
        return new LoginTableDTO
        {
            Id = loginTable.Id,
            Username = loginTable.Username
            // No incluimos password por seguridad
        };
    }
}