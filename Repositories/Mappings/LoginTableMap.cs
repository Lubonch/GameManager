using FluentNHibernate.Mapping;
using GameManagerWebAPI.Domain;

namespace GameManagerWebAPI.Repositories.Mappings
{
    public class LoginTableMap : ClassMap<LoginTable>
    {
        public LoginTableMap() 
        {
            Id(x => x.Id).Column("Id");
            Map(x => x.username).Column("username");
            Map(x => x.password).Column("password");
        }
    }
}
