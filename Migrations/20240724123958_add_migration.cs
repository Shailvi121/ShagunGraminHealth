using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShagunGraminHealth.Migrations
{
    public partial class add_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyDetail",
                columns: table => new
                {
                    FamilyDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipFormId = table.Column<int>(type: "int", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyMemberName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AadharNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EducationalLevel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
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
                name: "JobApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdvertisementNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Post = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CandidateName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirthDays = table.Column<int>(type: "int", nullable: false),
                    DateOfBirthMonths = table.Column<int>(type: "int", nullable: false),
                    DateOfBirthYears = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhysicallyHandicapped = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    VisibleIdentification = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Agree = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FormDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalQualifications_8th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPassing_8th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarksObtained_8th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks_8th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage_8th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division_8th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardUniversity_8th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subjects_8th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalQualifications_10th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPassing_10th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarksObtained_10th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks_10th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage_10th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division_10th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardUniversity_10th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subjects_10th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalQualifications_12th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPassing_12th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarksObtained_12th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks_12th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage_12th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division_12th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardUniversity_12th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subjects_12th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalQualifications_ITI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPassing_ITI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarksObtained_ITI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks_ITI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage_ITI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division_ITI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardUniversity_ITI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subjects_ITI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NominatedDetail",
                columns: table => new
                {
                    NominatedDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipFormId = table.Column<int>(type: "int", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NominatedPersonName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyDetail");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "NominatedDetail");
        }
    }
}
