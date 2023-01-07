using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chillify.Core.Services;

public class AuthService : IAuthService
{
    private readonly IMemberRepo _memberRepo;
    private readonly IConfiguration _iconfiguration;
    public AuthService(IMemberRepo memberRepo, IConfiguration iconfiguration)
    {
        _memberRepo = memberRepo;
        _iconfiguration = iconfiguration;
    }
    public ServiceResponse<int> Register(RegisterDto registerDto)
    {
        if (EmailExist(registerDto.EmailAddress.Trim()))
        {
            return new ServiceResponse<int>()
            {
                Success = false,
                Message = "Email already exists."
            };
        }
        else if (PseudoExist(registerDto.Pseudo.Trim()))
        {
            return new ServiceResponse<int>()
            {
                Success = false,
                Message = "Pseudo already exists."
            };
        }
        else
        {
            string pswdHash = CreatePasswordHash(registerDto.Password);

            Member member = new()
            {
                EmailAddress = registerDto.EmailAddress.Trim(),
                Pseudo = registerDto.Pseudo.Trim(),
                PswdHash = pswdHash,
            };

            int id = _memberRepo.Add(member);
            return new ServiceResponse<int>()
            {
                Data = id
            };
        }
    }

    public ServiceResponse<string> Login(LoginDto loginDto)
    {
        ServiceResponse<string> response = new();
        Member member = _memberRepo.GetMember(loginDto.EmailAddress.Trim());
        if (member is null)
        {
            response.Success = false;
            response.Message = "Email address not found";
        }
        else
        {
            bool isVerified = Verify(loginDto.Password, member.PswdHash);
            if (isVerified == false)
            {
                response.Success = false;
                response.Message = "Incorrect password";
            }
            else
            {
                response.Message = "Successful login";
                response.Data = CreateJwt(member);
            }
        }

        return response;
    }

    private bool EmailExist(string email)
    {
        return _memberRepo.EmailExist(email);
    }

    private bool PseudoExist(string pseudo)
    {
        return _memberRepo.PseudoExist(pseudo);
    }
    private string CreatePasswordHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    private bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }

    private string CreateJwt(Member member)
    {
        JwtSecurityTokenHandler tokenHandler = new();

        byte[] tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, member.Pseudo),
                new Claim(ClaimTypes.Email, member.EmailAddress),
                new Claim(ClaimTypes.Role, member.RoleId.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials= new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
