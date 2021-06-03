using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notification.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.EnsureSchema(
            //    name: "security");

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    schema: "security",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });







            migrationBuilder.EnsureSchema(
                name: "notification");

            migrationBuilder.CreateTable(
                name: "Templates",
                schema: "notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Templates",
                        column: x => x.TemplateId,
                        principalSchema: "notification",
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventRecipient",
                schema: "notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRecipient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRecipient_Events",
                        column: x => x.EventId,
                        principalSchema: "notification",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    NotificationHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    ReferenceTypeId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Events",
                        column: x => x.EventId,
                        principalSchema: "notification",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                schema: "notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReadDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications",
                        column: x => x.NotificationId,
                        principalSchema: "notification",
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRecipient_EventId",
                schema: "notification",
                table: "EventRecipient",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TemplateId",
                schema: "notification",
                table: "Events",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatorId",
                schema: "notification",
                table: "Notifications",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_EventId",
                schema: "notification",
                table: "Notifications",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                schema: "notification",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                schema: "notification",
                table: "UserNotifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRecipient",
                schema: "notification");

            migrationBuilder.DropTable(
                name: "UserNotifications",
                schema: "notification");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "notification");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "notification");

            migrationBuilder.DropTable(
                name: "Templates",
                schema: "notification");
        }
    }
}
