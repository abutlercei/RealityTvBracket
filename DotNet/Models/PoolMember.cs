// using System.ComponentModel.DataAnnotations; // Used to delcare Date types
namespace DotNet.Models;

public class PoolMember
{
    public string? Name { get; set; }
    public required string Username { get; set; }
    public required string PoolName { get; set; }
    public int? RankNum { get; set; }
    public int? Points { get; set; }
    public string? Contestant { get; set; }
}