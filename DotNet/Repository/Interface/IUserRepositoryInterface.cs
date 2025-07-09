using DotNet.Models;

public interface IUserRepository
{
    UserProfile? GetUserProfile(String username);
    void UpdateUserProfile(UserProfile profile);
}