using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public class AuthService
	{
		private readonly IConfiguration _configuration;
		private readonly ApplicationDbContext _context;

		public AuthService(IConfiguration configuration, ApplicationDbContext context)
		{
			_configuration = configuration;
			_context = context;
		}

		public async Task<string> AuthenticateAsync(string email, string password)
		{
			// Find the user by email
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

			if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
			{
				return null;
			}

			var token = GenerateJwtToken(user);

			return token;
		}

		private string GenerateJwtToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
				new Claim(ClaimTypes.Name, user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}

}
