using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class TryingTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCheckedIn",
                table: "Pets");

            migrationBuilder.AddColumn<byte[]>(
                name: "checkedInAt",
                table: "Pets",
                type: "bytea",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "checkedInAt",
                table: "Pets");

            migrationBuilder.AddColumn<bool>(
                name: "isCheckedIn",
                table: "Pets",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
