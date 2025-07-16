using System.Net;
using System.Threading.Tasks;
using DotNet.Models;
using DotNet.Models.ViewModels;
using DotNet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public IActionResult Get(int id)
        {
            SinglePoolViewModel result = _service.GetPoolView(id);
            return (result.Pool == null) ?
                new BadRequestResult()
                : new OkObjectResult(result);
        }

        [HttpGet("summary/{id}")]
        public IActionResult GetSummary(string id)
        {
            SummaryViewModel vm = _service.GetSummaryViewModel(id);
            return vm == null ? new StatusCodeResult(404) : new OkObjectResult(vm); // Returns not found status since a null object indicates error finding in database
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<PoolSearchResultViewModel> result = await _service.GetAllPools();
            return (result.Count == 0) ?
                new StatusCodeResult(500) // Returns internal server error since database has pre-populated objs
                : new OkObjectResult(result);
        }
    }
}