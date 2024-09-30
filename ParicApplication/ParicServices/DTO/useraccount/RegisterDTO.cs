using System.ComponentModel.DataAnnotations;

namespace ParicApplication.ParicServices.DTO.useraccount
{
	public class RegisterDTO
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
