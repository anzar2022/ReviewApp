using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.ReviewTaskApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenUserAndTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ReviewTasks",
                type: "bigint",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTasks_UserId",
                table: "ReviewTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewTasks_Users_UserId",
                table: "ReviewTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewTasks_Users_UserId",
                table: "ReviewTasks");

            migrationBuilder.DropIndex(
                name: "IX_ReviewTasks_UserId",
                table: "ReviewTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReviewTasks");
        }
    }
}
