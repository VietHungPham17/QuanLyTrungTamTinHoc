using DALayer.Migrations;
using DTLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name = StudentM")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBContext, Configuration>("StudentM"));
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Diary> Diaries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Transcript> Transcripts { get; set; }
        public virtual DbSet<Center> Centers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.Tuition)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Registers)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Transcripts)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Account)
                .WithRequired(e => e.Employee);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Register>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Register>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Register>()
                .Property(e => e.Debt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Register>()
                .HasMany(e => e.Receipts)
                .WithOptional(e => e.Register)
                .HasForeignKey(e => new { e.StudentID, e.CourseID });

            modelBuilder.Entity<Register>()
                .HasMany(e => e.Transcripts)
                .WithRequired(e => e.Register)
                .HasForeignKey(e => new { e.StudentID, e.CourseID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Registers)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Transcripts)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
