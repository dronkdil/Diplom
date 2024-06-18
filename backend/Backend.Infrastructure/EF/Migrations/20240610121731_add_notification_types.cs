using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class add_notification_types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotificationTypeId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NotificationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "Id", "Slug" },
                values: new object[,]
                {
                    { 1, "CERT_STUD" },
                    { 2, "REG_STUD" },
                    { 3, "STUD_ACT" },
                    { 4, "TEACH_GRD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_NotificationType_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId",
                principalTable: "NotificationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_NotificationType_NotificationTypeId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationType");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationTypeId",
                table: "Notifications");
        }
    }
}
