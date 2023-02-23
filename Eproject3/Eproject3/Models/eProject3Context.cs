using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eproject3.Models
{
    public partial class eProject3Context : DbContext
    {
        public eProject3Context()
        {
        }

        public eProject3Context(DbContextOptions<eProject3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Calender> Calenders { get; set; } = null!;
        public virtual DbSet<Complain> Complains { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<Evt> Evts { get; set; } = null!;
        public virtual DbSet<Lab> Labs { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=eProject3;Trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<Calender>(entity =>
            {
                entity.HasKey(e => e.CalenId)
                    .HasName("PK__Calender__9FC7D533590802D7");

                entity.ToTable("Calender");

                entity.Property(e => e.CalenId).HasColumnName("Calen_ID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StarTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Complain>(entity =>
            {
                entity.ToTable("Complain");

                entity.Property(e => e.ComplainId).HasColumnName("Complain_ID");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.UsersId).HasColumnName("Users_ID");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_Users_ID");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.DevicesId)
                    .HasName("PK__Devices__36D9232A9D837E87");

                entity.Property(e => e.DevicesId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Devices_ID");

                entity.Property(e => e.DateMaintance).HasColumnType("datetime");

                entity.Property(e => e.LabsId).HasColumnName("Labs_ID");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.HasOne(d => d.Labs)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.LabsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_labs_Labs_ID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_supplier_Supplier_ID");
            });

            modelBuilder.Entity<Evt>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__Evt__30FA9DB1AD133928");

                entity.ToTable("Evt");

                entity.Property(e => e.ReportId).HasColumnName("Report_ID");

                entity.Property(e => e.CalenId).HasColumnName("Calen_ID");

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.EventDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Event_Date");

                entity.Property(e => e.Minititle).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Calen)
                    .WithMany(p => p.Evts)
                    .HasForeignKey(d => d.CalenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Calender_Calen_ID");
            });

            modelBuilder.Entity<Lab>(entity =>
            {
                entity.HasKey(e => e.LabsId)
                    .HasName("PK__Labs__A74E2712C11F76F8");

                entity.Property(e => e.LabsId).HasColumnName("Labs_ID");

                entity.Property(e => e.LabsName).IsUnicode(false);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report");

                entity.Property(e => e.ReportId).HasColumnName("Report_ID");

                entity.Property(e => e.ComplainId).HasColumnName("Complain_ID");

                entity.Property(e => e.Descriptions).IsUnicode(false);

                entity.Property(e => e.DevicesId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Devices_ID");

                entity.Property(e => e.Reciver).IsUnicode(false);

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.HasOne(d => d.Complain)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ComplainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_report_Report_ID");

                entity.HasOne(d => d.Devices)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.DevicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devices_Devices_ID");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.Property(e => e.SupplierName).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__users__EB68290DA6C2CA51");

                entity.ToTable("users");

                entity.Property(e => e.UsersId).HasColumnName("Users_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
