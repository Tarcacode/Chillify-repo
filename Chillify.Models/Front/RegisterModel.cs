using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Chillify.Models.Front;

public class RegisterModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    [DisplayName("Email address")]
    public string EmailAddress { get; set; }

    [Required]
    public string Pseudo { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter and one number.")]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
