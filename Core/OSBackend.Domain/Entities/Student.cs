using OSBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Domain.Entities
{
    public class Student : User
    {
        public string department { get; set; }
        public int grade_year { get; set; }

        public ICollection<Course> Courses { get; set;}

    }
}
