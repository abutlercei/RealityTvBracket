using DotNet.Models;
using DotNet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Repository : IDataRepository
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly SamplePoolDBContext _context;
    public Repository(IServiceScopeFactory scopeFactory, SamplePoolDBContext context)
    {
        _scopeFactory = scopeFactory;
        _context = context;
    }

    public List<MemberTableViewModel> GetAllMemberships(String username)
    {
        List<MemberTableViewModel> result = [];
        List<PoolMember> mems = _context.PoolMembers.Where(pm => pm.UsernameFK == username).ToList();

        foreach (PoolMember mem in mems)
        {
            Pool? pool = GetPool(mem.PoolNameFK);
            if (pool != null)
            {
                result.Add(
                    new MemberTableViewModel
                    {
                        Name = pool.Name,
                        Contestant = mem.Contestant,
                        Rank = mem.Rank,
                        Points = mem.Points
                    }
                );
            }
        }
        return result;
    }

    public List<Pool> GetAllPools()
    {
        List<Pool> pools = _context.Pools.OrderBy(p => p.SourceName).ToList();
        return pools;
    }

    public Pool? GetPool(int id)
    {
        return _context.Pools.Find(id);
    }

    public IActionResult GetPoolMembershipsForUser(String username)
    {
        IActionResult result = new BadRequestResult();

        List<PoolMember> poolMems = _context.PoolMembers.Where(pm => pm.UsernameFK == username).ToList();
        List<Object> returnObjs = [.. poolMems];

        foreach (PoolMember p in poolMems)
        {
            Pool? pool = _context.Pools.Find(p.PoolNameFK);
            if (pool != null)
            {
                returnObjs.Add(pool);
            }
        }

        result = new OkObjectResult(returnObjs);
        return result;
    }

    public UserProfile? GetUserProfile(string username)
    {
        return _context.UserProfiles.Find(username);
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

        await context.SaveChangesAsync();
    }
}