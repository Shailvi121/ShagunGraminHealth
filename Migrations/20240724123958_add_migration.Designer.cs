﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShagunGraminHealth.Data;

#nullable disable

namespace ShagunGraminHealth.Migrations
{
    [DbContext(typeof(ShagunGraminHealthContext))]
    [Migration("20240724123958_add_migration")]
    partial class add_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShagunGraminHealth.Models.FamilyDetail", b =>
                {
                    b.Property<int>("FamilyDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyDetailId"), 1L, 1);

                    b.Property<string>("AadharNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("EducationalLevel")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FamilyMemberName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MembershipFormId")
                        .HasColumnType("int");

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FamilyDetailId");

                    b.HasIndex("MembershipFormId");

                    b.ToTable("FamilyDetail", (string)null);
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.JobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("AdvertisementNo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Agree")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ApplicationId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("BoardUniversity_10th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoardUniversity_12th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoardUniversity_8th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoardUniversity_ITI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CandidateName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CategoryNo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("DateOfBirthDays")
                        .HasColumnType("int");

                    b.Property<int>("DateOfBirthMonths")
                        .HasColumnType("int");

                    b.Property<int>("DateOfBirthYears")
                        .HasColumnType("int");

                    b.Property<string>("Division_10th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Division_12th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Division_8th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Division_ITI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicile")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("EducationalQualifications_10th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationalQualifications_12th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationalQualifications_8th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationalQualifications_ITI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("FormDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MarksObtained_10th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarksObtained_12th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarksObtained_8th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarksObtained_ITI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Percentage_10th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Percentage_12th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Percentage_8th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Percentage_ITI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicallyHandicapped")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Pincode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjects_10th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjects_12th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjects_8th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjects_ITI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalMarks_10th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalMarks_12th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalMarks_8th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalMarks_ITI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisibleIdentification")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("YearOfPassing_10th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearOfPassing_12th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearOfPassing_8th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearOfPassing_ITI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobApplication", (string)null);
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.MembershipForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aadhar_Card")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Application_Id")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Bank_Account")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Bank_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Candidate_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Current_Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Date_of_Birth_Days")
                        .HasColumnType("int");

                    b.Property<int>("Date_of_Birth_Months")
                        .HasColumnType("int");

                    b.Property<int>("Date_of_Birth_Years")
                        .HasColumnType("int");

                    b.Property<string>("Educational_Level")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Father_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Form_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("IFSC")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Marriage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Parmanent_Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PlanNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ration_Card")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("age_photo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("age_proof")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("old_application_no")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("old_member_name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("MembershipForm", (string)null);
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.MembershipPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("PlanFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PlanName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PlanNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MembershipPlan", (string)null);
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.NominatedDetail", b =>
                {
                    b.Property<int>("NominatedDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NominatedDetailId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("MembershipFormId")
                        .HasColumnType("int");

                    b.Property<string>("NominatedPersonName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Percentage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NominatedDetailId");

                    b.HasIndex("MembershipFormId");

                    b.ToTable("NominatedDetail", (string)null);
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.PaymentOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaymentStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RazorPaymentId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PaymentOrder", (string)null);
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Passcode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.FamilyDetail", b =>
                {
                    b.HasOne("ShagunGraminHealth.Models.MembershipForm", "MembershipForm")
                        .WithMany("FamilyDetails")
                        .HasForeignKey("MembershipFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipForm");
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.NominatedDetail", b =>
                {
                    b.HasOne("ShagunGraminHealth.Models.MembershipForm", "MembershipForm")
                        .WithMany("NominatedDetails")
                        .HasForeignKey("MembershipFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipForm");
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.UserRole", b =>
                {
                    b.HasOne("ShagunGraminHealth.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRole_Role");

                    b.HasOne("ShagunGraminHealth.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRole_User");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.MembershipForm", b =>
                {
                    b.Navigation("FamilyDetails");

                    b.Navigation("NominatedDetails");
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ShagunGraminHealth.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
