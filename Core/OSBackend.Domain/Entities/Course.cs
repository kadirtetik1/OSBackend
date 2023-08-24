using OSBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string faculty { get; set; }
        public string department { get; set; }
        public string course_name { get; set; }
        public string course_code { get; set; }
        public int capacity { get; set; }
        public string semester { get; set; }
        public int weeklyHours { get; set; }
        public string? days { get; set; }
        public string? startHours { get; set; }
        public string? endHours { get; set; }
        public Guid TeacherId { get; set; }
        

        public ICollection<Student> Students { get; set; }

        public Teacher Teacher { get; set; }

    }
}
