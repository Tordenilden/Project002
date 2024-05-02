using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project002.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Monday2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battle",
                columns: table => new
                {
                    BattleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battle", x => x.BattleId);
                });

            migrationBuilder.CreateTable(
                name: "Samurai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samurai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BattleSamurai",
                columns: table => new
                {
                    BattleId = table.Column<int>(type: "int", nullable: false),
                    SamuraiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleSamurai", x => new { x.SamuraiId, x.BattleId });
                    table.ForeignKey(
                        name: "FK_BattleSamurai_Battle_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battle",
                        principalColumn: "BattleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleSamurai_Samurai_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horse",
                columns: table => new
                {
                    HorseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SamuraiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horse", x => x.HorseId);
                    table.ForeignKey(
                        name: "FK_Horse_Samurai_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Battle",
                columns: new[] { "BattleId", "Description", "Name", "end", "start" },
                values: new object[,]
                {
                    { 100, "Really bad", "Imperious", new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 200, "Really bad", "FUnny", new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Samurai",
                columns: new[] { "Id", "Age", "Description", "Name" },
                values: new object[,]
                {
                    { 10, 20, "This is serios", "Ulla Skallesmækker" },
                    { 20, 20, "This is serios", "Ulla BrainFLuid" }
                });

            migrationBuilder.InsertData(
                table: "BattleSamurai",
                columns: new[] { "BattleId", "SamuraiId" },
                values: new object[,]
                {
                    { 100, 10 },
                    { 200, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleSamurai_BattleId",
                table: "BattleSamurai",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_Horse_SamuraiId",
                table: "Horse",
                column: "SamuraiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleSamurai");

            migrationBuilder.DropTable(
                name: "Horse");

            migrationBuilder.DropTable(
                name: "Battle");

            migrationBuilder.DropTable(
                name: "Samurai");
        }
    }
}
