
namespace Chillify.Core.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepo _memberRepo;

    public MemberService(IMemberRepo memberRepo)
	{
        _memberRepo = memberRepo;
    }

    public ServiceResponse<List<Member>> GetMembers()
    {
        List<Member> members= _memberRepo.GetMembers();

        ServiceResponse<List<Member>> response = new();

        if (members.Count <= 0)
        {
            response.Success = false;
            response.Message = "Can not find any User";
        }
        else
        {
            response.Data = members;
        }

        return response;
    }

    public ServiceResponse<Member> GetMemberById(int id)
    {
        Member member = _memberRepo.GetMemberById(id);

        ServiceResponse<Member> response = new();

        if (member is null)
        {
            response.Success = false;
            response.Message = "Can not find this User";
        }
        else
        {
            response.Data = member;
        }

        return response;
    }
}
