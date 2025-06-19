// using System.ComponentModel.DataAnnotations; // Used to delcare Date types
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.Models;

public class PoolMember
{
    // Foreign key
    public required string UsernameFK { get; set; }

    // Navigation property
    [ForeignKey("UsernameFK")]
    public UserProfile? UserProfile { get; set; }

    // Foreign key
    public required int PoolNameFK { get; set; }

    // Navigation property
    [ForeignKey("PoolNameFK")]
    public Pool? Pool { get; set; }

    public int? Rank { get; set; }
    public int? Points { get; set; }
    public string? Contestant { get; set; }
}