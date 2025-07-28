using DotNet.Models;

public interface IUserRepository
{
    UserProfile? GetUserProfile(String username);
    bool FindUserProfile(LoginModel model);
    void UpdateUserProfile(UserProfile profile);
}