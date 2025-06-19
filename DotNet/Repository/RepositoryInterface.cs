using DotNet.Models;
using Microsoft.AspNetCore.Mvc;

public interface DataRepository
{
    // Commented out to resolve errors within implementation of interface
    
    // PoolMember GetPoolMember(String username);
    IActionResult GetUserProfile(String username);
    // void UpdateUserProfile(UserProfile profile);
}