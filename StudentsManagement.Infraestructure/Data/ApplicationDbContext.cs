using System;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Entities;

namespace StudentsManagement.Infraestructure.Data
{
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(st => st.Student)
                .WithMany(ss => ss.Subjects)
                .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(sb => sb.Subject)
                .WithMany(s => s.Subjects)
                .HasForeignKey(sb => sb.SubjectId);

            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Subjects)
                .WithOne(o => o.Teacher)
                .HasForeignKey(o => o.TeacherId)
                .IsRequired();
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
                entity.Property(e => e.CreateAt)
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}
