using System.Threading.Tasks;
using Domain; 
using Application;
using Infrastructure;

public class UserService  : IUserService
{
	private readonly ApplicationDbContext _context;

	public UserService(ApplicationDbContext context)
	{
		_context = context;
	}

	public Task<User> CreateUserAsync(User user)
	{
		throw new NotImplementedException();
	}

	public Task<User> GetUserByEmailAsync(string email)
	{
		throw new NotImplementedException();
	}
}
