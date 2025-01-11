using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Data.Sorting;
using School.Infrastructure.Abstract;
using School.Service.Abstract;

namespace School.Service.Services
{
    public class Studentservice : IStudentService
    {
        private readonly IStudentRepository _student;

        public Studentservice(IStudentRepository student)
        {
            _student = student;
        }

        public async Task<string> AddStudent(Student student)
        {
            var iseexist = await IsNameExist(student.Name);
            if (iseexist)
            {
                return "Exist";
            }
            var res = await _student.AddAsync(student);
            return "success";
        }

        public async Task<string> Delete(int id)
        {
            var res = await GetStudentById(id);
            if (res == null) return "notfound";
            await _student.DeleteAsync(res);
            return "success";

        }

        public IQueryable<Student> GetStudent()
        {
            return _student.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _student.GetTableNoTracking().Include(x => x.Department).FirstOrDefaultAsync(x => x.StudID == id);
        }

        public async Task<bool> IsNameExist(string name)
        {
            return await _student.GetTableNoTracking().AnyAsync(x => x.Name == name);
        }

        public async Task<bool> IsNameExistWithOther(int id, string name)
        {
            return await _student.GetTableNoTracking().AnyAsync(x => x.Name == name && x.StudID != id);
        }

        public IQueryable<Student> orderby(IQueryable<Student> query, StudentSorting? stdsort, bool? isdescenfing = false)
        {
            switch (stdsort)
            {
                case StudentSorting.StudentId:
                    query = _student.OrderBy(query, x => x.StudID, isdescenfing);
                    break;
                case StudentSorting.Name:
                    query = _student.OrderBy(query, x => x.Name, isdescenfing);
                    break;
                case StudentSorting.Address:
                    query = _student.OrderBy(query, x => x.Address, isdescenfing);
                    break;
                default:
                    query = _student.OrderBy(query, x => x.Name, isdescenfing);
                    break;
            }
            return query;
        }

        public IQueryable<Student> Search(string? search)
        {
            return _student.SearchAsync(x => (string.IsNullOrEmpty(search) || x.Name.Contains(search)));
        }

        public async Task<string> UpdateStudent(int id, Student student)
        {
            if (!await _student.GetTableNoTracking().AnyAsync(x => x.StudID == id))
            {
                return "notfound";
            }
            var res = await IsNameExistWithOther(id, student.Name);
            if (res) { return "Exist"; }
            await _student.UpdateAsync(student);
            return "success";
        }
    }
}
