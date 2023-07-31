namespace GameManagerWebAPI.Domain
{
    public class LoginTable
    {
        public virtual int Id { get; set; }
        public virtual string username { get; set; }
        public virtual string password { get; set; }
    }
}
