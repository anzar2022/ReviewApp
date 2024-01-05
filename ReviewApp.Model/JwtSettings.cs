namespace ReviewApp.Model
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationHours { get; set; }
        public int RefreshTokenExpiryDate { get; set; }
    }
}
