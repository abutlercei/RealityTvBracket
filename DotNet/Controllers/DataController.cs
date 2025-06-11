using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Data.Sqlite;
using DotNet.Models;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public string Get(string queryType, string searchValue)
        {
            // Console.WriteLine(queryType);
            switch (queryType)
            {
                case "getProfile":
                    return GetProfile(searchValue);
                case "updateUser":
                    UpdateUser(searchValue);
                    break;
                default:
                    break;
            }

            return "";
        }

        private string GetProfile(string user)
        {
            List<UserProfile> userObjects = [];
            using (var connection = new SqliteConnection($"Data Source=sample_pools.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT name, username, password FROM UserProfile WHERE username = '{user}'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserProfile profile = new()
                        {
                            Name = reader.GetString(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                        };
                        userObjects.Add(profile);
                    }
                }

                connection.Close();
            }
            return JsonConvert.SerializeObject(userObjects);
        }

        private void UpdateUser(string user)
        {
            String[] updateArr = user.Split('/');
            for (int i = 0; i < updateArr.Length; i += 3)
            {
                using (var connection = new SqliteConnection($"Data Source=sample_pools.db"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                    $"UPDATE UserProfile SET {updateArr[i]} = '{updateArr[i + 1]}' WHERE username = '{updateArr[i + 2]}' OR username = '{updateArr[i+ 1]}';";
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
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