using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models.Domain;

namespace WebAPI.Repository
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        
        public Task<string> CreateTokenAsync(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:Key"]));

            //Claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName!));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName!));
            claims.Add(new Claim(ClaimTypes.Email, user.EmailAddress!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var exp = DateTime.UtcNow.AddDays(1);

            var securityToken = new JwtSecurityToken(issuer: this._configuration["Jwt:Issuer"],
                audience: this._configuration["Jwt:Audience"],
                claims: claims,
                expires: exp,
                signingCredentials: creds);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return Task.FromResult(token);
        }
    }
}
