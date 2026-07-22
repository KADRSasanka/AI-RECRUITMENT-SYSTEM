using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddResumeFileMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateId1",
                table: "Resumes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Resumes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "StoredFileName",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_CandidateId1",
                table: "Resumes",
                column: "CandidateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Candidates_CandidateId1",
                table: "Resumes",
                column: "CandidateId1",
                principalTable: "Candidates",
                principalColumn: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Candidates_CandidateId1",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_CandidateId1",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "CandidateId1",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "StoredFileName",
                table: "Resumes");
        }
    }
}
