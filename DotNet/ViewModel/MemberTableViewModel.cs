namespace DotNet.Models.ViewModels
{
    public class MemberTableViewModel
    {
        public string? Name { get; set; }
        public string? UserPreferredName { get; set; }
        public string? Contestant { get; set; }
        public int? Rank { get; set; }
        public int? Points { get; set; }
        public int? OrderOut { get; set; }
        public Boolean? IsCorrect { get; set; }
        public string? PoolName { get; set; }
    }
}