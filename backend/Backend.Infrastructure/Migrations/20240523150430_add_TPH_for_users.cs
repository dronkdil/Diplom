using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_TPH_for_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_StudentAdditionalData_StudentAdditionalDataId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_TeacherAdditionalData_TeacherAdditionalDataId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_StudentAdditionalData_StudentAdditionalDataId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StudentAdditionalData_StudentAdditionalDataId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CourseStudentAdditionalData");

            migrationBuilder.DropTable(
                name: "TeacherAdditionalData");

            migrationBuilder.DropTable(
                name: "StudentAdditionalData");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentAdditionalDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_StudentAdditionalDataId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherAdditionalDataId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "StudentAdditionalDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeacherAdditionalDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentAdditionalDataId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "TeacherAdditionalDataId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StudentAdditionalDataId",
                table: "Certificates",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_StudentAdditionalDataId",
                table: "Certificates",
                newName: "IX_Certificates_StudentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationalStatus",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Users_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FirstName", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { 1, "User", "admin@admin", "Admin", null, "admin_hashed", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_StudentId",
                table: "Homeworks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Users_StudentId",
                table: "Certificates",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Users_StudentId",
                table: "Homeworks",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Users_StudentId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_TeacherId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Users_StudentId",
                table: "Homeworks");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_StudentId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EducationalStatus",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Certificates",
                newName: "StudentAdditionalDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_StudentId",
                table: "Certificates",
                newName: "IX_Certificates_StudentAdditionalDataId");

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

            migrationBuilder.AddColumn<int>(
                name: "StudentAdditionalDataId",
                table: "Homeworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherAdditionalDataId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentAdditionalData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EducationalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAdditionalData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAdditionalData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAdditionalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAdditionalData_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalTable: "StudentAdditionalData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StudentAdditionalDataId", "TeacherAdditionalDataId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentAdditionalDataId",
                table: "Users",
                column: "StudentAdditionalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_StudentAdditionalDataId",
                table: "Homeworks",
                column: "StudentAdditionalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherAdditionalDataId",
                table: "Courses",
                column: "TeacherAdditionalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentAdditionalData_StudentsId",
                table: "CourseStudentAdditionalData",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAdditionalData_UserId",
                table: "TeacherAdditionalData",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_StudentAdditionalData_StudentAdditionalDataId",
                table: "Certificates",
                column: "StudentAdditionalDataId",
                principalTable: "StudentAdditionalData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_TeacherAdditionalData_TeacherAdditionalDataId",
                table: "Courses",
                column: "TeacherAdditionalDataId",
                principalTable: "TeacherAdditionalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_StudentAdditionalData_StudentAdditionalDataId",
                table: "Homeworks",
                column: "StudentAdditionalDataId",
                principalTable: "StudentAdditionalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StudentAdditionalData_StudentAdditionalDataId",
                table: "Users",
                column: "StudentAdditionalDataId",
                principalTable: "StudentAdditionalData",
                principalColumn: "Id");
        }
    }
}
