
namespace Chillify.Core.Interfaces;

public interface IMemberService
{
    ServiceResponse<List<Member>> GetMembers();
    ServiceResponse<Member> GetMember(int id);
}
