using Microsoft.AspNetCore.Mvc;
using DotNet.Models.ViewModels;

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
            return new OkObjectResult(_repository.GetAllMemberships(id));
        }
    }
}