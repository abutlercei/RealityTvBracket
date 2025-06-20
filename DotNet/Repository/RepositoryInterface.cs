using DotNet.Models;
using Microsoft.AspNetCore.Mvc;

public interface IDataRepository
{
    IActionResult GetPoolMembershipsForUser(String username);
    IActionResult GetUserProfile(String username);
    void UpdateUserProfile(UserProfile profile);
}