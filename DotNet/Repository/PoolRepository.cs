using System.Threading.Tasks;
using AutoMapper;
using DotNet.Models;
using DotNet.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

public class PoolRepository : IPoolRepository
{
    private readonly SamplePoolDBContext _context;
    private readonly IMapper _mapper;
    public PoolRepository(SamplePoolDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MemberTableViewModel>> GetAllMemberships(String username)
    {
        return await _mapper
            .ProjectTo<MemberTableViewModel>
                (_context.PoolMembers.Where(pm => pm.UsernameFK == username))
            .ToListAsync();
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
    public async Task<List<MemberTableViewModel>> GetAllMemberships(int id)
    {
        return await _mapper
            .ProjectTo<MemberTableViewModel>
                (_context.PoolMembers.Where(pm => pm.PoolNameFK == id).OrderBy(pm => pm.Rank), null)
            .ToListAsync();
    }

    public async Task<List<PoolSearchResultViewModel>> GetAllPools()
    {
        return await _mapper.ProjectTo<PoolSearchResultViewModel>(_context.Pools, null).ToListAsync();
    }

    public Pool? GetPool(int id)
    {
        return _context.Pools.Find(id);
    }

}