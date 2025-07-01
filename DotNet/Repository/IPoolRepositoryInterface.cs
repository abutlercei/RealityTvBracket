using DotNet.Models;
using DotNet.Models.ViewModels;

public interface IPoolRepository
{
    Task<List<MemberTableViewModel>> GetAllMemberships(String username);
    Task<List<MemberTableViewModel>> GetAllMemberships(int id);
    Task<List<PoolSearchResultViewModel>> GetAllPools();
    Pool? GetPool(int id);
}