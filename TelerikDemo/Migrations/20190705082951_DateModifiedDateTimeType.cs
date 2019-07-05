using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelerikDemo.Migrations
{
    public partial class DateModifiedDateTimeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModifed",
                table: "Cars",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTimeOffset));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateModifed",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
