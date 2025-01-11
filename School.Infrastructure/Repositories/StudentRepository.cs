using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Abstract;
using School.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository:GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext dbContext;
        private DbSet<Student> _dbset;
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
            _dbset = dbContext.Set<Student>();
        }
 
        
    }
}
