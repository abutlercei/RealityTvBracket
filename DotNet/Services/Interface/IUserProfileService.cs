using DotNet.Models;

namespace DotNet.Services
{
    public interface IUserProfileService
    {
        UserProfile? GetUserProfile(string id);
        bool FindUserProfile(LoginModel model);
        bool UpdateUserProfile(UserProfile profile);
    }
}