namespace Chillify.Dal.Interfaces;

public interface IMemberRepo
{
    Member GetMember(string email);
    bool EmailExist(string email);
    bool PseudoExist(string pseudo);
    int Add(Member member);
}
