using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public interface IUserService
	{
		Task<User> CreateUserAsync(User user);
		Task<User> GetUserByEmailAsync(string email);
	}
}
