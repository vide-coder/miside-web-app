namespace Infrastructure.Options
{
    public class AuthenticationSettings
    {
        public TimeSpan Expires { get; set; }
        public string SecretKey { get; set; }
    }
}
