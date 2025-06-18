// using System.ComponentModel.DataAnnotations; // Used to delcare Date types
using System.ComponentModel.DataAnnotations;

namespace DotNet.Models;

public class Pool
{
    [Key]
    public required string Name { get; set; }
    public string? SourceName { get; set; }
    public string? SourceLink { get; set; }
    public string? Host { get; set; }
    public string? Bio { get; set; }
}