using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShagunGraminHealth.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobAdvertisement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdvertisementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Post = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ApplicationFeeGEN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplicationFeeOTH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAdvertisement", x => x.Id);
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
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    VisibleIdentification = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Agree = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FormDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalQualifications_8th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfPassing_8th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarksObtained_8th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMarks_8th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage_8th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division_8th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardUniversity_8th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subjects_8th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationalQualifications_10th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfPassing_10th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarksObtained_10th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMarks_10th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage_10th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division_10th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardUniversity_10th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subjects_10th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationalQualifications_12th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfPassing_12th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarksObtained_12th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMarks_12th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage_12th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division_12th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardUniversity_12th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subjects_12th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationalQualifications_ITI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfPassing_ITI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarksObtained_ITI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMarks_ITI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage_ITI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division_ITI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardUniversity_ITI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subjects_ITI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationalQualifications_Diploma = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    YearOfPassing_Diploma = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    MarksObtained_Diploma = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TotalMarks_Diploma = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Percentage_Diploma = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Division_Diploma = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    BoardUniversity_Diploma = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Subjects_Diploma = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EducationalQualifications_Bachelor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    YearOfPassing_Bachelor = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    MarksObtained_Bachelor = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TotalMarks_Bachelor = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Percentage_Bachelor = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Division_Bachelor = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    BoardUniversity_Bachelor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Subjects_Bachelor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EducationalQualifications_Master = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    YearOfPassing_Master = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    MarksObtained_Master = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TotalMarks_Master = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Percentage_Master = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Division_Master = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    BoardUniversity_Master = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Subjects_Master = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Higher_Qualification = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Experience_Years = table.Column<int>(type: "int", nullable: false),
                    Experience_Months = table.Column<int>(type: "int", nullable: false),
                    Experience_Days = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Application_Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PlanNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Candidate_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Father_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Parmanent_Address = table.Column<string>(type: "text", nullable: false),
                    Current_Address = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Date_of_Birth_Days = table.Column<int>(type: "int", nullable: false),
                    Date_of_Birth_Months = table.Column<int>(type: "int", nullable: false),
                    Date_of_Birth_Years = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Educational_Level = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Marriage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ration_Card = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Aadhar_Card = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Bank_Account = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IFSC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Bank_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    age_proof = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    age_photo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    old_member_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    old_application_no = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Form_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NominatedDetailsJson = table.Column<string>(type: "text", nullable: false),
                    FamilyDetailsJson = table.Column<string>(type: "text", nullable: false),
                    Bonus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlanFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplicationId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RazorPaymentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Mobile = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBalance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranscationCount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletPaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    UserRefId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletPaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletPaymentDetails_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_UserId",
                table: "Wallet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletPaymentDetails_WalletId",
                table: "WalletPaymentDetails",
                column: "WalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobAdvertisement");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "MembershipForm");

            migrationBuilder.DropTable(
                name: "MembershipPlan");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentOrder");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "WalletPaymentDetails");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
