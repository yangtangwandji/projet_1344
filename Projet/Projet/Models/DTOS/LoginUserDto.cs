using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Projet.Models.DTOS
{
    public class LoginUserDto
    {
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "This is not a valid email!")]
        [Display(Name = "Email")]
        [Required]
        public string? Email { get; set; }


        //[DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*\d)(?=.*[az])(?=.*[AZ]).{8,12}$", ErrorMessage = "Must be 8 to 12 characters and contain a lowercase, an uppercase and a number!")]
        //[Display(Name = "Password")]
        //[StringLength(12, MinimumLength = 8, ErrorMessage = "Must be 8 to 12 characters and contain a lowercase, an uppercase and a number!")]
        //[Required]
        public string? Password { get; set; }
    }
}
