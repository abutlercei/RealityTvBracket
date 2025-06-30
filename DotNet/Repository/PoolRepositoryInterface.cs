using DotNet.Models;
using DotNet.Models.ViewModels;

public interface IPoolRepository
{
    List<MemberTableViewModel> GetAllMemberships(String username);
    List<MemberTableViewModel> GetAllMemberships(int id, bool isBracket);
    List<PoolSearchResultViewModel> GetAllPools();
    Pool? GetPool(int id);
}