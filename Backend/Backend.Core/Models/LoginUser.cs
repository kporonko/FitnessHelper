using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models
{
    public class LoginUser
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must contain at least 8 symbols")]
        public string Password { get; set; }
    }
}
