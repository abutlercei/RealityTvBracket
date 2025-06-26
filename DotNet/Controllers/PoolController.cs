using DotNet.Models;
using DotNet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoolController : ControllerBase
    {
        private readonly IPoolRepository _repository;
        public PoolController(IPoolRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Pool? pool = _repository.GetPool(id);
            if (pool != null)
            {
                List<MemberTableViewModel> memTable = _repository.GetAllMemberships(pool.Id);
                return new OkObjectResult(new SinglePoolViewModel
                {
                    Pool = pool,
                    MemberTables = memTable
                });
            }
            return new BadRequestResult();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            List<PoolSearchResultViewModel> result = _repository.GetAllPools();
            if (result.Count == 0)
            {
                return new BadRequestResult();
            }
            return new OkObjectResult(result);
        }
    }
}