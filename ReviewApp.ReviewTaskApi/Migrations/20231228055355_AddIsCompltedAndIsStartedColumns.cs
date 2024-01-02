using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.ReviewTaskApi.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCompltedAndIsStartedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTaskCompleteDate",
                table: "ReviewTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaskStartDate",
                table: "ReviewTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTaskCompleteDate",
                table: "ReviewTasks");

            migrationBuilder.DropColumn(
                name: "IsTaskStartDate",
                table: "ReviewTasks");
        }
    }
}
