namespace Wtt.Domain.Entities
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
