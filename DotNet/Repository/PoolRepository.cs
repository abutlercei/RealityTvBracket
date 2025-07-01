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