﻿namespace GameManagerWebAPI.Services.Contracts
{
    public interface IConsoleService
    {
        public List<Domain.Console> GetAllconsoles();
        public Domain.Console GetById(int id);
        public bool SaveOrUpdate(Domain.Console console);
        public bool Delete(int id);
    }
}
