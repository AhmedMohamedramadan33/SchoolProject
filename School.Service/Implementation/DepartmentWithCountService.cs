using School.Data.Entities;
using School.Infrastructure.Abstract;
using School.Service.Abstract;

namespace School.Service.Implementation
{
    public class DepartmentWithCountService : IDepartmentWithCountService
    {
        private readonly IDepartmentWithCountView _repository;
        public DepartmentWithCountService(IDepartmentWithCountView repository)
        {
            _repository = repository;
        }

        public IQueryable<GetDepartmentwithstudentcount> _GetDepartmentwithstudentcount()
        {
            return _repository.GetTableAsTracking().AsQueryable();
        }
    }
}
