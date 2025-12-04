namespace Authentication.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = default!;
        public Guid? CustomerId { get; set; } = default!;
    }
}
