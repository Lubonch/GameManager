using FluentNHibernate.Mapping;
using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Mappings
{
    public class PublisherMap : ClassMap<Publisher>
    {
        public PublisherMap() 
        {
            Id(x => x.Id).Column("Id");
            Map(x => x.Name).Column("Name"); 
        }
    }
}
