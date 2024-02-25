using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WebAPIs.Config;
using WebAPIs.DTO;

namespace WebApi.Services;

public class TokenGenerator
{
    private static int expirationHours { get; } = 2;
    
    private DateTime expirationDate { get; init; } = DateTime.UtcNow.AddHours(expirationHours);

    public DateTime getExpiration()
    {
        return expirationDate;
    }
    
    public string generate(UsuarioToken userToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(JwtConfig.Secret);

        List<Claim> claims = new List<Claim>();
        
        claims.Add(new Claim(ClaimTypes.Name, userToken.email));
        claims.Add(new Claim("id", userToken.id.ToString()));
        

        var claim = new Claim[claims.Capacity];
        claims.CopyTo(claim);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claim),
            Expires = expirationDate,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tkn = tokenHandler.WriteToken(token);
        return tkn;
    }
}