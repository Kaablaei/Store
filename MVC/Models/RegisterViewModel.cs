using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class RegisterViewModel
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string Name { get; set; }
        public string Family { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
