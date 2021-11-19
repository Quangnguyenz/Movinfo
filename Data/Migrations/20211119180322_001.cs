using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProDemo.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CastId",
                table: "MovieCast",
                newName: "CastID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movie",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CastID",
                table: "MovieCast",
                newName: "CastId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movie",
                newName: "id");
        }
    }
}
