using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_users_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Students_StudentId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_StudentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Students_StudentId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Teachers_TeacherId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Roles_RoleId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Roles_RoleId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_StudentId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_StudentId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_RoleId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoleId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "TeacherAdditionalData");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_TeacherId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Courses",
                newName: "StudentAdditionalDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_StudentId",
                table: "Courses",
                newName: "IX_Courses_StudentAdditionalDataId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherAdditionalData",
                table: "TeacherAdditionalData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAdditionalData",
                table: "Student",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Student" },
                    { 2, "Teacher" },
                    { 3, "Administrator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_StudentAdditionalDataId",
                table: "Homeworks",
                column: "StudentAdditionalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherAdditionalDataId",
                table: "Courses",
                column: "TeacherAdditionalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_StudentAdditionalData_StudentAdditionalDataId",
                table: "Certificates",
                column: "StudentAdditionalDataId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentAdditionalData_StudentAdditionalDataId",
                table: "Courses",
                column: "StudentAdditionalDataId",
                principalTable: "Student",
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
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_StudentAdditionalData_StudentAdditionalDataId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentAdditionalData_StudentAdditionalDataId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_TeacherAdditionalData_TeacherAdditionalDataId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_StudentAdditionalData_StudentAdditionalDataId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_StudentAdditionalDataId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherAdditionalDataId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherAdditionalData",
                table: "TeacherAdditionalData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAdditionalData",
                table: "Student");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "StudentAdditionalDataId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "TeacherAdditionalDataId",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "TeacherAdditionalData",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_TeacherId");

            migrationBuilder.RenameColumn(
                name: "StudentAdditionalDataId",
                table: "Courses",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_StudentAdditionalDataId",
                table: "Courses",
                newName: "IX_Courses_StudentId");

            migrationBuilder.RenameColumn(
                name: "StudentAdditionalDataId",
                table: "Certificates",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_StudentAdditionalDataId",
                table: "Certificates",
                newName: "IX_Certificates_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_StudentId",
                table: "Notifications",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_StudentId",
                table: "Homeworks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_RoleId",
                table: "Teachers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoleId",
                table: "Students",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Students_StudentId",
                table: "Certificates",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Students_StudentId",
                table: "Courses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "UserId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Students_StudentId",
                table: "Notifications",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Teachers_TeacherId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Roles_RoleId",
                table: "Students",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Roles_RoleId",
                table: "Teachers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
