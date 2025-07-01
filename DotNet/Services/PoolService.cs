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

        public async Task<SinglePoolViewModel> GetPoolView(int id)
        {
            Pool? pool = _repository.GetPool(id);
            List<MemberTableViewModel> memTable = await _repository.GetAllMemberships(id);
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
    }
}