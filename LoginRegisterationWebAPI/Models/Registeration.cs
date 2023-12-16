using System.ComponentModel.DataAnnotations;

namespace LoginRegisterationWebAPI.Models
{
	public class Registeration
	{
		[Key]
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
	}
}
