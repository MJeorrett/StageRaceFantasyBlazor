using Microsoft.EntityFrameworkCore.Migrations;

namespace StageRaceFantasy.Server.Migrations
{
    public partial class RenameRaceStageFinishLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndLocation",
                table: "RaceStages",
                newName: "FinishLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinishLocation",
                table: "RaceStages",
                newName: "EndLocation");
        }
    }
}
