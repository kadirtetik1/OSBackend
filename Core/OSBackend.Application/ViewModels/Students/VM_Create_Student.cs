using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Application.ViewModels.Students
{
    public class VM_Create_Student
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string academic_role { get; set; }
        public string e_mail { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
    }
}
