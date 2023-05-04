using Microsoft.EntityFrameworkCore.Migrations;

namespace ReimbursementApp.DataAccessLayer.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Claims",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternalNotes",
                table: "Claims",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "InternalNotes",
                table: "Claims");
        }
    }
}
