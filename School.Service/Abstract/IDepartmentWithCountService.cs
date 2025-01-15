using School.Data.Entities;

namespace School.Service.Abstract
{
    public interface IDepartmentWithCountService
    {
        IQueryable<GetDepartmentwithstudentcount> _GetDepartmentwithstudentcount();

    }
}
