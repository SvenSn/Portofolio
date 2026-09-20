using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyFinder.Persistence.Entities.Migrations
{
    /// <inheritdoc />
    public partial class Lobby_Member_leaderid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LeaderId",
                table: "PreLobbies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityServerId",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Lobbies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Lobbies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaderId",
                table: "PreLobbies");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IdentityServerId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Lobbies");
        }
    }
}
