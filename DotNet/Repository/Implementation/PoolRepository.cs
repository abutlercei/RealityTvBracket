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
        var poolMemTask = await _mapper.ProjectTo<MemberTableViewModel>(
            _context.PoolMembers
                .Include(pm => pm.Pool)
                .Where(pm => pm.UsernameFK == username)
                .OrderBy(pm => pm.Rank))
            .ToListAsync();

        var bracketMemTask = await _mapper.ProjectTo<MemberTableViewModel>(
            _context.BracketMembers
                .Include(bm => bm.Pool)
                .Where(bm => bm.UserFK == username)
                .OrderBy(bm => bm.PoolIdFK))
            .ToListAsync();

        return poolMemTask.Concat(bracketMemTask).ToList();
    }

    public List<MemberTableViewModel> GetAllMemberships(int id, bool isBracket)
    {
        List<MemberTableViewModel> result = [];
        if (isBracket)
        {
            result = _context.BracketMembers
                .Include(bm => bm.UserProfile).Where(bm => bm.PoolIdFK == id)
                .GroupBy(bm => new { bm.UserFK, bm.UserProfile.Name })
                .Select(g => new MemberTableViewModel
                {
                    Name = g.Key.UserFK,
                    UserPreferredName = g.Key.Name,
                    Contestant = $"{g.Count(x => x.IsCorrect == true)} / {g.Max(x => x.OrderOut)}",
                    Points = g.Sum(x => x.IsCorrect == true ? x.Points : 0)
                })
                .ToList().OrderByDescending(x => x.Points)
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
                (_context.PoolMembers.Include(bm => bm.UserProfile).Where(pm => pm.PoolNameFK == id).OrderBy(pm => pm.Rank), null)
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

    public List<PoolSearchResultViewModel> GetSearchResult(string input)
    {
        List<PoolSearchResultViewModel> result = _mapper.ProjectTo<PoolSearchResultViewModel>(_context.Pools.Include(p => p.UserProfile)
            .Where(p => p.HostFK.Contains(input) || p.Name.Contains(input) || p.SourceName.Contains(input)), null).ToList();
        return result;
    }

    public Pool? GetPool(int id)
    {
        return _context.Pools.Find(id);
    }

}