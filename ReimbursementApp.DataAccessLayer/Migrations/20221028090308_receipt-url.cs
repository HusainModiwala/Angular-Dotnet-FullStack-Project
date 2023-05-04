using Microsoft.EntityFrameworkCore.Migrations;

namespace ReimbursementApp.DataAccessLayer.Migrations
{
    public partial class receipturl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiptUrl",
                table: "Claims",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiptUrl",
                table: "Claims");
        }
    }
}
