using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string course_name { get; set; }
        public string duration { get; set; }
        public string field { get; set; }
        public int max_student { get; set; }
        public string comments { get; set; }

        public ICollection<Student> Students { get; set; }

        public Teacher Teacher { get; set; }

    }
}
