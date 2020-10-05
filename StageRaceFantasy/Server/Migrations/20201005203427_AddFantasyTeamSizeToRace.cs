using Microsoft.EntityFrameworkCore.Migrations;

namespace StageRaceFantasy.Server.Migrations
{
    public partial class AddFantasyTeamSizeToRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FantasyTeamSize",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FantasyTeamSize",
                table: "Races");
        }
    }
}
