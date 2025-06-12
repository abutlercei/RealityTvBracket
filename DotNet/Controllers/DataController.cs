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
            switch (queryType)
            {
                case "getProfile": // Called in Profile component
                    return GetProfile(searchValue);
                case "updateUser": // Called in Profile component
                    UpdateUser(searchValue);
                    break;
                case "getUserMemberships": // Called in Profile component
                    return GetUserMemberships(searchValue);
                case "getAllPools": // Called in Search component
                    return GetAllPools();
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
                    @$"UPDATE UserProfile SET {updateArr[i]} = '{updateArr[i + 1]}' 
                    WHERE username = '{updateArr[i + 2]}' OR username = '{updateArr[i+ 1]}';";
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        private string GetUserMemberships(String username)
        {
            List<PoolMember> poolObj = [];
            using (var connection = new SqliteConnection($"Data Source=sample_pools.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @$"SELECT pool_name AS 'Name', contestant as 'Contestant', rank_num as 'Rank', 
                    points as 'Points' FROM PoolMembers WHERE username = '{username}' ORDER BY pool_name;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PoolMember pool = new()
                        {
                            Username = username,
                            Name = reader.GetString(0),
                            Contestant = reader.GetString(1),
                            Rank = reader.GetInt32(2),
                            Points = reader.GetInt32(3),
                        };
                        poolObj.Add(pool);
                    }
                }

                connection.Close();
            }
            return JsonConvert.SerializeObject(poolObj);
        }

        private string GetAllPools()
        {
            List<Pool> poolObj = [];
            using (var connection = new SqliteConnection($"Data Source=sample_pools.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @$"SELECT name, source_name, source_link, host, bio
                                        FROM Pool ORDER BY source_name, name";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pool pool = new()
                        {
                            Name = reader.GetString(0),
                            SourceName = reader.GetString(1),
                            SourceLink = reader.GetString(2),
                            Host = reader.GetString(3),
                            Bio = reader.GetString(4)
                        };
                        poolObj.Add(pool);
                    }
                }

                connection.Close();
            }
            return JsonConvert.SerializeObject(poolObj);
        }

        // Returns pool selected by user
        private string GetPoolInfo()
        {
            // Returns pool members associated with table given
            return "";
        }

        // Call within Home component
        private void GetHomeObjects()
        {
            // Returns objects associated with user if logged in
            // Returns general objects if logged out
        }
    }
}