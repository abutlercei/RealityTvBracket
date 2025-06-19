using DotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IDataRepository _repository;
        public UserProfileController(IDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(string id)
        {
            return _repository.GetUserProfile(id);
        }

        [HttpPost("update")]
        public IActionResult UpdateUser([FromBody] UserProfile prof)
        {
            if (prof == null)
            {
                return new BadRequestResult();
            }

            _repository.UpdateUserProfile(prof);
            return new OkResult();
        }
    }
}