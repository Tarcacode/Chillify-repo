using System.ComponentModel.DataAnnotations.Schema;

namespace Chillify.Entities;

[Table("Role")]
public class Role
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}
