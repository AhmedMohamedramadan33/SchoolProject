using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Abstract;
using School.Infrastructure.Data;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private DbSet<Student> _dbset;
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbset = dbContext.Set<Student>();
        }


    }
}
