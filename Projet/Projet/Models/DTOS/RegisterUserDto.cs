using System.ComponentModel.DataAnnotations;

namespace Projet.Models.DTOS
{
    public class RegisterUserDto
    {
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        [StringLength(maximumLength: 25, ErrorMessage = "Must have a maximum of 25 characters")]
        [Required]
        public string? UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "This is not a valid email!")]
        [Display(Name = "Email")]
        [Required]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[az])(?=.*[AZ]).{8,12}$", ErrorMessage = "Must be 8 to 12 characters and contain a lowercase, an uppercase and a number!")]
        [Display(Name = "Password")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Must be 8 to 12 characters and contain a lowercase, an uppercase and a number!")]
        [Required]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords are not the same!")]
        public string? ConfirmPassword { get; set; }
    }
}
