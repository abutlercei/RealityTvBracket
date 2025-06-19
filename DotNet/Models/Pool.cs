using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNet.Models;

public class Pool
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string SourceName { get; set; }
    public required string SourceLink { get; set; }
    // Navigation property
    [ForeignKey("HostFK")]
    [JsonIgnore]
    public UserProfile? UserProfile { get; set; }
    // Foreign Key
    public required string HostFK { get; set; }
    public string? Bio { get; set; }

    // Collection navigating dependent objects
    public ICollection<PoolMember> Members { get; } = []; // Navigation property
}