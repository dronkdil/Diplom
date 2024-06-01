using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class change_delivered_to_complete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Delivered",
                table: "Homeworks",
                newName: "Сompleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Сompleted",
                table: "Homeworks",
                newName: "Delivered");
        }
    }
}
