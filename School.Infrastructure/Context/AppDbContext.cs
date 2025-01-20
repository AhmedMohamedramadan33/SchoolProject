using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Data.Entities.Identity;
using System.Reflection;

namespace School.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetDepartmentwithstudentcount>().HasNoKey().ToView("GetDepartmentwithstudentcount");
            modelBuilder.Entity<Ins_Subject>().HasKey(x => new { x.SubId, x.InsId });
            modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.SubID, x.StudID });
            modelBuilder.Entity<DepartmetSubject>().HasKey(x => new { x.SubID, x.DID });

            modelBuilder.Entity<Instructor>().HasOne(x => x.Supervisor).WithMany(x => x.Instructors).HasForeignKey(x => x.SupervisorId).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>().HasOne(x => x.Instructor).WithOne(x => x.departmentManager).HasForeignKey<Department>(x => x.InsManager).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<GetDepartmentwithstudentcount> GetDepartmentsWithstudentcount { get; set; }

    }
}
