using DotNet.Models;
using Microsoft.AspNetCore.Mvc;

public interface IDataRepository
{
    List<Pool> GetAllPools();
    Pool? GetPool(int id);
    IActionResult GetPoolMembershipsForUser(String username);
    UserProfile? GetUserProfile(String username);
    void UpdateUserProfile(UserProfile profile);
}