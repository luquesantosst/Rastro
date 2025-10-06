using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rastro.Domain.Interfaces.Account;
using Rastro.Infra.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Rastro.Infra.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var usuario = await _context.Usuario.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();

            if (usuario == null)
                return false;

            using var hmac = new HMACSHA512(usuario.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != usuario.PasswordHash[i]) return false;
            }

            return true;
        }


        public string GenerateToken(Guid id, string email)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var experation = DateTime.Now.AddMinutes(30);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: experation,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<bool> UserExists(string email)
        {
            var usuario = await _context.Usuario.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();

            if (usuario == null)
                return false;

            return true;
        }
    }
}
