using OSBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Domain.Entities
{
    public class Teacher : User
    {
        public string? ProfessionArea { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
