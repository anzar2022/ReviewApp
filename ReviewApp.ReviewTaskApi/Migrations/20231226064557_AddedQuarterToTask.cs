using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.ReviewTaskApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedQuarterToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuarterCode",
                table: "Quarters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTasks_QuarterId",
                table: "ReviewTasks",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_Quarters_QuarterCode",
                table: "Quarters",
                column: "QuarterCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewTasks_Quarters_QuarterId",
                table: "ReviewTasks",
                column: "QuarterId",
                principalTable: "Quarters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewTasks_Quarters_QuarterId",
                table: "ReviewTasks");

            migrationBuilder.DropIndex(
                name: "IX_ReviewTasks_QuarterId",
                table: "ReviewTasks");

            migrationBuilder.DropIndex(
                name: "IX_Quarters_QuarterCode",
                table: "Quarters");

            migrationBuilder.AlterColumn<string>(
                name: "QuarterCode",
                table: "Quarters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
