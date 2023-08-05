using GameManagerWebAPI.Configs;
using GameManagerWebAPI.Configs.Contracts;
using GameManagerWebAPI.Repositories.Contracts;
using GameManagerWebAPI.Services.Contracts;
using NHibernate;
using System.Net;
using System.Net.Http;

namespace GameManagerWebAPI.Services.Contracts
{
    public interface IConsoleService
    {
        public List<Domain.Console> GetAllconsoles();
        public Domain.Console GetById(int id);
        public HttpResponseMessage SaveOrUpdate(Domain.Console console);
        public HttpResponseMessage Delete(int id);
    }
}
