﻿using System;
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
        public virtual DbSet<Complain> Complains { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Lab> Labs { get; set; } = null!;
        public virtual DbSet<MaintainceDevice> MaintainceDevices { get; set; } = null!; 
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Slot> Slots { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-A16M1PC\\NUN;Database=eProject3;uid=sa;pwd=04012003");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.Role).IsUnicode(false);
            });

            modelBuilder.Entity<Complain>(entity =>
            {
                entity.HasKey(e => e.ComplainId)
                    .HasName("PK__Complain__46A70C13D3F020E5");

                entity.ToTable("Complain");

                entity.Property(e => e.ComplainId).HasColumnName("Complain_ID");

                entity.Property(e => e.DateCp)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_CP");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.StatusCp).HasColumnName("Status_CP");

                //entity.HasOne(d => d.Admins)
                //    .WithMany(p => p.Slots)
                //    .HasForeignKey(d => d.AdminsId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_admins_ID");

                entity.Property(e => e.Reply).HasColumnName("Reply");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.DevicesId)
                    .HasName("PK__Devices__36D9232AC44A680B");

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

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LabsId).HasColumnName("Labs_ID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Labs)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.LabsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Labs");
            });

            modelBuilder.Entity<Lab>(entity =>
            {
                entity.HasKey(e => e.LabsId)
                    .HasName("PK__Labs__A74E2712A4F986F5");

                entity.Property(e => e.LabsId).HasColumnName("Labs_ID");

                entity.Property(e => e.LabsName).IsUnicode(false);
            });

            modelBuilder.Entity<MaintainceDevice>(entity =>
            {
                entity.HasKey(e => e.MaintnId)
                    .HasName("PK__Maintain__156624B00AC36A19");

                entity.Property(e => e.MaintnId).HasColumnName("Maintn_ID");

                entity.Property(e => e.Creater).IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Descriptions).IsUnicode(false);

                entity.Property(e => e.DevicesId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Devices_ID");

                entity.Property(e => e.isFinished).HasColumnName("isFinished");

                entity.Property(e => e.Reason).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.Devices)
                    .WithMany(p => p.MaintainDevices)
                    .HasForeignKey(d => d.DevicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Device_Devices_ID");
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

                entity.HasOne(d => d.Devices)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.DevicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devices_Devices_ID");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");

                entity.Property(e => e.SlotId).HasColumnName("Slot_ID");

                entity.Property(e => e.AdminsId)
                    .HasMaxLength(50)
                    .HasColumnName("Admins_ID");

                entity.Property(e => e.Day).HasColumnType("datetime");

                entity.Property(e => e.LabId).HasColumnName("Lab_ID");

                entity.Property(e => e.Slot1).HasColumnName("slot");

                entity.HasOne(d => d.Admins)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.AdminsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_admins_ID");

                entity.HasOne(d => d.Lab)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.LabId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_labs_Lab_ID");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.Property(e => e.SupplierName).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__users__EB68290DC586CC26");

                entity.ToTable("users");

                entity.Property(e => e.UsersId).HasColumnName("Users_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
