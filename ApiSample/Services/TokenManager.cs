using ApiSample.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiSample.Services
{
    public class TokenManager
    {
        public static string secretKey = "èvcge!hçnzjxàazi ç'!tuoirjfdsgàç( po'!ç)à-oihnfdqs:jq^!(àoq kjiufklmjdq)çà() àç'çpoj";

        public string GenerateToken(User u)
        {
            // Génération de la clé de signature
            //Microsoft.IdentityModel.Tokens;
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Gérération du payload => Claims

            Claim[] myClaims = new Claim[]
            {
                new Claim(ClaimTypes.Role, u.IsAdmin ? "admin" : "user"),
                new Claim("UserId", u.Id.ToString()),
                new Claim(ClaimTypes.GivenName, u.UserName)
            };

            //Génération du token
            //System.IdentityModel.Tokens.Jwt;
            JwtSecurityToken jwt = new JwtSecurityToken(
                claims: myClaims,
                signingCredentials: credentials,
                expires : DateTime.Now.AddDays(1)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);

        }
    }
}
