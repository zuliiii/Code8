using Application;
using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	// In Infrastructure layer
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<User> GetUserByIdAsync(int userId)
		{
			return await _context.Users.FindAsync(userId);
		}
		// Implement other methods
	}

}
