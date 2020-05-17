﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUDCore.Models.MyModels.OriginalDB
{
    public partial class CRUDAPPContext : DbContext
    {
        public CRUDAPPContext()
        {
        }

        public CRUDAPPContext(DbContextOptions<CRUDAPPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CtRoles> CtRoles { get; set; }
        public virtual DbSet<CtUsers> CtUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7VHO3GN\\SQLEXPRESS;Database=CRUDAPP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CtRoles>(entity =>
            {
                entity.ToTable("CT_Roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CtUsers>(entity =>
            {
                entity.ToTable("CT_Users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.LastAccess).HasColumnType("date");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.CtUsers)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_CT_Users_CT_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
