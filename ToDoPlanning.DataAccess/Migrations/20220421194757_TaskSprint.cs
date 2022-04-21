using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoPlanning.DataAccess.Migrations
{
    public partial class TaskSprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sprint",
                table: "WorkTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sprint",
                table: "WorkTasks");
        }
    }
}
