using GameManagerWebAPI.Services.Contracts;

namespace GameManagerWebAPI.Services
{
    public class ConsoleService : IConsoleService
    {
        public List<Domain.Console> GetAllconsoles()
        {
            var consoleList = new List<Domain.Console>();
            consoleList.Add
            (
                new Domain.Console()
                {
                    Id = 1,
                    Name = "Test"
                }
             );

            return consoleList;
        }
    }
}
