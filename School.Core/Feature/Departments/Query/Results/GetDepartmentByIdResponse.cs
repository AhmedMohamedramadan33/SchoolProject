using School.Core.Paginated;

namespace School.Core.Feature.Departments.Query.Results
{
    public class GetDepartmentByIdResponse
    {
        public int DID { get; set; }
        public string DName { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResponse<StudentResponse>? Students { get; set; }
        public List<SubjectResponse>? Subjects { get; set; }
        public List<InstructResponse>? Instructors { get; set; }
    }
    public class StudentResponse
    {
        public StudentResponse(int iD, string name)
        {
            StudID = iD;
            Name = name;
        }
        public int StudID { get; set; }

        public string Name { get; set; }

    }


    public class SubjectResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class InstructResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
