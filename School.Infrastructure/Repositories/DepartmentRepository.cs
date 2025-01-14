using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Abstract;
using School.Infrastructure.Data;

namespace School.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly DbSet<Department> _dbSet;
        public DepartmentRepository(AppDbContext context) : base(context)
        {

            _dbSet = context.Set<Department>();
        }
    }
}
