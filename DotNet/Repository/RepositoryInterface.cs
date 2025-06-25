using DotNet.Models;
using DotNet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

public interface IDataRepository
{
    List<MemberTableViewModel> GetAllMemberships(String username);
    List<Pool> GetAllPools();
    Pool? GetPool(int id);
    IActionResult GetPoolMembershipsForUser(String username);
    UserProfile? GetUserProfile(String username);
    void UpdateUserProfile(UserProfile profile);
}