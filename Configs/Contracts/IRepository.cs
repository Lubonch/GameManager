﻿using System.Collections.Generic;

namespace GameManagerWebAPI.Configs.Contracts
{
    public interface IRepository<T> : BaseRepository<T>
    {
        long Count();
        void Delete(T entity);
        void DeleteAll();
        bool Exists();
        ICollection<T> FindAll();
        T Get(object id);
        T Load(object id);
        T Merge(T entity);
        T Save(T entity);
        void SaveOrUpdate(T entity);
        void Update(T entity);
    }
}
