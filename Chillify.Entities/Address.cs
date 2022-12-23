
using System.ComponentModel.DataAnnotations.Schema;

namespace Chillify.Entities;

[Table("Address")]
public class Address
{
    public int Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public ICollection<MemberAddress> MemberAddresses { get; set; }
}
