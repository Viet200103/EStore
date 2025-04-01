using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using EStore.Business.Contants;
using EStore.Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EStore.Business.Security;

public class TokenProvider: ITokenProvider
{
    private readonly JwtOptions _jwtOptions;

    public TokenProvider(IOptions<JwtOptions> options)
    {
        _jwtOptions = options.Value;
    }

    public string GenerateToken(Member member, IEnumerable<string> roles)
    {
        if (_jwtOptions.SecretKey.Length < 32)
        {
            throw new SecurityException("The secret key must be at least 32 characters to avoid brute force");
        }
        
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claimList = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Email, member.Email),
            new(JwtRegisteredClaimNames.Sub, member.MemberId.ToString()),
        };
        
        claimList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _jwtOptions.ValidAudience,
            Issuer = _jwtOptions.ValidIssuer,
            Subject = new ClaimsIdentity(claimList),
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddSeconds(_jwtOptions.ExpiryInSeconds),
            SigningCredentials = credentials,
            TokenType = Utils.AccessToken
        };
        
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}