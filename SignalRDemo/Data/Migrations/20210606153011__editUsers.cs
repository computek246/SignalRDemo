using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRDemo.Data.Migrations
{
    public partial class _editUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModDateTime",
                schema: "security",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModDateTime",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                schema: "security",
                table: "Users");
        }
    }
}
