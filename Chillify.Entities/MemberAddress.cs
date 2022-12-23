
using System.ComponentModel.DataAnnotations.Schema;

namespace Chillify.Entities;

[Table("MemberAddress")]
public class MemberAddress
{
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
}
