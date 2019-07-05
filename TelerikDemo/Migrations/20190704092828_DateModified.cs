using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelerikDemo.Migrations
{
    public partial class DateModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateModifed",
                table: "Cars",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModifed",
                table: "Cars");
        }
    }
}
