using GameManager.Server.DTOs;
using GameManager.Server.Models;
using Console = GameManager.Server.Models.Console;

namespace GameManager.Server.Services;

public interface IMappingService
{
    GameDTO ToDTO(Game game);
    Game ToModel(GameDTO gameDTO);
    ConsoleDTO ToDTO(Console console);
    Console ToModel(ConsoleDTO consoleDTO);
    GenreDTO ToDTO(Genre genre);
    Genre ToModel(GenreDTO genreDTO);
    PublisherDTO ToDTO(Publisher publisher);
    Publisher ToModel(PublisherDTO publisherDTO);
    PeopleDTO ToDTO(People people);
    People ToModel(PeopleDTO peopleDTO);
    LoginTableDTO ToDTO(LoginTable loginTable);
}