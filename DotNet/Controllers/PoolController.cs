using System.Threading.Tasks;
using DotNet.Models;
using DotNet.Models.ViewModels;
using DotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoolController : ControllerBase
    {
        private readonly IPoolService _service;
        public PoolController(IPoolService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            SinglePoolViewModel result = await _service.GetPoolView(id);
            return (result.Pool == null) ?
                new BadRequestResult()
                : new OkObjectResult(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<PoolSearchResultViewModel> result = await _service.GetAllPools();
            return (result.Count == 0) ?
                new BadRequestResult()
                : new OkObjectResult(result);
        }
    }
}