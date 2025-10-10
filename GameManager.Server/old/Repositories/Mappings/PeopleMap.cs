using FluentNHibernate.Mapping;
using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Mappings
{
    public class PeopleMap : ClassMap<People>
    {
        public PeopleMap() 
        {
            Id(x => x.Id).Column("Id");
            Map(x => x.name).Column("name");
            Map(x => x.age).Column("age");
        }
    }
}
