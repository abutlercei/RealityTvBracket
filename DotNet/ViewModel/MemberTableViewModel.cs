namespace DotNet.Models.ViewModels
{
    public class MemberTableViewModel
    {
        public required string Name { get; set; }
        public string? UserPreferredName { get; set; }
        public string? Contestant { get; set; }
        public int? Rank { get; set; }
        public int? Points { get; set; }
    }
}