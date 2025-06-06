using Microsoft.AspNetCore.Mvc;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Data1", "Data2", "Data3" };
        }
    }
}