using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Application.ViewModels.Teachers
{
    public class VM_Update_Teacher
    {
        public string Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string academic_role { get; set; }
        public string e_mail { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string department { get; set; }
        public long phone_number { get; set; }
        public string gender { get; set; }
    }
}
