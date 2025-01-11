using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Data
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 

        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmetSubject> DepartmetSubjects { get; set;}
        public virtual DbSet<Subject> Subjects { get; set; }

    }
}
