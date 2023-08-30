using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Application.ViewModels.Courses
{
    public class VM_Get_CoursesByFaculty
    {

        public Guid courseId { get; set; }
        public Guid teacherId { get; set; }
        public string teacherName { get; set; }
        public string facultyName { get; set; }
        public string departmentName { get; set; }
        public string courseName { get; set; }
        public string courseCode { get; set; }
        public int openCapacity { get; set; }
        public string semester { get; set; }
        public int weeklyHours { get; set; }
        public string courseDays { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }

    }
}
