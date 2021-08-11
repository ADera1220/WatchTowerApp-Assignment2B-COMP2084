using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchTowerWebApp.Data.Migrations
{
    public partial class AddWatchTimeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WatchTime",
                table: "CoWatchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WatchTime",
                table: "CoWatchers");
        }
    }
}
