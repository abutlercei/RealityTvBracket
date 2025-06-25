using DotNet.Models;
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
            Pool? result = _repository.GetPool(id);
            if (result == null)
            {
                return new BadRequestResult();
            }
            return new OkObjectResult(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            List<Pool> result = _repository.GetAllPools();
            if (result.Count == 0)
            {
                return new BadRequestResult();
            }
            return new OkObjectResult(result);
        }
    }
}