using GameManagerWebAPI.Services.Contracts;
using GameManagerWebAPI.Services;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Repositories;

namespace GameManagerWebAPI.Configs
{
    static class CustomExtensions
    {
        public static void AddInjectionServices(IServiceCollection services)
        {
            services.AddScoped<IConsoleService, ConsoleService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPublisherService, PublisherService>();
        }
        public static void AddInjectionRepositories(IServiceCollection services)
        {
            services.AddScoped<IConsoleRepository, ConsoleRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
        }
    }
}
