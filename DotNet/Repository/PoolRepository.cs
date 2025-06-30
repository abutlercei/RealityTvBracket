using System.Runtime.Intrinsics.X86;
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

    public List<MemberTableViewModel> GetAllMemberships(int id, bool isBracket)
    {
        List<MemberTableViewModel> result = [];
        if (isBracket)
        {
            List<IGrouping<string, BracketMember>> mems = _context.BracketMembers
                .Include(bm => bm.UserProfile).Where(bm => bm.PoolIdFK == id).GroupBy(bm => bm.UserFK).ToList();
            List<MemberTableViewModel> rankings = mems.Select(memberRank => new MemberTableViewModel
            {
                Name = memberRank.Key,
                Rank = mems.Count(bm2 => bm2.Sum(points => points.IsCorrect == true ? points.Points : 0) > memberRank.Sum(points => points.IsCorrect == true ? points.Points : 0)) + 1
            }).ToList();

            foreach (var grouping in mems)
            {
                result.Add(new MemberTableViewModel
                {
                    Name = grouping.Key,
                    Contestant = $"{grouping.Count(count => count.IsCorrect == true)} / {grouping.Max(value => value.OrderOut)}",
                    Points = grouping.Sum(value => value.IsCorrect == true ? value.Points : 0),
                    Rank = rankings.FirstOrDefault(r => r.Name == grouping.Key).Rank
                });
            }
        }
        else
        {
            List<PoolMember> mems = _context.PoolMembers.Where(pm => pm.PoolNameFK == id).OrderBy(pm => pm.Rank).ToList();
            foreach (PoolMember mem in mems)
            {
                UserProfile? prof = _context.UserProfiles.Find(mem.UsernameFK);
                if (prof != null)
                {
                    result.Add(
                        new MemberTableViewModel
                        {
                            Name = mem.UsernameFK,
                            UserPreferredName = prof.Name,
                            Contestant = mem.Contestant,
                            Rank = mem.Rank,
                            Points = mem.Points
                        }
                    );
                }
            }
        }
        return result.OrderBy(m => m.Rank).ToList();
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