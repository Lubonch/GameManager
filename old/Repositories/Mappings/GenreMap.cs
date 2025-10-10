using FluentNHibernate.Mapping;
using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Mappings
{
    public class GenreMap : ClassMap<Genre>
    {
        public GenreMap() 
        {
            Id(x => x.Id).Column("Id");
            Map(x => x.Name).Column("Name");
        }
    }
}
