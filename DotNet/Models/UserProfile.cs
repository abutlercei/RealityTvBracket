using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DotNet.Models;

public class UserProfile
{
    [Key]
    public required string Username { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
}