using DotNet.Models;
using DotNet.Models.ViewModels;

public interface IPoolRepository
{
    Task<List<MemberTableViewModel>> GetAllMemberships(String username);
    List<MemberTableViewModel> GetAllMemberships(int id, bool isBracket);
    Task<List<PoolSearchResultViewModel>> GetAllPools();
    Pool? GetPool(int id);
}