// using System.ComponentModel.DataAnnotations; // Used to delcare Date types
namespace DotNet.Models;

public class PoolMember
{
    public required string Username { get; set; }
    public required string Name { get; set; }
    public int? Rank { get; set; }
    public int? Points { get; set; }
    public string? Contestant { get; set; }
}