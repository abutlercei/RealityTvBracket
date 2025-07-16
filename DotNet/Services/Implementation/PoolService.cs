using DotNet.Models;
using DotNet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Services
{
    public class PoolService : IPoolService
    {
        private readonly IPoolRepository _repository;
        public PoolService(IPoolRepository repository)
        {
            _repository = repository;
        }

        public SinglePoolViewModel GetPoolView(int id)
        {
            Pool? pool = _repository.GetPool(id);
            if (pool == null)
            {
                return new SinglePoolViewModel();
            }
            List<MemberTableViewModel> memTable = _repository.GetAllMemberships(id, pool.IsBracketStyle);
            return new SinglePoolViewModel
            {
                Pool = pool,
                MemberTables = memTable
            };
        }

        public async Task<List<PoolSearchResultViewModel>> GetAllPools()
        {
            return await _repository.GetAllPools();
        }

        public SummaryViewModel GetSummaryViewModel(string id)
        {
            return _repository.GetSummaryViewModel(id);
        }

        public List<PoolSearchResultViewModel> GetSearchResult(string input)
        {
            return _repository.GetSearchResult(input);
        }
    }
}