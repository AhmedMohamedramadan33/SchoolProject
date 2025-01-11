using School.Data.Entities;
using School.Data.Sorting;

namespace School.Service.Abstract
{
    public interface IStudentService
    {
        IQueryable<Student> GetStudent();
        Task<Student> GetStudentById(int id);
        Task<string> AddStudent(Student student);
        Task<string> UpdateStudent(int id, Student student);
        Task<bool> IsNameExist(string name);
        Task<bool> IsNameExistWithOther(int id, string name);
        Task<string> Delete(int id);
        IQueryable<Student> Search(string? search);
        IQueryable<Student> orderby(IQueryable<Student> query, StudentSorting? stdsort, bool? isdescenfing = false);


    }
}
