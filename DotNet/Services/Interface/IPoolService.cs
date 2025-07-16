using DotNet.Models.ViewModels;
using DotNet.Models;

namespace DotNet.Services
{
    public interface IPoolService
    {
        public Task<List<PoolSearchResultViewModel>> GetAllPools();
        public SinglePoolViewModel GetPoolView(int id);
        public SummaryViewModel GetSummaryViewModel(string id);
    }
}