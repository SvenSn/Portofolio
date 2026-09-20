using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyFinder.Persistence.Entities.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Boss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreLobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Boss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InviteToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreLobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QueueParties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Boss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartySize = table.Column<int>(type: "int", nullable: false),
                    TargetSize = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueParties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PreLobbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QueuePartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LobbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Lobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_PreLobbies_PreLobbyId",
                        column: x => x.PreLobbyId,
                        principalTable: "PreLobbies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_QueueParties_QueuePartyId",
                        column: x => x.QueuePartyId,
                        principalTable: "QueueParties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_LobbyId",
                table: "Members",
                column: "LobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PreLobbyId",
                table: "Members",
                column: "PreLobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_QueuePartyId",
                table: "Members",
                column: "QueuePartyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Lobbies");

            migrationBuilder.DropTable(
                name: "PreLobbies");

            migrationBuilder.DropTable(
                name: "QueueParties");
        }
    }
}
