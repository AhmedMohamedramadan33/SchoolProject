using School.Data.Procedures;
using School.Infrastructure.Abstract;
using School.Service.Abstract;

namespace School.Service.Implementation
{
    public class DepartmentProc : IDepartmentProc
    {
        private readonly IDepartmentProcedure _procedure;

        public DepartmentProc(IDepartmentProcedure procedure)
        {
            _procedure = procedure;
        }

        public Task<GetDepartmentWithStdCountProc> getDepartmentWithStdCountProcs(GetDepartmentWithStdCountProcparam param)
        {
            return _procedure.getDepartmentWithStdCountProcs(param);
        }
    }
}
