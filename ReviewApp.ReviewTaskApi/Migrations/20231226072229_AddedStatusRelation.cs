using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.ReviewTaskApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatusRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReviewTasks_StatusId",
                table: "ReviewTasks",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewTasks_Statuses_StatusId",
                table: "ReviewTasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewTasks_Statuses_StatusId",
                table: "ReviewTasks");

            migrationBuilder.DropIndex(
                name: "IX_ReviewTasks_StatusId",
                table: "ReviewTasks");
        }
    }
}
