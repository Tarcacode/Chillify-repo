namespace Chillify.Dal.Interfaces;

public interface IMemberRepo
{
    List<Member> GetMembers();
    Member GetMemberByEmail(string email);
    Member GetMemberById(int id);
    bool EmailExist(string email);
    bool PseudoExist(string pseudo);
    int Add(Member member);
}
