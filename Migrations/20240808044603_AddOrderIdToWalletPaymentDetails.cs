using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShagunGraminHealth.Migrations
{
    public partial class AddOrderIdToWalletPaymentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "WalletPaymentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "WalletPaymentDetails");
        }
    }
}
