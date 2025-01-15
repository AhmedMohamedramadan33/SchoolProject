using School.Data.Procedures;

namespace School.Infrastructure.Abstract
{
    public interface IDepartmentProcedure
    {
        public Task<GetDepartmentWithStdCountProc> getDepartmentWithStdCountProcs(GetDepartmentWithStdCountProcparam param);
    }
}
