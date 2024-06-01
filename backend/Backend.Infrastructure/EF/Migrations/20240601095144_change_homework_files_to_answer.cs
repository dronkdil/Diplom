using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class change_homework_files_to_answer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Evaluation",
                table: "Homeworks",
                newName: "Appraisal");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Homeworks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Homeworks");

            migrationBuilder.RenameColumn(
                name: "Appraisal",
                table: "Homeworks",
                newName: "Evaluation");
        }
    }
}
