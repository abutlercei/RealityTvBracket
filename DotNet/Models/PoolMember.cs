using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNet.Models
{
    public class PoolMember
    {
        // Foreign key
        public required string UsernameFK { get; set; }

        // Navigation property
        [ForeignKey("UsernameFK")]
        [JsonIgnore]
        public UserProfile? UserProfile { get; set; }

        // Foreign key
        public required int PoolNameFK { get; set; }

        // Navigation property
        [ForeignKey("PoolNameFK")]
        [JsonIgnore]
        public Pool? Pool { get; set; }

        public int? Rank { get; set; }
        public int? Points { get; set; }
        public string? Contestant { get; set; }
    }
}