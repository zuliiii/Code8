using System.ComponentModel.DataAnnotations;

namespace API.Models
{
	public class LoginRequest
	{
		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid email format.")]
		public required string Email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[DataType(DataType.Password)]
		public required string Password { get; set; }
	}

}
