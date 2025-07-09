using Microsoft.AspNetCore.Mvc;
using DotNet.Models.ViewModels;
using System.Threading.Tasks;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoolMemberController : ControllerBase
    {
        private readonly IPoolRepository _repository;
        public PoolMemberController(IPoolRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(string id)
        {
            return new OkObjectResult(await _repository.GetAllMemberships(id));
        }
    }
}