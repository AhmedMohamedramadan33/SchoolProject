using School.Data.Procedures;

namespace School.Service.Abstract
{
    public interface IDepartmentProc
    {
        public Task<GetDepartmentWithStdCountProc> getDepartmentWithStdCountProcs(GetDepartmentWithStdCountProcparam param);

    }
}
