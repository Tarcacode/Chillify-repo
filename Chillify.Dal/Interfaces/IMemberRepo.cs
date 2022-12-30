namespace Chillify.Dal.Interfaces;

public interface IMemberRepo
{
    List<Member> GetMembers();
    Member GetMember(string email);
    Member GetMember(int id);
    bool EmailExist(string email);
    bool PseudoExist(string pseudo);
    int Add(Member member);
}
