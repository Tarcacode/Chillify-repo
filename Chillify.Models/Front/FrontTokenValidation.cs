using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chillify.Models.Front;

public class FrontTokenValidation
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string? Token { get; set; }

}
