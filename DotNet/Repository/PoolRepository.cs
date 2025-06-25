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

}