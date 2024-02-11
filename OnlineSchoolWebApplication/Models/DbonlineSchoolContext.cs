using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineSchoolWebApplication.Models;

public partial class DbonlineSchoolContext : DbContext
{
    public DbonlineSchoolContext()
    {
    }

    public DbonlineSchoolContext(DbContextOptions<DbonlineSchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentSubscription> StudentSubscriptions { get; set; }

    public virtual DbSet<StudentTeacher> StudentTeachers { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherSpecialization> TeacherSpecializations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= LAPTOP-8CSE747M\\SQLEXPRESS; Database=DBOnlineSchool; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.Property(e => e.SpecializationName).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Charasteristic).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<StudentSubscription>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.SubscriptionId });

            entity.HasOne(d => d.Student).WithMany(p => p.StudentSubscriptions)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubscriptions_Students");

            entity.HasOne(d => d.Subscription).WithMany(p => p.StudentSubscriptions)
                .HasForeignKey(d => d.SubscriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubscriptions_Subscriptions");
        });

        modelBuilder.Entity<StudentTeacher>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.TeacherSpecializationId });

            entity.HasOne(d => d.Student).WithMany(p => p.StudentTeachers)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentTeachers_Students");

            entity.HasOne(d => d.TeacherSpecialization).WithMany(p => p.StudentTeachers)
                .HasForeignKey(d => d.TeacherSpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentTeachers_TeacherSpecializations1");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TeacherSpecialization>(entity =>
        {
            entity.HasOne(d => d.Specialization).WithMany(p => p.TeacherSpecializations)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherSpecializations_Specializations");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherSpecializations)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherSpecializations_Teachers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
