using School.Data.Procedures;
using School.Infrastructure.Abstract;
using School.Infrastructure.Data;
using StoredProcedureEFCore;

namespace School.Infrastructure.Repositories
{
    public class Departmentprocedurerepo : IDepartmentProcedure
    {
        private readonly AppDbContext _context;

        public Departmentprocedurerepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetDepartmentWithStdCountProc> getDepartmentWithStdCountProcs(GetDepartmentWithStdCountProcparam param)
        {

            var rows = new GetDepartmentWithStdCountProc();

            await _context.LoadStoredProc(nameof(GetDepartmentWithStdCountProc))
                   .AddParam(nameof(GetDepartmentWithStdCountProcparam.did), param.did)
                   .ExecAsync(async r =>
                     rows = await r.FirstOrDefaultAsync<GetDepartmentWithStdCountProc>());
            return rows;
        }
    }
}
//async r => rows = await r.ToListAsync<GetDepartmentWithStdCountProc>()