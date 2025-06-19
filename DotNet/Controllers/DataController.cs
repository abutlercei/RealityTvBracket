using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Data.Sqlite;
using DotNet.Models;

// Will be split into separate controllers within resolved pull request!
// Kept to see class definitions for transfer
namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly DataRepository _repository;
        public DataController(DataRepository repository)
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
                    return Ok(GetUserMemberships(searchValue));
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
            // String[] updateArr = user.Split('/');
            // for (int i = 0; i < updateArr.Length; i += 3)
            // {
            //     using (var connection = new SqliteConnection($"Data Source=sample_pools.db"))
            //     {
            //         connection.Open();

            //         var command = connection.CreateCommand();
            //         command.CommandText =
            //         @$"UPDATE UserProfile SET {updateArr[i]} = '{updateArr[i + 1]}' 
            //         WHERE username = '{updateArr[i + 2]}' OR username = '{updateArr[i + 1]}';";
            //         command.ExecuteNonQuery();

            //         connection.Close();
            //     }
            // }
        }

        private string GetUserMemberships(String username)
        {
            List<PoolMember> poolObj = [];
            // using (var connection = new SqliteConnection($"Data Source=sample_pools.db"))
            // {
            //     connection.Open();

            //     var command = connection.CreateCommand();
            //     command.CommandText = @$"SELECT pool_name AS 'Name', contestant as 'Contestant', rank_num as 'Rank', 
            //         points as 'Points' FROM PoolMembers WHERE username = '{username}' ORDER BY pool_name;";

            //     using (var reader = command.ExecuteReader())
            //     {
            //         while (reader.Read())
            //         {
            //             PoolMember pool = new()
            //             {
            //                 Username = username,
            //                 PoolName = reader.GetString(0),
            //                 Contestant = reader.GetString(1),
            //                 Rank = reader.GetInt32(2),
            //                 Points = reader.GetInt32(3),
            //             };
            //             poolObj.Add(pool);
            //         }
            //     }

            //     connection.Close();
            // }
            return JsonConvert.SerializeObject(poolObj);
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