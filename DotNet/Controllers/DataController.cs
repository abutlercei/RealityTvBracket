using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            const string dbFile = "sample_pools.db";
            var connectionStr = $"Data Source={dbFile}";

            using (var connection = new SqliteConnection(connectionStr))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT name, username FROM UserProfile";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        var username = reader.GetString(1);

                        Console.WriteLine($"UserProfile: {name}, {username}");
                    }
                }

                connection.Close();    
            }

            return new string[] { "Item1", "Item2", "Item3" };
        }
    }
}