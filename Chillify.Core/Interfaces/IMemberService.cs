
namespace Chillify.Core.Interfaces;

public interface IMemberService
{
    ServiceResponse<List<Member>> GetMembers();
    ServiceResponse<Member> GetMemberById(int id);
    ServiceResponse<bool> Edit(int id, Member member);
}
