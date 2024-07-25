using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShagunGraminHealth.Areas.Admin.Models;
using ShagunGraminHealth.Models;

namespace ShagunGraminHealth.Data
{
    public partial class ShagunGraminHealthContext : DbContext
    {
        public ShagunGraminHealthContext()
        {
        }

        public ShagunGraminHealthContext(DbContextOptions<ShagunGraminHealthContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<MembershipPlan> MembershipPlans { get; set; } = null!;

        public virtual DbSet<MembershipForm> MembershipForms { get; set; }
        public virtual DbSet<PaymentOrder> PaymentOrders { get; set; }
        public virtual DbSet<Orders> Order { get; set; } = null!;
        public virtual DbSet<JobApplication> JobApplications { get; set; } = null!;
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Passcode).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<MembershipPlan>(entity =>
            {
                entity.ToTable("MembershipPlan");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.Property(e => e.PlanFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlanName).HasMaxLength(100);

                entity.Property(e => e.PlanNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<MembershipForm>(entity =>
            {
                entity.ToTable("MembershipForm");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.Property(e => e.Application_Id).HasMaxLength(255).IsRequired();
                entity.Property(e => e.PlanNumber).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Reference).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Candidate_Name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Father_Name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Parmanent_Address).HasColumnType("text").IsRequired();
                entity.Property(e => e.Current_Address).HasColumnType("text").IsRequired();
                entity.Property(e => e.Mobile).HasMaxLength(15).IsRequired();
                entity.Property(e => e.Date_of_Birth_Days).IsRequired();
                entity.Property(e => e.Date_of_Birth_Months).IsRequired();
                entity.Property(e => e.Date_of_Birth_Years).IsRequired();
                entity.Property(e => e.Sex).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Educational_Level).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Marriage).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Category).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Ration_Card).HasMaxLength(255);
                entity.Property(e => e.Aadhar_Card).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Bank_Account).HasMaxLength(255).IsRequired();
                entity.Property(e => e.IFSC).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Bank_Name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.age_proof).HasMaxLength(50).IsRequired();
                entity.Property(e => e.age_photo).HasMaxLength(255).IsRequired();
                entity.Property(e => e.old_member_name).HasMaxLength(255);
                entity.Property(e => e.old_application_no).HasMaxLength(255);
                entity.Property(e => e.Photo).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Signature).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Place).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Form_Date).IsRequired();
                entity.Property(e => e.OrderId).HasMaxLength(50).IsRequired();
                entity.Property(e => e.NominatedDetailsJson).HasColumnType("text").IsRequired();
                entity.Property(e => e.FamilyDetailsJson).HasColumnType("text").IsRequired();
            });
           
            modelBuilder.Entity<PaymentOrder>(entity =>
            {
                entity.ToTable("PaymentOrder");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.Property(e => e.OrderId).HasMaxLength(50);
                entity.Property(e => e.PaymentStatus).HasMaxLength(50);
                entity.Property(e => e.RazorPaymentId).HasMaxLength(50);
                entity.Property(e => e.UserId).IsRequired(false);
            });
            modelBuilder.Entity<JobApplication>(entity =>
            {
                entity.ToTable("JobApplication");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.ApplicationId).HasMaxLength(255).IsRequired();
                entity.Property(e => e.AdvertisementNo).HasMaxLength(255).IsRequired();
                entity.Property(e => e.CategoryNo).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Post).HasMaxLength(255).IsRequired();
                entity.Property(e => e.CandidateName).HasMaxLength(255).IsRequired();
                entity.Property(e => e.FatherName).HasMaxLength(255).IsRequired();
                entity.Property(e => e.DateOfBirthDays).IsRequired();
                entity.Property(e => e.DateOfBirthMonths).IsRequired();
                entity.Property(e => e.DateOfBirthYears).IsRequired();
                entity.Property(e => e.Sex).HasMaxLength(10).IsRequired();
                entity.Property(e => e.EmailAddress).HasMaxLength(255).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Category).HasMaxLength(10).IsRequired();
                entity.Property(e => e.PhysicallyHandicapped).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Domicile).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Nationality).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Pincode).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Address).HasMaxLength(1000).IsRequired();
                entity.Property(e => e.VisibleIdentification).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Agree).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Place).HasMaxLength(255).IsRequired();
                entity.Property(e => e.FormDate).IsRequired();
                entity.Property(e => e.Photo).IsRequired();
                entity.Property(e => e.Signature).IsRequired();

                entity.Property(e => e.EducationalQualifications_8th).IsRequired(false);
                entity.Property(e => e.YearOfPassing_8th).IsRequired(false);
                entity.Property(e => e.MarksObtained_8th).IsRequired(false);
                entity.Property(e => e.TotalMarks_8th).IsRequired(false);
                entity.Property(e => e.Percentage_8th).IsRequired(false);
                entity.Property(e => e.Division_8th).IsRequired(false);
                entity.Property(e => e.BoardUniversity_8th).IsRequired(false);
                entity.Property(e => e.Subjects_8th).IsRequired(false);

                entity.Property(e => e.EducationalQualifications_10th).IsRequired(false);
                entity.Property(e => e.YearOfPassing_10th).IsRequired(false);
                entity.Property(e => e.MarksObtained_10th).IsRequired(false);
                entity.Property(e => e.TotalMarks_10th).IsRequired(false);
                entity.Property(e => e.Percentage_10th).IsRequired(false);
                entity.Property(e => e.Division_10th).IsRequired(false);
                entity.Property(e => e.BoardUniversity_10th).IsRequired(false);
                entity.Property(e => e.Subjects_10th).IsRequired(false);

                entity.Property(e => e.EducationalQualifications_12th).IsRequired(false);
                entity.Property(e => e.YearOfPassing_12th).IsRequired(false);
                entity.Property(e => e.MarksObtained_12th).IsRequired(false);
                entity.Property(e => e.TotalMarks_12th).IsRequired(false);
                entity.Property(e => e.Percentage_12th).IsRequired(false);
                entity.Property(e => e.Division_12th).IsRequired(false);
                entity.Property(e => e.BoardUniversity_12th).IsRequired(false);
                entity.Property(e => e.Subjects_12th).IsRequired(false);

                entity.Property(e => e.EducationalQualifications_ITI).IsRequired(false);
                entity.Property(e => e.YearOfPassing_ITI).IsRequired(false);
                entity.Property(e => e.MarksObtained_ITI).IsRequired(false);
                entity.Property(e => e.TotalMarks_ITI).IsRequired(false);
                entity.Property(e => e.Percentage_ITI).IsRequired(false);
                entity.Property(e => e.Division_ITI).IsRequired(false);
                entity.Property(e => e.BoardUniversity_ITI).IsRequired(false);
                entity.Property(e => e.Subjects_ITI).IsRequired(false);

                entity.Property(e => e.EducationalQualifications_Diploma).HasMaxLength(255).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.YearOfPassing_Diploma).HasMaxLength(4).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.MarksObtained_Diploma).HasMaxLength(10).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.TotalMarks_Diploma).HasMaxLength(10).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Percentage_Diploma).HasMaxLength(5).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Division_Diploma).HasMaxLength(10).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.BoardUniversity_Diploma).HasMaxLength(100).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Subjects_Diploma).HasMaxLength(255).IsRequired(false).IsUnicode(false);

                entity.Property(e => e.EducationalQualifications_Bachelor).HasMaxLength(255).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.YearOfPassing_Bachelor).HasMaxLength(4).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.MarksObtained_Bachelor).HasMaxLength(10).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.TotalMarks_Bachelor).HasMaxLength(10).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Percentage_Bachelor).HasMaxLength(5).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Division_Bachelor).HasMaxLength(10).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.BoardUniversity_Bachelor).HasMaxLength(100).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Subjects_Bachelor).HasMaxLength(255).IsRequired(false).IsUnicode(false);

                entity.Property(e => e.EducationalQualifications_Master).HasMaxLength(255).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.YearOfPassing_Master).HasMaxLength(4).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.MarksObtained_Master).HasMaxLength(10).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.TotalMarks_Master).HasMaxLength(10).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Percentage_Master).HasMaxLength(5).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Division_Master).HasMaxLength(10).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.BoardUniversity_Master).HasMaxLength(100).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Subjects_Master).HasMaxLength(255).IsRequired(false).IsUnicode(false);

                entity.Property(e => e.Higher_Qualification).HasMaxLength(255).IsRequired(false).IsUnicode(false);
                entity.Property(e => e.Experience_Years).IsRequired();
                entity.Property(e => e.Experience_Months).IsRequired();
                entity.Property(e => e.Experience_Days).IsRequired();

                entity.Property(e => e.VisibleIdentification).HasMaxLength(255).IsRequired(false).IsUnicode(false);
            });
            modelBuilder.Entity<JobAdvertisement>(entity =>
            {
                entity.ToTable("JobAdvertisement");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.AdvertisementNo).HasMaxLength(255).IsRequired();
                entity.Property(e => e.AdvertisementDate).IsRequired();
                entity.Property(e => e.LastDate).IsRequired();
                entity.Property(e => e.Category).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Post).HasMaxLength(255).IsRequired();
                entity.Property(e => e.ApplicationFeeGEN).IsRequired();
                entity.Property(e => e.ApplicationFeeOTH).IsRequired();
                entity.Property(e => e.FileUrl).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Status).HasMaxLength(10).IsRequired();
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}