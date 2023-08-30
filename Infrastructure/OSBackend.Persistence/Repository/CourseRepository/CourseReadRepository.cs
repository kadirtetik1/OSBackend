using Microsoft.EntityFrameworkCore;
using OSBackend.Application.Repository.CourseRepository;
using OSBackend.Application.ViewModels.Courses;
using OSBackend.Domain.Entities;
using OSBackend.Persistence.Contexts;


namespace OSBackend.Persistence.Repository.CourseRepository
{
    public class CourseReadRepository : ReadRepository<Course>, ICourseReadRepository
    {
        public CourseReadRepository(OsBackendDbContext context) : base(context)
        {

        }

        //List<VM_x>  => object yerine ?
        public async Task<List<VM_Get_CoursesByFaculty>> GetWithTeacherInfo(bool tracking = true)
        {

            return await Table.AsNoTracking()
                              .Include(course => course.Teacher)
                              //.GroupBy(course => course.faculty)
                              .Select(course => new VM_Get_CoursesByFaculty
                              {
                                  courseName = course.course_name,
                                  courseCode=course.course_code,
                                  openCapacity=course.capacity,
                                  facultyName = course.faculty,
                                  departmentName= course.department,
                                  semester = course.semester,
                                  weeklyHours = course.weeklyHours,
                                  startTime =course.startHours,
                                  endTime=course.endHours,
                                  courseDays = course.days,
                                  teacherName = course.Teacher.first_name + " " + course.Teacher.last_name,
                                  courseId=course.Id,
                                  teacherId=course.TeacherId,

                              }).ToListAsync();
        }

        public async Task<List<Course>> GetByIdAsyncTeacher(string TeacherId, bool tracking = true)

        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }

            //return await query.FirstOrDefaultAsync(data => data.TeacherId == Guid.Parse(TeacherId));

            return await query.Where(data => data.TeacherId == Guid.Parse(TeacherId)).ToListAsync();

        }
    }
}
