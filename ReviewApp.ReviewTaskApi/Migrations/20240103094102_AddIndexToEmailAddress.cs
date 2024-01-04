using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.ReviewTaskApi.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexToEmailAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_EmailAddress",
                table: "Users",
                column: "EmailAddress",
                unique: true); // Specify if the index should be unique or not
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_EmailAddress",
                table: "Users");
        }
    }
}
