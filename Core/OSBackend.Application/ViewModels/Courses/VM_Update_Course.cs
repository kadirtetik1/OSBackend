using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Application.ViewModels.Courses
{
    public class VM_Update_Course
    {
        public string Id { get; set; }
        public string faculty { get; set; }
        public string department { get; set; }
        public string course_name { get; set; }
        public string course_code { get; set; }
        public int capacity { get; set; }
        public string semester { get; set; }
        public int weeklyHours { get; set; }
    }
}
