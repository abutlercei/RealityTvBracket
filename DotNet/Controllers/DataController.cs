using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;

namespace DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // https://www.ottorinobruni.com/how-to-integrate-sqlite-with-net-console-application-using-csharp-and-vscode/
            const String dbFile = "sample_pools.db";
            var connectionStr = $"Data Source={dbFile}";

            using (var connection = new SqliteConnection(connectionStr))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT username, name FROM UserProfile";

                var data = new JObject();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var username = reader.GetString(0);
                        var name = reader.GetString(1);
                        // Rest of function goes here
                    }
                }

                connection.Close();
            }

            System.Console.WriteLine("Database file deleted!");

            return new string[] { "Data1", "Data2", "Data3" };
        }
    }
}