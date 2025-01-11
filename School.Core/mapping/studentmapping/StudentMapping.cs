using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Feature.mapping
{
    public partial class StudentMapping:Profile
    {
        public StudentMapping() { 
            GetStudentListMapping();
            CreateStudentMapping();
        }
    }
}
