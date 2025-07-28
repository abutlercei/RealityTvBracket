using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNet.Migrations
{
    /// <inheritdoc />
    public partial class SeedPoolMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PoolMembers",
                columns: new[] { "PoolNameFK", "UsernameFK", "Contestant", "Points", "Rank" },
                values: new object[,]
                {
                    { 1, "aadam", "Joel", 5, 11 },
                    { 2, "aadam", "Colby", 14, 2 },
                    { 3, "aadam", "Carl", 2, 14 },
                    { 1, "aapril", "Stacey", 2, 14 },
                    { 2, "aapril", "Jeff", 6, 10 },
                    { 3, "aapril", "Lex", 13, 3 },
                    { 1, "abutler", "Rudy", 13, 3 },
                    { 2, "abutler", "Mitchell", 3, 13 },
                    { 3, "abutler", "Clarence", 6, 10 },
                    { 1, "ffrancis", "Ramona", 3, 13 },
                    { 2, "ffrancis", "Alicia", 7, 9 },
                    { 3, "ffrancis", "Silas", 4, 12 },
                    { 1, "jjayden", "Gervase", 9, 7 },
                    { 2, "jjayden", "Rodger", 11, 5 },
                    { 3, "jjayden", "Diane", 0, 16 },
                    { 1, "jjeff", "Kelly", 14, 2 },
                    { 2, "jjeff", "Debb", 0, 16 },
                    { 3, "jjeff", "Kim P", 10, 6 },
                    { 1, "kkathleen", "Gretchen", 6, 10 },
                    { 2, "kkathleen", "Nick", 9, 7 },
                    { 3, "kkathleen", "Frank", 9, 7 },
                    { 1, "kkelley", "Coleen", 10, 6 },
                    { 2, "kkelley", "Amber", 10, 6 },
                    { 3, "kkelley", "Kelly", 7, 9 },
                    { 1, "llucy", "BB", 1, 15 },
                    { 2, "llucy", "Michael", 5, 11 },
                    { 3, "llucy", "Linda", 3, 13 },
                    { 1, "mmorgan", "Sonja", 0, 16 },
                    { 2, "mmorgan", "Keith", 13, 3 },
                    { 3, "mmorgan", "Ethan", 14, 2 },
                    { 1, "nnina", "Susan", 12, 4 },
                    { 2, "nnina", "Elisabeth", 12, 4 },
                    { 3, "nnina", "Tom", 12, 4 },
                    { 1, "pparis", "Greg", 7, 9 },
                    { 2, "pparis", "Jerri", 8, 8 },
                    { 3, "pparis", "Kim J", 15, 1 },
                    { 1, "ppatrica", "Sean", 11, 5 },
                    { 2, "ppatrica", "Maralyn", 2, 14 },
                    { 3, "ppatrica", "Brandon", 8, 8 },
                    { 1, "rrosalind", "Richard", 15, 1 },
                    { 2, "rrosalind", "Kel", 1, 15 },
                    { 3, "rrosalind", "Jessie", 1, 15 },
                    { 1, "sstephan", "Dirk", 4, 12 },
                    { 2, "sstephan", "Kimmi", 4, 12 },
                    { 3, "sstephan", "Lindsey", 5, 11 },
                    { 1, "ttaylor", "Jenna", 8, 8 },
                    { 2, "ttaylor", "Tina", 15, 1 },
                    { 3, "ttaylor", "Teresa", 11, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "aadam" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "aadam" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "aadam" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "aapril" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "aapril" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "aapril" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "abutler" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "abutler" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "abutler" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "ffrancis" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "ffrancis" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "ffrancis" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "jjayden" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "jjayden" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "jjayden" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "jjeff" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "jjeff" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "jjeff" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "kkathleen" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "kkathleen" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "kkathleen" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "kkelley" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "kkelley" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "kkelley" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "llucy" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "llucy" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "llucy" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "mmorgan" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "mmorgan" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "mmorgan" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "nnina" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "nnina" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "nnina" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "pparis" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "pparis" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "pparis" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "ppatrica" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "ppatrica" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "ppatrica" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "rrosalind" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "rrosalind" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "rrosalind" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "sstephan" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "sstephan" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "sstephan" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 1, "ttaylor" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 2, "ttaylor" });

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumns: new[] { "PoolNameFK", "UsernameFK" },
                keyValues: new object[] { 3, "ttaylor" });
        }
    }
}
