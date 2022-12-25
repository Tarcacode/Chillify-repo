using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Chillify.Blaz.Shared.Models.Auth;

public class RegisterModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [DisplayName("Email address")]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    public string Pseudo { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter and one number.")]
    public string Password { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
