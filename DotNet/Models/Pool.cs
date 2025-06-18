// using System.ComponentModel.DataAnnotations; // Used to delcare Date types
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public required UserProfile UserProfile { get; set; }
    // Foreign Key
    public required string HostFK { get; set; }
    public string? Bio { get; set; }

    // Collection navigating dependent objects
    public ICollection<PoolMember> Members { get; } = []; // Navigation property
}