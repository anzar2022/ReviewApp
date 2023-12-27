using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.ReviewTaskApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatusCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusCode",
                table: "Statuses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_StatusCode",
                table: "Statuses",
                column: "StatusCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Statuses_StatusCode",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Statuses");
        }
    }
}
