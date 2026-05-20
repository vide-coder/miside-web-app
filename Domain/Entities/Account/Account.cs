namespace Domain.Entities.Account
{
    public class Account
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
