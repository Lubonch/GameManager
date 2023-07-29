using FluentNHibernate.Mapping;
using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Mappings
{
    public class ConsoleMap : ClassMap<Domain.Console>
    {
        public ConsoleMap() 
        {
            Id(x => x.Id).Column("Id");
            Map(x => x.Name).Column("Name");
        }
    }
}
