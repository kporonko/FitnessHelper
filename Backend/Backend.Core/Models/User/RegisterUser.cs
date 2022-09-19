using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models
{
    public class RegisterUser
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must contain at least 8 symbols")]
        public string Password { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }
    }
}
