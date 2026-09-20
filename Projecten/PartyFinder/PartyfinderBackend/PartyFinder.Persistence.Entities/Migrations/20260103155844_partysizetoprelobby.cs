using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyFinder.Persistence.Entities.Migrations
{
    /// <inheritdoc />
    public partial class partysizetoprelobby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxSize",
                table: "PreLobbies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetSize",
                table: "PreLobbies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxSize",
                table: "PreLobbies");

            migrationBuilder.DropColumn(
                name: "TargetSize",
                table: "PreLobbies");
        }
    }
}
