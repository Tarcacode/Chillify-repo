using System.ComponentModel.DataAnnotations;

namespace Chillify.Blaz.Shared.Dtos.Auth;

public class LoginDto
{
    [Required]
    [DataType(DataType.EmailAddress)] 
    public string EmailAddress { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
