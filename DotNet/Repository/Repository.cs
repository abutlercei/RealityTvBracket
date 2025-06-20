using DotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Repository : IDataRepository
{
    private readonly IServiceScopeFactory _scopeFactory;
    public Repository(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public IActionResult GetPoolMembershipsForUser(String username)
    {
        IActionResult result = new BadRequestResult();
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SamplePoolDBContext>();

            List<PoolMember> poolMems = context.PoolMembers.Where(pm => pm.UsernameFK == username).ToList();
            List<Object> returnObjs = [.. poolMems];

            foreach (PoolMember p in poolMems)
            {
                Pool? pool = context.Pools.Find(p.PoolNameFK);
                if (pool != null)
                {
                    returnObjs.Add(pool);
                }
            }

            result = new OkObjectResult(returnObjs);
        }
        return result;
    }

    public IActionResult GetUserProfile(string username)
    {
        IActionResult result = new BadRequestResult();
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SamplePoolDBContext>();
            UserProfile? user = context.UserProfiles.Find(username);
            if (user != null)
            {
                result = new OkObjectResult(user);
            }
        }
        return result;
    }

    public async void UpdateUserProfile(UserProfile profile)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
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

            await context.SaveChangesAsync();
        }
    }
}