// using System.ComponentModel.DataAnnotations; // Used to delcare Date types
using System.ComponentModel.DataAnnotations;

namespace DotNet.Models;

public class PoolMember
{
    [Key]
    public required string Username { get; set; }
    [Key]
    public required string PoolName { get; set; }
    public int? Rank { get; set; }
    public int? Points { get; set; }
    public string? Contestant { get; set; }
}