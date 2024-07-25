using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShagunGraminHealth.Migrations
{
    public partial class AddApplicationIdToMembershipPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "MembershipPlan",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "MembershipPlan");
        }
    }
}
