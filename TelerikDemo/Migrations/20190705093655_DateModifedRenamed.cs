using Microsoft.EntityFrameworkCore.Migrations;

namespace TelerikDemo.Migrations
{
    public partial class DateModifedRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateModifed",
                table: "Cars",
                newName: "DateModified");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Cars",
                newName: "DateModifed");
        }
    }
}
