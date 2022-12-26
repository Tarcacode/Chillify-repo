using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Chillify.Blaz.Shared.Dtos.Auth;

public class RegisterDto
{
    [DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }

    public string Pseudo { get; set; }

    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter and one number.")]
    public string Password { get; set; }
}
