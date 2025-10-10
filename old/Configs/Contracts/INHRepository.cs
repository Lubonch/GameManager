using NHibernate.Criterion;
using NHibernate;
using GameManagerWebAPI.Configs.Contracts;

namespace GameManagerWebAPI.Configs
{
    public interface INHRepository<T> : IRepository<T>, BaseRepository<T>
    {
    }
}
