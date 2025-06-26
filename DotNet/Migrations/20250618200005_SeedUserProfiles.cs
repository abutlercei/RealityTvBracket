using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNet.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Username", "Name", "Password" },
                values: new object[,]
                {
                    { "aadam", "Adam", "password" },
                    { "aapril", "April", "password" },
                    { "abutler", "Alex", "password" },
                    { "ffrancis", "Francis", "password" },
                    { "jjayden", "Jayden", "password" },
                    { "jjeff", "Jeff", "password" },
                    { "kkathleen", "Kathleen", "password" },
                    { "kkelley", "Kelley", "password" },
                    { "llucy", "Lucy", "password" },
                    { "mmorgan", "Morgan", "password" },
                    { "nnina", "Nina", "password" },
                    { "pparis", "Paris", "password" },
                    { "ppatrica", "Patrica", "password" },
                    { "rrosalind", "Rosalind", "password" },
                    { "sstephan", "Stephan", "password" },
                    { "ttaylor", "Taylor", "password" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "aadam");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "aapril");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "abutler");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "ffrancis");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "jjayden");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "jjeff");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "kkathleen");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "kkelley");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "llucy");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "mmorgan");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "nnina");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "pparis");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "ppatrica");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "rrosalind");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "sstephan");

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Username",
                keyValue: "ttaylor");
        }
    }
}
