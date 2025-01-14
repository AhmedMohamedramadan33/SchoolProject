using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Abstract;
using School.Service.Abstract;

namespace School.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _department;

        public DepartmentService(IDepartmentRepository department)
        {
            _department = department;
        }

        public async Task<bool> checkdepartment(int did)
        {
            return await _department.GetTableNoTracking().AnyAsync(x => x.DID.Equals(did));
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _department.GetTableNoTracking().Where(x => x.DID == id).Include(x => x.Instructor).
                Include(x => x.Instructors).Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
                .FirstOrDefaultAsync();
        }
    }
}
