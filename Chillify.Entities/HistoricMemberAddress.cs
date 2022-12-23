
using System.ComponentModel.DataAnnotations.Schema;

namespace Chillify.Entities;

[Table("HistoricMemberAddress")]
public class HistoricMemberAddress
{
    public int HistoricMemberId { get; set; }
    public HistoricMember HistoricMember { get; set; }
    public int HistoricAddressId { get; set; }
    public HistoricAddress HistoricAddress { get; set; }
}
