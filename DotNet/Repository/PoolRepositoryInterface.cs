using DotNet.Models;
using DotNet.Models.ViewModels;

public interface IPoolRepository
{
    List<MemberTableViewModel> GetAllMemberships(String username);
    List<Pool> GetAllPools();
    Pool? GetPool(int id);
}