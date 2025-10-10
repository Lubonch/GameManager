using FluentNHibernate.Mapping;
using GameManagerWebAPI.Domain;
using NHibernate.Proxy;
using System;

namespace GameManagerWebAPI.Repositories.Mappings
{
    public class GameMap : ClassMap<Game>
    {
        public GameMap() 
        {
            Id(x => x.Id).Column("Id");
            Map(x => x.Name).Column("Name");
            Map(x => x.Year).Column("Year");
            References(x => x.Publisher).Column("IdPublisher");
            References(x => x.Console).Column("IdConsole");
            References(x => x.Genre).Column("IdGenre");
            Map(x => x.Quantity).Column("Quantity");
            Map(x => x.Price).Column("Price");
        }
    }
}
