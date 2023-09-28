using API.Models;
using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserService _userService;
		private readonly AuthService _authService;

		public AuthController(UserService userService, AuthService authService)
		{
			_userService = userService;
			_authService = authService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequest model)
		{
			if (await _userService.RegisterAsync(model.Email, model.Password))
			{
				return Ok(new { Message = "Registration successful" });
			}

			return BadRequest(new { Message = "Registration failed" });
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest model)
		{
			var token = await _authService.AuthenticateAsync(model.Email, model.Password);

			if (token == null)
			{
				return Unauthorized(new { Message = "Invalid credentials" });
			}

			return Ok(new { Token = token });
		}
	}
}
