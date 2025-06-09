using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTodoItemCompleation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TodoItem");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "TodoItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "TodoItem");

            migrationBuilder.AddColumn<string>(
                name: "CurrentState",
                table: "TodoItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
