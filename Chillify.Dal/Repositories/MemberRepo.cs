using Chillify.Dal.Data;
using Chillify.Dal.Interfaces;

namespace Chillify.Dal.Repositories;

public class MemberRepo : IMemberRepo
{
    private readonly ChillContext _context;

    public MemberRepo(ChillContext context)
    {
        _context = context;
    }
    
    public List<Member> GetMembers()
    {
        return _context.Members.ToList();
    }
    public Member GetMember(string email)
    {
        Member member = _context.Members.SingleOrDefault(m => m.EmailAddress.ToLower().Equals(email.ToLower()));
        return member;
    }

    public Member GetMember(int id)
    {
        Member member = _context.Members.SingleOrDefault(m => m.Id == id);
        return member;
    }

    public int Add(Member member)
    {
        _context.Members.Add(member);
        _context.SaveChanges();

        return member.Id;
    }

    public bool EmailExist(string email)
    {
        return _context.Members.Any(m => m.EmailAddress.ToLower().Equals(email.ToLower()));
    }
    
    public bool PseudoExist(string pseudo)
    {
        return _context.Members.Any(m => m.Pseudo.ToLower().Equals(pseudo.ToLower()));
    }
}
