using DotNet.Models;
using DotNet.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

public class PoolRepository : IPoolRepository
{
    private readonly SamplePoolDBContext _context;
    public PoolRepository(SamplePoolDBContext context)
    {
        _context = context;
    }

    public List<MemberTableViewModel> GetAllMemberships(String username)
    {
        List<MemberTableViewModel> result = [];
        List<PoolMember> mems = _context.PoolMembers.Include(pm => pm.Pool).Where(pm => pm.UsernameFK == username).ToList();

        foreach (PoolMember mem in mems)
        {
            if (mem.Pool != null)
            {
                result.Add(
                    new MemberTableViewModel
                    {
                        Name = mem.Pool.Name,
                        Contestant = mem.Contestant,
                        Rank = mem.Rank,
                        Points = mem.Points
                    }
                );
            }
        }
        return result;
    }

    public List<MemberTableViewModel> GetAllMemberships(int id)
    {
        List<MemberTableViewModel> result = [];
        List<PoolMember> mems = _context.PoolMembers.Include(pm => pm.UserProfile).Where(pm => pm.PoolNameFK == id).OrderBy(pm => pm.Rank).ToList();

        foreach (PoolMember mem in mems)
        {
            if (mem.UserProfile != null)
            {
                result.Add(
                    new MemberTableViewModel
                    {
                        Name = mem.UsernameFK,
                        UserPreferredName = mem.UserProfile.Name,
                        Contestant = mem.Contestant,
                        Rank = mem.Rank,
                        Points = mem.Points
                    }
                );
            }
        }
        return result;
    }

    public List<PoolSearchResultViewModel> GetAllPools()
    {
        List<PoolSearchResultViewModel> result = [];
        List<Pool> pools = _context.Pools.OrderBy(p => p.SourceName).ToList();

        foreach (Pool pool in pools)
        {
            result.Add(new PoolSearchResultViewModel
            {
                PoolId = pool.Id,
                PoolName = pool.Name,
                SourceName = pool.SourceName,
                HostUsername = pool.HostFK
            });
        }
        return result;
    }

    public Pool? GetPool(int id)
    {
        return _context.Pools.Find(id);
    }

}