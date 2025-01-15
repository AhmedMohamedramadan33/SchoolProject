using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Abstract;
using School.Infrastructure.Data;

namespace School.Infrastructure.Repositories
{
    public class DepartmentWithCountView : GenericRepository<GetDepartmentwithstudentcount>, IDepartmentWithCountView
    {
        private DbSet<GetDepartmentwithstudentcount> _dbSet;
        public DepartmentWithCountView(AppDbContext context) : base(context)
        {
            _dbSet = context.Set<GetDepartmentwithstudentcount>();
        }
    }
}
