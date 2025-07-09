using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using AutoMapper;
using DotNet.Models;
using DotNet.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

public class PoolRepository : IPoolRepository
{
    private readonly SamplePoolDBContext _context;
    private readonly IMapper _mapper;
    private readonly IServiceScopeFactory _scopeFactory;
    public PoolRepository(SamplePoolDBContext context, IMapper mapper, IServiceScopeFactory scopeFactory)
    {
        _context = context;
        _mapper = mapper;
        _scopeFactory = scopeFactory;
    }

    public async Task<List<MemberTableViewModel>> GetAllMemberships(string username)
    {
        using var scope1 = _scopeFactory.CreateScope();
        using var scope2 = _scopeFactory.CreateScope();
        var context1 = scope1.ServiceProvider.GetRequiredService<SamplePoolDBContext>();
        var context2 = scope2.ServiceProvider.GetRequiredService<SamplePoolDBContext>();

        var poolMemTask = _mapper.ProjectTo<MemberTableViewModel>(
            context1.PoolMembers
                .Where(pm => pm.UsernameFK == username)
                .OrderBy(pm => pm.Rank))
            .ToListAsync();

        var bracketMemTask = _mapper.ProjectTo<MemberTableViewModel>(
            context2.BracketMembers
                .Where(bm => bm.UserFK == username)
                .OrderBy(bm => bm.PoolIdFK))
            .ToListAsync();

        var results = await Task.WhenAll(poolMemTask, bracketMemTask);

        return results[0].Concat(results[1]).ToList();
    }


    public List<MemberTableViewModel> GetAllMemberships(int id, bool isBracket)
    {
        List<MemberTableViewModel> result = [];
        if (isBracket)
        {
            result = _context.BracketMembers
                .Include(bm => bm.UserProfile)
                .Where(bm => bm.PoolIdFK == id)
                .GroupBy(bm => new { bm.UserFK, bm.UserProfile.Name })
                .Select(g => new MemberTableViewModel
                {
                    Name = g.Key.Name,
                    Contestant = $"{g.Count(x => x.IsCorrect == true)} / {g.Max(x => x.OrderOut)}",
                    Points = g.Sum(x => x.IsCorrect == true ? x.Points : 0)
                })
                .ToList()
                .OrderByDescending(x => x.Points)
                .Select((x, index) =>
                {
                    x.Rank = index + 1;
                    return x;
                })
                .ToList();
        }
        else
        {
            result = _mapper.ProjectTo<MemberTableViewModel>
                (_context.PoolMembers.Where(pm => pm.PoolNameFK == id).OrderBy(pm => pm.Rank), null)
            .ToList();
        }
        return result.OrderBy(m => m.Rank).ToList();
    }

    public async Task<List<PoolSearchResultViewModel>> GetAllPools()
    {
        return await _mapper.ProjectTo<PoolSearchResultViewModel>(_context.Pools, null).ToListAsync();
    }

    public SummaryViewModel GetSummaryViewModel(string id)
    {
        try
        {
            SummaryViewModel summary = new SummaryViewModel();
            List<Pool> pools = _context.Pools
                .Include(p => p.Members).Include(p => p.Brackets)
                .Where(p => p.Members.Any(m => m.UsernameFK == id)
                || p.Brackets.Any(b => b.UserFK == id)).OrderBy(p => p.Id).ToList();
            return summary.MapToSummaryViewModel(pools, id);
        }
        catch (Exception e)
        {
            throw new Exception("Failure to query and map summary.", e);
        }
    }

    public Pool? GetPool(int id)
    {
        return _context.Pools.Find(id);
    }

}