using Microsoft.AspNetCore.Mvc;
using DotNet.Models.ViewModels;

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
        public IActionResult GetProfile(string id)
        {
            return new OkObjectResult(_repository.GetAllMemberships(id));
        }
    }
}