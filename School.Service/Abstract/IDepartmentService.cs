using School.Data.Entities;

namespace School.Service.Abstract
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int id);
    }
}
