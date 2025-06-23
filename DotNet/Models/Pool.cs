// using System.ComponentModel.DataAnnotations; // Used to delcare Date types
namespace DotNet.Models;

public class Pool
{
    public required string Name { get; set; }
    public string? SourceName { get; set; }
    public string? SourceLink { get; set; }
    public string? Host { get; set; }
    public string? Bio { get; set; }
}