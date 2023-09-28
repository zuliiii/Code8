using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public class UserService
	{
		private readonly ApplicationDbContext _context;

		public UserService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> RegisterAsync(string email, string password)
		{
			if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
			{
				return false;
			}

			string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

			var newUser = new User
			{
				Email = email,
				Password = hashedPassword
			};

			_context.Users.Add(newUser);
			await _context.SaveChangesAsync();

			return true; 
		}
	}

}
