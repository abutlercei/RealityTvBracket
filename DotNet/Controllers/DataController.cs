using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Data.Sqlite;
using DotNet.Models;
using System.Text.Json;

// Will be split into separate controllers within resolved pull request!
// Kept to see class definitions for transfer
namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataRepository _repository;
        public DataController(IDataRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Get(string queryType, string searchValue)
        {
            // Console.WriteLine(queryType);
            switch (queryType)
            {
                case "getProfile":
                    return GetProfile(searchValue);
                case "updateUser":
                    UpdateUser(searchValue);
                    return Ok();
                case "getUserMemberships":
                    return GetUserMemberships(searchValue);
                default:
                    break;
            }

            return NotFound();
        }

        private IActionResult GetProfile(string user)
        {
            return _repository.GetUserProfile(user);
        }

        private void UpdateUser(string user)
        {
            // Use HttpPost with [FromBody] UserProfile prof to receive data from json
            // For now, user is json that will be parsed from body
            UserProfile? userJson = JsonConvert.DeserializeObject<UserProfile>(user);
#pragma warning disable CS8604 // Possible null reference argument.
            _repository.UpdateUserProfile(userJson);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        private IActionResult GetUserMemberships(String username)
        {
            return _repository.GetPoolMembershipsForUser(username);
        }

        // Call within Home component
        private void GetHomeObjects()
        {
            // Returns objects associated with user if logged in
            // Returns general objects if logged out
        }

        // Call within profile when page loads or when user presses search button
        private void GetSearchResults()
        {
            // Returns rows of Pools & Pool Members associated with search results
        }
    }
}