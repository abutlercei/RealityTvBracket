using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNet.Migrations
{
    /// <inheritdoc />
    public partial class SeedPools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pools",
                columns: new[] { "Id", "Bio", "HostFK", "Name", "SourceLink", "SourceName" },
                values: new object[,]
                {
                    { 1, "Join this test league to see other features within the environment. As Survivor Season 1 aired in 2000, this current league is closed for actual participants. This pool shows a type where participants gain points as their contestant stays in the competition. The other type of pool allows players to guess when contestants get eliminated similar to NCAA brackets.", "abutler", "Lone Survivors", "https://en.wikipedia.org/wiki/Survivor:_Borneo", "Survivor Season 1" },
                    { 2, "Here is another test league to see how data can transition within the application. Survivor Season 2 allows us to see how to use the same host name and participants within a new pool.", "abutler", "Lone Survivors Revival", "https://en.wikipedia.org/wiki/Survivor:_The_Australian_Outback", "Survivor Season 2" },
                    { 3, "We have another Survivor league! Our fake participants hyped up the stakes and did their final season with our league.", "abutler", "Lone Survivors Final Boss", "https://en.wikipedia.org/wiki/Survivor:_Africa", "Survivor Season 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
