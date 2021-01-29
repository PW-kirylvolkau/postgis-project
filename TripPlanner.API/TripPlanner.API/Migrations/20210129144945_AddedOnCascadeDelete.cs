using Microsoft.EntityFrameworkCore.Migrations;

namespace TripPlanner.API.Migrations
{
    public partial class AddedOnCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointId1",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_PointId1",
                table: "Places",
                column: "PointId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Points_PointId1",
                table: "Places",
                column: "PointId1",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Points_PointId1",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_PointId1",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PointId1",
                table: "Places");
        }
    }
}
