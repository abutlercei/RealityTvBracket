using Microsoft.AspNetCore.Mvc;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoolMemberController : ControllerBase
    {
        private readonly IDataRepository _repository;
        public PoolMemberController(IDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(string id)
        {
            return _repository.GetPoolMembershipsForUser(id);
        }
    }
}