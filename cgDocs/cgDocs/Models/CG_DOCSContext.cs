﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cgDocs.Models
{
    public partial class CG_DOCSContext : DbContext
    {
        public CG_DOCSContext()
        {
        }

        public CG_DOCSContext(DbContextOptions<CG_DOCSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Folders> Folders { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CG_DOCS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.ToTable("documents");

                entity.Property(e => e.DocumentId).HasColumnName("document_id");

                entity.Property(e => e.DocumentContentType)
                    .HasColumnName("document_content_type")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentCreatedAt)
                    .HasColumnName("document_created_at")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DocumentCreatedBy).HasColumnName("document_created_by");

                entity.Property(e => e.DocumentIsDeleted).HasColumnName("document_isDeleted");

                entity.Property(e => e.DocumentName)
                    .HasColumnName("document_name")
                    .HasMaxLength(20);

                entity.Property(e => e.DocumentSize).HasColumnName("document_size");

                entity.Property(e => e.FolderId).HasColumnName("folderId");

                entity.HasOne(d => d.DocumentCreatedByNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocumentCreatedBy)
                    .HasConstraintName("FK__documents__docum__5CD6CB2B");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK__documents__folde__5EBF139D");
            });

            modelBuilder.Entity<Folders>(entity =>
            {
                entity.HasKey(e => e.FolderId);

                entity.ToTable("folders");

                entity.Property(e => e.FolderId).HasColumnName("folder_id");

                entity.Property(e => e.FolderCreatedAt)
                    .HasColumnName("folder_created_at")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.FolderCreatedBy).HasColumnName("folder_created_by");

                entity.Property(e => e.FolderIsDeleted).HasColumnName("folder_isDeleted");

                entity.Property(e => e.FolderName)
                    .HasColumnName("folder_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.FolderCreatedByNavigation)
                    .WithMany(p => p.Folders)
                    .HasForeignKey(d => d.FolderCreatedBy)
                    .HasConstraintName("FK__folders__folder___5535A963");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.UserPassword)
                    .HasColumnName("user_password")
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(100);
            });
        }
    }
}
