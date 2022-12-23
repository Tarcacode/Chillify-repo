using System.ComponentModel.DataAnnotations.Schema;

namespace Chillify.Entities;

[Table("HistoricMember")]
public class HistoricMember
{
    public int Id { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public string Pseudo { get; set; } = string.Empty;
    public string PswdHash { get; set; } = string.Empty;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public int RoleId { get; set; } = 1;
    public Role Role { get; set; }
    public ICollection<HistoricMemberAddress> HistoricMemberAddresses { get; set; }
}
