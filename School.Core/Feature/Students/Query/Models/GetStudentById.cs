using MediatR;
using School.Core.Base;
using School.Core.Feature.Students.Query.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Feature.Students.Query.Models
{
  public class GetStudentById:IRequest<Response<StudentResponse>>
    {
       public int Id { get; set; }

        public GetStudentById(int id)
        {
            Id = id;
        }
    }
}
