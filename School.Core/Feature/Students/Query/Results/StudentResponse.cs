
using System.ComponentModel.DataAnnotations;


namespace School.Core.Feature.Students.Query.Results
{
    public class StudentResponse
    {
        [Key]
        public int StudID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public string? Department { get; set; }

    }
}
