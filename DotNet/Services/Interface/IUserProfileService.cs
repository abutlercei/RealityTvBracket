using DotNet.Models;

namespace DotNet.Services
{
    public interface IUserProfileService
    {
        UserProfile? GetUserProfile(string id);
        bool UpdateUserProfile(UserProfile profile);
    }
}