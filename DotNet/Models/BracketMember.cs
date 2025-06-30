using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNet.Models
{
    public class BracketMember
    {
        // Foreign Key
        public required string UserFK { get; set; }
        [ForeignKey("UserFK")] // Navigation property
        [JsonIgnore]
        public UserProfile? UserProfile { get; set; }
        // Foreign Key
        public required int PoolIdFK { get; set; }
        [ForeignKey("PoolIdFK")] // Navigation property
        [JsonIgnore]
        public Pool? Pool { get; set; }
        public required int OrderOut { get; set; }
        public string? Contestant { get; set; }
        public int? Points { get; set; }
        public bool? IsCorrect { get; set; }
    }
}