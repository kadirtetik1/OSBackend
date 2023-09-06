using OSBackend.Application.ViewModels.Courses;
using OSBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Application.Repository.CourseRepository
{
    public interface ICourseReadRepository : IReadRepository<Course>
    {
        Task<List<Course>> GetByIdAsyncTeacher(string TeacherId, bool tracking = true);   // Şu anda sadece 1.yi getiriyor, hepsini getirmesini sağla.
        Task<List<VM_Get_CoursesByFaculty>> GetWithTeacherInfo(bool tracking = true); 
       
    }


}
