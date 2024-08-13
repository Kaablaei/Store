using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace API.DTOs.Account
{
    public record RegisterViewModel
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

