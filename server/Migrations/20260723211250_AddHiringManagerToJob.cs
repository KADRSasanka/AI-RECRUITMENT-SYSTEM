using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddHiringManagerToJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HiringManagerId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_HiringManagerId",
                table: "Jobs",
                column: "HiringManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Users_HiringManagerId",
                table: "Jobs",
                column: "HiringManagerId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Users_HiringManagerId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_HiringManagerId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "HiringManagerId",
                table: "Jobs");
        }
    }
}
