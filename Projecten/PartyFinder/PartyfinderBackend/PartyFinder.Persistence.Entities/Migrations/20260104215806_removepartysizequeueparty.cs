using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyFinder.Persistence.Entities.Migrations
{
    /// <inheritdoc />
    public partial class removepartysizequeueparty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartySize",
                table: "QueueParties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartySize",
                table: "QueueParties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
