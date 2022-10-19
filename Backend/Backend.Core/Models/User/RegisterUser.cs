using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models
{
    public class RegisterUser
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }
    }
}
