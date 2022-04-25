using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lva_project.Models
{
    public partial class LvaContext : DbContext
    {
        public LvaContext()
        {
        }

        public LvaContext(DbContextOptions<LvaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lva> Lvas { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=admin;password=admin;database=db01", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.7.3-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Lva>(entity =>
            {
                entity.ToTable("lva");

                entity.Property(e => e.LvaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("lva_id");

                entity.Property(e => e.LvaCreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("lva_created_on");

                entity.Property(e => e.LvaEcts).HasColumnName("lva_ects");

                entity.Property(e => e.LvaExam)
                    .HasColumnType("datetime")
                    .HasColumnName("lva_exam");

                entity.Property(e => e.LvaGrade)
                    .HasColumnType("int(11)")
                    .HasColumnName("lva_grade");

                entity.Property(e => e.LvaInstitute)
                    .HasMaxLength(20)
                    .HasColumnName("lva_institute");

                entity.Property(e => e.LvaName)
                    .HasMaxLength(50)
                    .HasColumnName("lva_name");

                entity.Property(e => e.LvaNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("lva_number");

                entity.Property(e => e.LvaRoom)
                    .HasMaxLength(10)
                    .HasColumnName("lva_room");

                entity.Property(e => e.LvaTeacher)
                    .HasMaxLength(50)
                    .HasColumnName("lva_teacher");

                entity.Property(e => e.LvaType)
                    .HasColumnType("int(11)")
                    .HasColumnName("lva_type");

                entity.Property(e => e.SemId)
                    .HasColumnType("int(11)")
                    .HasColumnName("sem_id");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.SemId)
                    .HasName("PRIMARY");

                entity.ToTable("semester");

                entity.HasIndex(e => e.SemId, "semester_sem_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.SemName, "semester_sem_name_uindex")
                    .IsUnique();

                entity.Property(e => e.SemId)
                    .HasColumnType("int(11)")
                    .HasColumnName("sem_id");

                entity.Property(e => e.SemName)
                    .HasMaxLength(20)
                    .HasColumnName("sem_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
