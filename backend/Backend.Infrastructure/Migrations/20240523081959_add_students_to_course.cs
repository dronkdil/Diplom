using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_students_to_course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentAdditionalData_StudentAdditionalDataId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_TeacherAdditionalData_TeacherAdditionalDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeacherAdditionalDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentAdditionalDataId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentAdditionalDataId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TeacherAdditionalData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseStudentAdditionalData",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudentAdditionalData", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudentAdditionalData_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudentAdditionalData_StudentAdditionalData_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAdditionalData_UserId",
                table: "TeacherAdditionalData",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentAdditionalData_StudentsId",
                table: "CourseStudentAdditionalData",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherAdditionalData_Users_UserId",
                table: "TeacherAdditionalData",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherAdditionalData_Users_UserId",
                table: "TeacherAdditionalData");

            migrationBuilder.DropTable(
                name: "CourseStudentAdditionalData");

            migrationBuilder.DropIndex(
                name: "IX_TeacherAdditionalData_UserId",
                table: "TeacherAdditionalData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TeacherAdditionalData");

            migrationBuilder.AddColumn<int>(
                name: "StudentAdditionalDataId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeacherAdditionalDataId",
                table: "Users",
                column: "TeacherAdditionalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentAdditionalDataId",
                table: "Courses",
                column: "StudentAdditionalDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentAdditionalData_StudentAdditionalDataId",
                table: "Courses",
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
    }
}
