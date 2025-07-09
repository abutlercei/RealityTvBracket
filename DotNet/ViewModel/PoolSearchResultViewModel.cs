namespace DotNet.Models.ViewModels
{
    public class PoolSearchResultViewModel
    {
        public required int PoolId { get; set; }
        public required string PoolName { get; set; }
        public required string SourceName { get; set; }
        public required string HostUsername { get; set; }
    }
}