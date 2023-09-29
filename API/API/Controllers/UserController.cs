using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using API.Models;
using Application;
using Domain;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IJwtService _jwtService;

	public UserController(IUserService userService, IJwtService jwtService)
	{
		_userService = userService;
		_jwtService = jwtService;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
	{
		try
		{
			var existingUser = await _userService.GetUserByEmailAsync(request.Email);
			if (existingUser != null)
			{
				return BadRequest("A user with this email already exists.");
			}

			string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

			var newUser = new User
			{
				Email = request.Email,
				Password = hashedPassword
			};
			var createdUser = await _userService.CreateUserAsync(newUser);

			var token = _jwtService.GenerateJwtToken(createdUser);

			return Ok(new { token });
		}
		catch (Exception ex)
		{
			return StatusCode(500, "An error occurred while processing your request.");
		}
	}

}
