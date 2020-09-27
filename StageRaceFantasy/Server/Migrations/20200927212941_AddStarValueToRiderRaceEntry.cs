using Microsoft.EntityFrameworkCore.Migrations;

namespace StageRaceFantasy.Server.Migrations
{
    public partial class AddStarValueToRiderRaceEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StarValue",
                table: "RiderRaceEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarValue",
                table: "RiderRaceEntries");
        }
    }
}
