namespace Chillify.FrontServices.Interfaces;

public interface IMemberService
{
    Task<ServiceResponse<List<Member>>> GetMembers();
    Task<ServiceResponse<Member>> GetMember(int id);
}
