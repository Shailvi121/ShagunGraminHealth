using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShagunGraminHealth.Migrations
{
    public partial class AddPaymentIdToWalletPaymentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "WalletPaymentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "WalletPaymentDetails");
        }
    }
}
