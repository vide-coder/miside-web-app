namespace Api.Auth
{
    public class Account
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? PasswordHash { get; set; }
    }
}
