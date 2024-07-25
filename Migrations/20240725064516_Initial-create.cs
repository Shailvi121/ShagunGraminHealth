using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShagunGraminHealth.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyDetail");

            migrationBuilder.DropTable(
                name: "NominatedDetail");

            migrationBuilder.AddColumn<string>(
                name: "FamilyDetailsJson",
                table: "MembershipForm",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NominatedDetailsJson",
                table: "MembershipForm",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyDetailsJson",
                table: "MembershipForm");

            migrationBuilder.DropColumn(
                name: "NominatedDetailsJson",
                table: "MembershipForm");

            migrationBuilder.CreateTable(
                name: "FamilyDetail",
                columns: table => new
                {
                    FamilyDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipFormId = table.Column<int>(type: "int", nullable: false),
                    AadharNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    EducationalLevel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FamilyMemberName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDetail", x => x.FamilyDetailId);
                    table.ForeignKey(
                        name: "FK_FamilyDetail_MembershipForm_MembershipFormId",
                        column: x => x.MembershipFormId,
                        principalTable: "MembershipForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NominatedDetail",
                columns: table => new
                {
                    NominatedDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipFormId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NominatedPersonName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Percentage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NominatedDetail", x => x.NominatedDetailId);
                    table.ForeignKey(
                        name: "FK_NominatedDetail_MembershipForm_MembershipFormId",
                        column: x => x.MembershipFormId,
                        principalTable: "MembershipForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetail_MembershipFormId",
                table: "FamilyDetail",
                column: "MembershipFormId");

            migrationBuilder.CreateIndex(
                name: "IX_NominatedDetail_MembershipFormId",
                table: "NominatedDetail",
                column: "MembershipFormId");
        }
    }
}
