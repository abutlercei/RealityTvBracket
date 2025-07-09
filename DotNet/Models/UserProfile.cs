using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNet.Models
{
    public class UserProfile
    {
        [Key]
        public required string Username { get; set; }
        public required string Name { get; set; }
        [DefaultValue("password")]
        public required string Password { get; set; }

        // Collections navigating dependent objects
        public ICollection<Pool> Pools { get; } = []; // Navigation property
        public ICollection<PoolMember> Members { get; } = []; // Navigation property
    }
}