using DotNet.Models;
using DotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _service;
        public UserProfileController(IUserProfileService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(string id)
        {
            UserProfile? result = _service.GetUserProfile(id);
            return (result == null)
                ? new StatusCodeResult(404) // Returning not found status code, called in login functionality
                : new OkObjectResult(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] UserProfile prof)
        {
            bool success = _service.UpdateUserProfile(prof);
            return (!success) ?
                new BadRequestResult()
                : new OkResult();
        }
    }
}