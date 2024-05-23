using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_foreign_key_to_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentAdditionalDataId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherAdditionalDataId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentAdditionalDataId",
                table: "Users",
                column: "StudentAdditionalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeacherAdditionalDataId",
                table: "Users",
                column: "TeacherAdditionalDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StudentAdditionalData_StudentAdditionalDataId",
                table: "Users",
                column: "StudentAdditionalDataId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TeacherAdditionalData_TeacherAdditionalDataId",
                table: "Users",
                column: "TeacherAdditionalDataId",
                principalTable: "TeacherAdditionalData",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_StudentAdditionalData_StudentAdditionalDataId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_TeacherAdditionalData_TeacherAdditionalDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentAdditionalDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeacherAdditionalDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentAdditionalDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeacherAdditionalDataId",
                table: "Users");
        }
    }
}
