using DotNet.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly SamplePoolDBContext _context;
    public UserRepository(IServiceScopeFactory scopeFactory, SamplePoolDBContext context)
    {
        _scopeFactory = scopeFactory;
        _context = context;
    }

    public UserProfile? GetUserProfile(string username)
    {
        return _context.UserProfiles.Find(username);
    }

    public bool FindUserProfile(LoginModel model)
    {
        return _context.UserProfiles.Find(model.Username) != null &&
            _context.UserProfiles.Find(model.Username).Password == model.Password;
    }

    public async void UpdateUserProfile(UserProfile profile)
    {
        var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SamplePoolDBContext>();
        var user = await context.UserProfiles.SingleOrDefaultAsync(
            u => u.Username == profile.Username
        );
        if (user == null) return;

        Dictionary<String, object> updated = [];
        if (profile.Name != user.Name)
        {
            updated.Add("Name", profile.Name);
        }
        if (profile.Password != user.Password)
        {
            updated.Add("Password", profile.Password);
        }

        var entry = context.Entry(user);
        foreach (var field in updated)
        {
            if (entry.Property(field.Key) != null)
            {
                entry.Property(field.Key).CurrentValue = field.Value;
                entry.Property(field.Key).IsModified = true;
            }
        }
        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to run database updated. {e}");
        }
    }
}