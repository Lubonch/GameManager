using GameManager.Server.Data;
using GameManager.Server.Models;

namespace GameManager.Server.Data;

public static class DbInitializer
{
    public static void Initialize(GameManagerContext context)
    {
        context.Database.EnsureCreated();

        // Si ya hay datos, no hacer nada
        if (context.Games.Any())
        {
            return;
        }

        // Datos de ejemplo para Consolas
        var consoles = new GameConsole[]
        {
            new GameConsole { Name = "PlayStation 5" },
            new GameConsole { Name = "Xbox Series X" },
            new GameConsole { Name = "Nintendo Switch" },
            new GameConsole { Name = "PlayStation 4" },
            new GameConsole { Name = "Xbox One" },
            new GameConsole { Name = "PC" }
        };
        context.GameConsoles.AddRange(consoles);
        context.SaveChanges();

        // Datos de ejemplo para Géneros
        var genres = new Genre[]
        {
            new Genre { Name = "Action" },
            new Genre { Name = "Adventure" },
            new Genre { Name = "RPG" },
            new Genre { Name = "Sports" },
            new Genre { Name = "Racing" },
            new Genre { Name = "Strategy" },
            new Genre { Name = "Puzzle" },
            new Genre { Name = "Fighting" }
        };
        context.Genres.AddRange(genres);
        context.SaveChanges();

        // Datos de ejemplo para Publishers
        var publishers = new Publisher[]
        {
            new Publisher { Name = "Sony Interactive Entertainment" },
            new Publisher { Name = "Microsoft Studios" },
            new Publisher { Name = "Nintendo" },
            new Publisher { Name = "Electronic Arts" },
            new Publisher { Name = "Activision" },
            new Publisher { Name = "Ubisoft" },
            new Publisher { Name = "Square Enix" },
            new Publisher { Name = "Bandai Namco" }
        };
        context.Publishers.AddRange(publishers);
        context.SaveChanges();

        // Datos de ejemplo para Juegos
        var games = new Game[]
        {
            new Game
            {
                Name = "The Last of Us Part II",
                Year = new DateTime(2020, 6, 19),
                PublisherId = 1, // Sony
                ConsoleId = 4, // PS4
                GenreId = 2, // Adventure
                Quantity = 5,
                Price = 59.99f
            },
            new Game
            {
                Name = "Halo Infinite",
                Year = new DateTime(2021, 12, 8),
                PublisherId = 2, // Microsoft
                ConsoleId = 2, // Xbox Series X
                GenreId = 1, // Action
                Quantity = 3,
                Price = 59.99f
            },
            new Game
            {
                Name = "The Legend of Zelda: Breath of the Wild",
                Year = new DateTime(2017, 3, 3),
                PublisherId = 3, // Nintendo
                ConsoleId = 3, // Nintendo Switch
                GenreId = 2, // Adventure
                Quantity = 7,
                Price = 59.99f
            }
        };
        context.Games.AddRange(games);
        context.SaveChanges();

        // Datos de ejemplo para People
        var people = new People[]
        {
            new People { Name = "John Doe", Age = 25 },
            new People { Name = "Jane Smith", Age = 30 },
            new People { Name = "Bob Johnson", Age = 35 }
        };
        context.Peoples.AddRange(people);
        context.SaveChanges();

        // Datos de ejemplo para Login (usuario admin)
        var loginTables = new LoginTable[]
        {
            new LoginTable { Username = "admin", Password = "admin123" }, // En producción usar hash
            new LoginTable { Username = "user", Password = "user123" }
        };
        context.LoginTables.AddRange(loginTables);
        context.SaveChanges();
    }
}