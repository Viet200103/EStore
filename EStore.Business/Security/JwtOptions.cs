namespace EStore.Business.Security;

public class JwtOptions
{
    public required string ValidIssuer { get; set; }
    public required string ValidAudience { get; set; }
    public required string SecretKey { get; set; }
    public int ExpiryInSeconds { get; set; }
}