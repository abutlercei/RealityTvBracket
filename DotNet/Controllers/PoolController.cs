using Microsoft.AspNetCore.Mvc;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoolController : ControllerBase
    {
        private readonly IDataRepository _repository;
        public PoolController(IDataRepository repository)
        {
            _repository = repository;
        }
    }
}