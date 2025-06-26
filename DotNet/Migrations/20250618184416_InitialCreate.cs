using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Pools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pools_UserProfiles_HostFK",
                        column: x => x.HostFK,
                        principalTable: "UserProfiles",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoolMembers",
                columns: table => new
                {
                    UsernameFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PoolNameFK = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: true),
                    Contestant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolMembers", x => new { x.UsernameFK, x.PoolNameFK });
                    table.ForeignKey(
                        name: "FK_PoolMembers_Pools_PoolNameFK",
                        column: x => x.PoolNameFK,
                        principalTable: "Pools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolMembers_UserProfiles_UsernameFK",
                        column: x => x.UsernameFK,
                        principalTable: "UserProfiles",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoolMembers_PoolNameFK",
                table: "PoolMembers",
                column: "PoolNameFK");

            migrationBuilder.CreateIndex(
                name: "IX_Pools_HostFK",
                table: "Pools",
                column: "HostFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolMembers");

            migrationBuilder.DropTable(
                name: "Pools");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
