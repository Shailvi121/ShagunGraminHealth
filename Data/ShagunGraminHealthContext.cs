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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

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

                entity.Property(e => e.Id).ValueGeneratedNever();

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

                entity.Property(e => e.PlanFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlanName).HasMaxLength(100);

                entity.Property(e => e.PlanNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<MembershipForm>(entity =>
            {
                entity.ToTable("MembershipForm");

                entity.HasKey(e => e.Id);

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}