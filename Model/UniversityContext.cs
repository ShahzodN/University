using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityT.Model
{
    class UniversityContext : DbContext
    {
        public UniversityContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=University;Trusted_Connection=True;");
        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Kafedra> Kafedras { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>(UniversityConfigure);
            modelBuilder.Entity<Institute>(InstituteConfigure);
            modelBuilder.Entity<Faculty>(FacultyConfigure);
            modelBuilder.Entity<Kafedra>(KafedraConfigure);
            modelBuilder.Entity<Group>(GroupConfigure);
            modelBuilder.Entity<Student>(StudentConfigure);
            modelBuilder.Entity<Specialty>(SpecialtyConfigure);
            modelBuilder.Entity<TeacherSubject>(TeacherSubjectConfigure);
        }

        void UniversityConfigure(EntityTypeBuilder<University> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasMany(u => u.Institutes).WithOne(i => i.University).HasForeignKey(i => i.UniversityId);
            builder.Property(u => u.Name).IsRequired();
        }

        void InstituteConfigure(EntityTypeBuilder<Institute> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasMany(i => i.Faculties).WithOne(f => f.Institute).HasForeignKey(f => f.InstituteId);
            builder.Property(i => i.Name).IsRequired();
        }

        void FacultyConfigure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasKey(f => f.Id);
            builder.HasMany(f => f.Kafedras).WithOne(k => k.Faculty).HasForeignKey(k => k.FacultyId);
            builder.Property(f => f.Name).IsRequired();
        }

        void KafedraConfigure(EntityTypeBuilder<Kafedra> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasMany(k => k.Groups).WithOne(g => g.Kafedra).HasForeignKey(g => g.KafedraId);
            builder.HasMany(k => k.Teachers).WithOne(t => t.Kafedra).HasForeignKey(t => t.KafedraId);
            builder.Property(k => k.Name).IsRequired();
        }

        void GroupConfigure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.Id);
            builder.HasMany(g => g.Students).WithOne(s => s.Group).HasForeignKey(s => s.GroupId);
            builder.Property(g => g.Number).IsRequired();
        }

        void StudentConfigure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();
            builder.Property(s => s.MiddleName).IsRequired();
        }

        void SpecialtyConfigure(EntityTypeBuilder<Specialty> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.Students).WithOne(s => s.Specialty).HasForeignKey(s => s.SpecialtyId);
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Number).IsRequired();
        }
        
        void TeacherSubjectConfigure(EntityTypeBuilder<TeacherSubject> builder)
        {
            builder.HasKey(t => new { t.TeacherId, t.SubjectId });
            builder.HasOne(t => t.Teacher).WithMany(t => t.TeacherSubjects).HasForeignKey(t => t.TeacherId);
            builder.HasOne(t => t.Subject).WithMany(t => t.TeacherSubject).HasForeignKey(t => t.SubjectId);
        }
    }
}
